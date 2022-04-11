using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Models;

namespace PriceTrackerMobile.Mapper
{
    public static class GameMapper
    {
        public static Game ConvertFetchedGame(FetchedGame fetchedGame)
        {
            Game game = new Game()
            {
                Name = fetchedGame.Name,
                SteamAppId = fetchedGame.Appid,
                ImageUrl = SteamImage.FromId(fetchedGame.Appid)
            };

            return game;
        }
    }
}
