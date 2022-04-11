using Newtonsoft.Json;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public class PriceTrackerApiService : IPriceTrackerApiService
    {
        readonly string baseUrl = "https://zmp-price-tracker.herokuapp.com/";
        static HttpClient client;

        public PriceTrackerApiService()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
            client.DefaultRequestHeaders.Add("authentication", Settings.Token);
        }

        public async Task<ApiResponse<IEnumerable<Game>>> GetGames()
        {
            var stringResponse = await client.GetAsync("user-info/user-games").Result.Content.ReadAsStringAsync();
            var finalResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Game>>>(stringResponse);

            return finalResponse;
        }

        public async Task AddGame(long gameId)
        {
            var json = JsonConvert.SerializeObject(gameId);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await client.PostAsync("add-game/by-id", content).Result.Content.ReadAsStringAsync();
        }

        public static async Task DeleteGame(Game game)
        {
            
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

        public async Task<Game> GetGameDetails(int gameId)
        {
            return new Game() { Name = "Test" };
        }

        public async Task<ApiResponse<List<FetchedGame>>> GetSteamGames()
        {
            HttpResponseMessage response = await client.GetAsync($"{baseUrl}get-steam-games-list").ConfigureAwait(false);
            string rString = await response.Content.ReadAsStringAsync();
            ApiResponse<List<FetchedGame>> convertedJson = JsonConvert.DeserializeObject<ApiResponse<List<FetchedGame>>>(rString);

            return convertedJson;
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
