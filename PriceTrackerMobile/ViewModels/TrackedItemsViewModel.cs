using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using System.Threading.Tasks;

namespace PriceTrackerMobile.ViewModels
{
    public class TrackedItemsViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Game> TrackedGames { get; }
        public AsyncCommand RefreshCommand { get; }

        public TrackedItemsViewModel()
        {
            Title = "Tracked Items";

            TrackedGames = new ObservableRangeCollection<Game>();

            var image = "https://s3.gaming-cdn.com/images/products/4082/orig/nierautomata-game-of-the-yorha-edition-game-of-the-yorha-edition-pc-game-steam-cover.jpg";

            TrackedGames.Add(new Game() { Name = "Nier Automata", Id = 1, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "sabnautica", Id = 2, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "Nier Automata", Id = 1, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "sabnautica", Id = 2, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "Nier Automata", Id = 1, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "sabnautica", Id = 2, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "Nier Automata", Id = 1, ImageUrl = image });
            TrackedGames.Add(new Game() { Name = "sabnautica", Id = 2, ImageUrl = image });

            RefreshCommand = new AsyncCommand(Refresh);
        }

        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            IsBusy = false;
        }
    }
}
