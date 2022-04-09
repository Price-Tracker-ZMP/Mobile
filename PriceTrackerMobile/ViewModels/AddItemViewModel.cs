using MvvmHelpers;
using MvvmHelpers.Commands;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Mapper;
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

        List<FetchedGame> allFetchedGames;
        List<Game> allGames;
        IPriceTrackerApiService apiService;

        public AsyncCommand<long> AddByIdCommand { get; }
        public MvvmHelpers.Commands.Command FilterGamesCommand { get; }

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
            FilterGamesCommand = new MvvmHelpers.Commands.Command(FilterGames);
        }

        void FilterGames()
        {
            FilteredGames.Clear();
            FilteredGames.AddRange(allGames.FindAll(g => g.Name.ToLower().Contains(searchingGamePhrase.ToLower())));
        }

        async Task AddGameById(long id)
        {
            await apiService.AddGame(id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
