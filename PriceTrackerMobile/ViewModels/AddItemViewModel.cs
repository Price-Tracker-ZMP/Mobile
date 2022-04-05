using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        public string searchingGamePhrase { get; set; }
        public ObservableRangeCollection<Game> FilteredGames { get; set; }

        List<FetchedGame> allGames;
        IPriceTrackerApiService apiService;

        public AsyncCommand AddCommand { get; }

        public AddItemViewModel()
        {
            Title = "Add Game";
            apiService = DependencyService.Get<IPriceTrackerApiService>();
            allGames = Settings.AvailableGames;

            AddCommand = new AsyncCommand(AddGame);
            FilteredGames = new ObservableRangeCollection<Game>();
        }

        async Task AddGame()
        {
            await apiService.AddGame(new Game() { Id = 1, Name = "Nier", ImageUrl = "https://image.ceneostatic.pl/data/products/49127782/i-nier-automata-gra-ps4.jpg" });
            await Shell.Current.GoToAsync("..");
        }
    }
}
