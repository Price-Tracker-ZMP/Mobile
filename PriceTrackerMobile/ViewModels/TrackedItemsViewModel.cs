using MvvmHelpers;
using MvvmHelpers.Commands;
using Plugin.LocalNotification;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Response;
using PriceTrackerMobile.Services.Toast;
using PriceTrackerMobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;
using System;

namespace PriceTrackerMobile.ViewModels
{
    public class TrackedItemsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Game> Games { get; set; }

        IPriceTrackerApiService apiService;

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<long> DeleteCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Game> DetailsCommand { get; }

        public TrackedItemsViewModel()
        {
            Title = "Tracked Games";
            Games = new ObservableRangeCollection<Game>();
            apiService = DependencyService.Get<IPriceTrackerApiService>();

            RefreshCommand = new AsyncCommand(RefreshPage);
            DeleteCommand = new AsyncCommand<long>(DeleteGame);
            AddCommand = new AsyncCommand(GoToAddPage);
            DetailsCommand = new AsyncCommand<Game>(GoToDetailsPage);

            Task.Run(FetchSteamAppsList);
            Task.Run(StartNotyfying);
        }

        async Task DeleteGame(long gameId)
        {
            ApiResponse response = await apiService.DeleteGame(gameId);
            if (response.status)
            {
                await RefreshPage();
                await new SuccessToastService().ShowAsync(response.message);
            }
            else
                await new ErrorToastService().ShowAsync(response.message);
        }

        public async Task RefreshPage()
        {
            IsBusy = true;

            ApiResponse<IEnumerable<Game>> response = await apiService.GetGames();

            if (response.status)
            {
                Games.Clear();
                var games = response.content;
                Games.AddRange(games);
            }
            else
                await new ErrorToastService().ShowAsync(response.message);

            IsBusy = false;
        }

        async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AddItemPage)}");
        }

        async Task GoToDetailsPage(Game game)
        {
            await Shell.Current.GoToAsync($"{nameof(PriceDetailPage)}?GameId={game.SteamAppId}&GameName={game.Name}");
        }

        async Task FetchSteamAppsList()
        {
            Settings.AvailableGames = apiService.GetSteamGames().Result.content;
        }

        async Task StartNotyfying()
        {
            int millisecondsDelay = 30000;

            List<NotificationRequest> notofications = new List<NotificationRequest>();

            while (true)
            {
                await Task.Delay(millisecondsDelay);

                ApiResponse<IEnumerable<Game>> response = await apiService.GetGames();
                List<Game> refreshedList = response.content.ToList();

                for (int i = 0; i < Games.Count; i++)
                {
                    Game newGame = refreshedList.FirstOrDefault(g => g.Name == Games[i].Name);
                    if (Games[i].PriceFinal != newGame.PriceFinal)
                    {
                        NotificationRequest basenotification = new NotificationRequest
                        {
                            Title = "New price, check this out!",
                            Description = $"Price for {Games[i].Name} has changed " +
                            $"from {Games[i].PriceFinal}{Games[i].Currency} to {refreshedList[i].PriceFinal}{refreshedList[i].Currency}",
                            BadgeNumber = 10,
                            NotificationId = i,
                            CategoryType = NotificationCategoryType.Promo,
                            Schedule = new NotificationRequestSchedule()
                            {
                                NotifyTime = System.DateTime.Now,
                            }
                        };

                        notofications.Add(basenotification);
                    }
                }

                if (notofications.Count > 0)
                {
                    Games.Clear();
                    Games.AddRange(refreshedList);

                    foreach (NotificationRequest notification in notofications)
                    {
                        NotificationCenter.Current.Show(notification);
                    }

                    notofications.Clear();
                }
            }
        }
    }
}
