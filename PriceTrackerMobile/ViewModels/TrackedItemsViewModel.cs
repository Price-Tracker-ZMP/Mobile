using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using System.Threading.Tasks;

namespace PriceTrackerMobile.ViewModels
{
    public class TrackedItemsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Game> Games { get; set; }

        public AsyncCommand RefreshCommand { get; }

        public AsyncCommand<Game> DeleteCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }

        public TrackedItemsViewModel()
        {

            Title = "Coffee Equipment";

            Games = new ObservableRangeCollection<Game>
            {
                new Game() { Id = 1, Name = "Nier", ImageUrl = "https://image.ceneostatic.pl/data/products/49127782/i-nier-automata-gra-ps4.jpg" },
                new Game() { Id = 2, Name = "Sabnautica", ImageUrl = "https://s2.gaming-cdn.com/images/products/1003/orig/game-steam-subnautica-cover.jpg" }
            };

            RefreshCommand = new AsyncCommand(Refresh);
            DeleteCommand = new AsyncCommand<Game>(Delete);
        }

        async Task Delete(Game game)
        {
            if (game == null)
                return;

            Games.Remove(game); ;

        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            IsBusy = false;
        }
    }
}
