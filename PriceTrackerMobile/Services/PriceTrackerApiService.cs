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
            string stringResponse = await client.GetAsync("user-info/user-games").Result.Content.ReadAsStringAsync();
            ApiResponse<IEnumerable<Game>> finalResponse = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<Game>>>(stringResponse);

            return finalResponse;
        }

        public async Task<ApiResponse> AddGame(long gameId)
        {
            string stringResponse = await PostRequest(new AddGameByIdRequest() { gameId = gameId }, "add-game/by-id");
            ApiResponse<object> response = JsonConvert.DeserializeObject<ApiResponse<object>>(stringResponse);

            return response;
        }

        public async Task<ApiResponse> AddGameByLink(string link)
        {
            string stringResponse = await PostRequest(new AddGameByLinkRequest() { link = link }, "add-game/by-link");
            ApiResponse<object> response = JsonConvert.DeserializeObject<ApiResponse<object>>(stringResponse);

            return response;
        }

        public async Task<ApiResponse> DeleteGame(long gameId)
        {
            string stringResponse = await client.DeleteAsync($"delete/game/{gameId}").Result.Content.ReadAsStringAsync();
            ApiResponse response = JsonConvert.DeserializeObject<ApiResponse>(stringResponse);

            return response;
        }

        public async Task<ApiResponse<string>> Login(AuthRequest request)
        {
            string stringResponse = await PostRequest(request, "auth/login");
            ApiResponse<string> loginResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(stringResponse);

            return loginResponse;
        }

        public async Task<ApiResponse> Register(AuthRequest request)
        {
            string stringResponse = await PostRequest(request, "auth/register");
            ApiResponse registerResponse = JsonConvert.DeserializeObject<ApiResponse>(stringResponse);

            return registerResponse;
        }

        public async Task<Game> GetGameDetails(int gameId)
        {
            return new Game() { Name = "Test" };
        }

        public async Task<ApiResponse<List<FetchedGame>>> GetSteamGames()
        {
            HttpResponseMessage response = await client.GetAsync($"{baseUrl}get-steam-games-list").ConfigureAwait(false);
            string rresponseString = await response.Content.ReadAsStringAsync();
            ApiResponse<List<FetchedGame>> convertedJson = JsonConvert.DeserializeObject<ApiResponse<List<FetchedGame>>>(rresponseString);

            return convertedJson;
        }

        async Task<string> PostRequest(IRequest request, string path)
        {
            string json = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            string response = await client.PostAsync(path, content).Result.Content.ReadAsStringAsync();

            return response;
        }
    }
}
