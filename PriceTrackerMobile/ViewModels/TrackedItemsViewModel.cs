using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using PriceTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class TrackedItemsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Game> Games { get; set; }

        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<Game> DeleteCommand { get; }
        public AsyncCommand AddCommand { get; }

        public TrackedItemsViewModel()
        {
            Title = "Tracked Games";
            Games = new ObservableRangeCollection<Game>();

            RefreshCommand = new AsyncCommand(RefreshPage);
            DeleteCommand = new AsyncCommand<Game>(Delete);
            AddCommand = new AsyncCommand(GoToAddPage);

            RefreshPage();
        }

        async Task Delete(Game game)
        {
            if (game == null)
                return;

            await PriceTrackerApiService.DeleteGame(game);
            await RefreshPage();
        }

        async Task RefreshPage()
        {
            IsBusy = true;

            var newGames = await PriceTrackerApiService.GetGames();
            Games.Clear();
            Games.AddRange(newGames);

            IsBusy = false;
        }

        async Task GoToAddPage()
        {
            string route = $"{nameof(AddItemPage)}";
            await Shell.Current.GoToAsync(route);
        }
    }
}
