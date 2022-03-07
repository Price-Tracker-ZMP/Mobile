using PriceTrackerMobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public static class PriceTrackerApiService
    {
        static List<Game> games;

        static async Task Init()
        {
            if (games != null)
                return;

            games = new List<Game>();
            List<Game> newGames = new List<Game>()
            {
                new Game() { Id = 1, Name = "Nier", ImageUrl = "https://image.ceneostatic.pl/data/products/49127782/i-nier-automata-gra-ps4.jpg" },
                new Game() { Id = 2, Name = "Sabnautica", ImageUrl = "https://s2.gaming-cdn.com/images/products/1003/orig/game-steam-subnautica-cover.jpg" }
            };

            games.AddRange(newGames);
        }

        public static async Task<IEnumerable<Game>> GetGames()
        {
            await Init();
            return games;
        }

        public static async Task AddGame(Game game)
        {
            await Init();
            games.Add(game);
        }

        public static async Task DeleteGame(Game game)
        {
            await Init();
            games.Remove(game);
        }

        public static async Task Login()
        {

        }

        public static async Task Register()
        {

        }
    }
}
