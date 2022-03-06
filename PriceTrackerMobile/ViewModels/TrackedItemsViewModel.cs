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
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand AddCommand { get; }

        public TrackedItemsViewModel()
        {
            Title = "Coffee Equipment";
            Games = new ObservableRangeCollection<Game>();

            RefreshCommand = new AsyncCommand(Refresh);
            DeleteCommand = new AsyncCommand<Game>(Delete);
            AddCommand = new AsyncCommand(GoToAddPage);
        }

        async Task Delete(Game game)
        {
            if (game == null)
                return;

            await PriceTrackerApiService.DeleteGame(game);
            await Refresh();
        }

        async Task Refresh()
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
