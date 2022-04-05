using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        public string searchingGamePhrase { get; set; }
        public ObservableRangeCollection<FetchedGame> FilteredGames { get; set; }

        IPriceTrackerApiService apiService;

        public AsyncCommand AddCommand { get; }

        public AddItemViewModel()
        {
            Title = "Add Game";
            apiService = DependencyService.Get<IPriceTrackerApiService>();

            AddCommand = new AsyncCommand(AddGame);
            FilteredGames = new ObservableRangeCollection<FetchedGame>();
        }

        async Task AddGame()
        {
            await apiService.AddGame(new FetchedGame() { Id = 1, Name = "Nier", ImageUrl = "https://image.ceneostatic.pl/data/products/49127782/i-nier-automata-gra-ps4.jpg" });
            await Shell.Current.GoToAsync("..");
        }
    }
}
