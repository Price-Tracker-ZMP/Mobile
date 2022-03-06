using MvvmHelpers.Commands;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        string searchSteamGameUri = "https://store.steampowered.com/games/";
        public string gameUrl { get; set; }

        public AsyncCommand AddCommand { get; }
        public AsyncCommand BrowseCommand { get; }

        public AddItemViewModel()
        {
            Title = "Add Game";

            AddCommand = new AsyncCommand(AddGame);
            BrowseCommand = new AsyncCommand(OpenBrowser);
        }

        async Task AddGame()
        {
            await PriceTrackerApiService.AddGame(new Game() { Id = 1, Name = "Nier", ImageUrl = "https://image.ceneostatic.pl/data/products/49127782/i-nier-automata-gra-ps4.jpg" });
            await Shell.Current.GoToAsync("..");
        }

        async Task OpenBrowser()
        {
            await Browser.OpenAsync(searchSteamGameUri, BrowserLaunchMode.External);
        }
    }
}
