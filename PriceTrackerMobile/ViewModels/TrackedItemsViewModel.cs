using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Response;
using PriceTrackerMobile.Services.Toast;
using PriceTrackerMobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

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

            Settings.AvailableGames = apiService.GetSteamGames().Result.content;

            RefreshCommand = new AsyncCommand(RefreshPage);
            DeleteCommand = new AsyncCommand<long>(DeleteGame);
            AddCommand = new AsyncCommand(GoToAddPage);
            DetailsCommand = new AsyncCommand<Game>(GoToDetailsPage);
        }

        async Task DeleteGame(long gameId)
        {
            ApiResponse<object> response = await apiService.DeleteGame(gameId);
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

            ApiResponse<IEnumerable<Game>> trackedGamesResponse = await apiService.GetGames();
            Games.Clear();
            Games.AddRange(trackedGamesResponse.content);

            IsBusy = false;
        }

        async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AddItemPage)}");
        }

        async Task GoToDetailsPage(Game game)
        {
            await Shell.Current.GoToAsync($"{nameof(PriceDetailPage)}?GameId={game.SteamAppId}");
        }
    }
}
