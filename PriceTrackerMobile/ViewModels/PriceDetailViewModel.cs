using PriceTrackerMobile.Models;
using PriceTrackerMobile.Services;
using System.Threading.Tasks;

namespace PriceTrackerMobile.ViewModels
{
    public class PriceDetailViewModel : ViewModelBase
    {
        Game detailedGame;
        public Game DetailedGame
        {
            get => detailedGame;
            set => SetProperty(ref detailedGame, value);
        }

        public PriceDetailViewModel()
        {
            Title = "Price Detail";
        }

        public async Task LoadDetails(int gameId)
        {
            DetailedGame = await PriceTrackerApiService.GetGameDetails(gameId); ;
        }
    }
}
