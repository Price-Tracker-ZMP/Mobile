using Newtonsoft.Json;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public class PriceTrackerApiService : IPriceTrackerApiService
    {
        readonly string baseUrl = "https://zmp-price-tracker.herokuapp.com/";
        static HttpClient client;
        static List<FetchedGame> games;

        public PriceTrackerApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };

            games = new List<FetchedGame>();
            List<FetchedGame> newGames = new List<FetchedGame>()
            {
                new FetchedGame() { Id = 1, Name = "Nier", ImageUrl = "https://image.ceneostatic.pl/data/products/49127782/i-nier-automata-gra-ps4.jpg" },
                new FetchedGame() { Id = 2, Name = "Sabnautica", ImageUrl = "https://s2.gaming-cdn.com/images/products/1003/orig/game-steam-subnautica-cover.jpg" }
            };

            games.AddRange(newGames);
        }

        public async Task<IEnumerable<FetchedGame>> GetGames()
        {
            return games;
        }

        public async Task AddGame(FetchedGame game)
        {
            games.Add(game);
        }

        public static async Task DeleteGame(FetchedGame game)
        {
            games.Remove(game);
        }

        public async Task<ApiResponse<string>> Login(AuthRequest request)
        {
            var stringResponse = await PostRequest(request, "auth/login");
            var loginResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(stringResponse);

            return loginResponse;
        }

        public async Task<ApiResponse<string>> Register(AuthRequest request)
        {
            var stringResponse = await PostRequest(request, "auth/register");
            var registerResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(stringResponse);

            return registerResponse;
        }

        public async Task<FetchedGame> GetGameDetails(int gameId)
        {
            return games.Where(g => g.Id == gameId).FirstOrDefault();
        }

        async Task<string> PostRequest(IRequest request, string path)
        {
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(path, content).Result.Content.ReadAsStringAsync();

            return response;
        }
    }
}
