using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Mapper;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Response;
using PriceTrackerMobile.Services.Toast;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class AddItemViewModel : ViewModelBase
    {
        public string searchingGamePhrase { get; set; }
        public ObservableRangeCollection<Game> FilteredGames { get; set; }

        List<FetchedGame> allFetchedGames;
        List<Game> allGames;
        IPriceTrackerApiService apiService;

        public AsyncCommand<long> AddByIdCommand { get; }
        public MvvmHelpers.Commands.Command FilterGamesCommand { get; }
        public AsyncCommand AddByLinkCommand { get; }

        public AddItemViewModel()
        {
            Title = "Add Game";
            apiService = DependencyService.Get<IPriceTrackerApiService>();
            allFetchedGames = Settings.AvailableGames;
            allGames = new List<Game>();
            FilteredGames = new ObservableRangeCollection<Game>();
            searchingGamePhrase = "";

            foreach (FetchedGame fGame in allFetchedGames)
            {
                allGames.Add(GameMapper.ConvertFetchedGame(fGame));
            }

            AddByIdCommand = new AsyncCommand<long>(AddGameById);
            AddByLinkCommand = new AsyncCommand(AddGameByLink);
            FilterGamesCommand = new MvvmHelpers.Commands.Command(FilterGames);
        }

        void FilterGames()
        {
            FilteredGames.Clear();
            if (searchingGamePhrase != "")
                FilteredGames.AddRange(allGames.FindAll(g => g.Name.ToLower().Contains(searchingGamePhrase.ToLower())));
        }

        async Task AddGameById(long id)
        {
            ApiResponse response = await apiService.AddGame(id);

            if (response.status)
            {
                await Shell.Current.GoToAsync("..");
                await new SuccessToastService().ShowAsync(response.message);
            }
            else
                await new ErrorToastService().ShowAsync(response.message);
        }

        async Task AddGameByLink()
        {
            string link = await Application.Current.MainPage.DisplayPromptAsync("Paste steam link", "Done");

            ApiResponse response = await apiService.AddGameByLink(link);

            if (response.status)
            {
                await Shell.Current.GoToAsync("..");
                await new SuccessToastService().ShowAsync(response.message);
            }
            else
                await new ErrorToastService().ShowAsync(response.message);
        }
    }
}
