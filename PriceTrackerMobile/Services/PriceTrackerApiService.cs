using Newtonsoft.Json;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public static class PriceTrackerApiService
    {
        readonly static string baseUrl = "http://10.0.2.2:5001";
        static HttpClient client;
        static List<Game> games;

        static PriceTrackerApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };

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
            return games;
        }

        public static async Task AddGame(Game game)
        {
            games.Add(game);
        }

        public static async Task DeleteGame(Game game)
        {
            games.Remove(game);
        }

        public static async Task<ApiResponse<string>> Login(LoginRequest request)
        {

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("auth/login", content);
            var stringResponse = await response.Content.ReadAsStringAsync();

            var loginResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(stringResponse);
            return loginResponse;
        }

        public static async Task Register()
        {

        }

        public static async Task<Game> GetGameDetails(int gameId)
        {
            return games.Where(g => g.Id == gameId).FirstOrDefault();
        }
    }
}
