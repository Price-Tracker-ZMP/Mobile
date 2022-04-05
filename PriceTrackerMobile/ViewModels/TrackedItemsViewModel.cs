using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using PriceTrackerMobile.Services.Toast;
using PriceTrackerMobile.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class TrackedItemsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<FetchedGame> Games { get; set; }

        IPriceTrackerApiService apiService;

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<FetchedGame> DeleteCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<FetchedGame> DetailsCommand { get; }

        public TrackedItemsViewModel()
        {
            Title = "Tracked Games";
            Games = new ObservableRangeCollection<FetchedGame>();
            apiService = DependencyService.Get<IPriceTrackerApiService>();

            RefreshCommand = new AsyncCommand(RefreshPage);
            DeleteCommand = new AsyncCommand<FetchedGame>(DeleteGame);
            AddCommand = new AsyncCommand(GoToAddPage);
            DetailsCommand = new AsyncCommand<FetchedGame>(GoToDetailsPage);
        }

        async Task DeleteGame(FetchedGame game)
        {
            if (game == null)
                return;

            await PriceTrackerApiService.DeleteGame(game);
            await RefreshPage();
            await new ErrorToastService().ShowAsync("Game deleted");
        }

        public async Task RefreshPage()
        {
            IsBusy = true;

            IEnumerable<FetchedGame> newGames = await apiService.GetGames();
            Games.Clear();
            Games.AddRange(newGames);

            IsBusy = false;
        }

        async Task GoToAddPage()
        {
            await Shell.Current.GoToAsync($"{nameof(AddItemPage)}");
        }

        async Task GoToDetailsPage(FetchedGame game)
        {
            if (game == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(PriceDetailPage)}?GameId={game.Id}");
        }
    }
}
