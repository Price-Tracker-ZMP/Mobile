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
            ApiResponse response = await PostRequest<ApiResponse>(new AddGameByIdRequest() { gameId = gameId }, "add-game/by-id");

            return response;
        }

        public async Task<ApiResponse> AddGameByLink(string link)
        {
            ApiResponse response = await PostRequest<ApiResponse>(new AddGameByLinkRequest() { link = link }, "add-game/by-link");

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
            ApiResponse<string> loginResponse = await PostRequest<ApiResponse<string>>(request, "auth/login");

            return loginResponse;
        }

        public async Task<ApiResponse> Register(AuthRequest request)
        {
            ApiResponse registerResponse = await PostRequest<ApiResponse>(request, "auth/register");

            return registerResponse;
        }

        public async Task<Game> GetGamePriceHistory(int gameId)
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

        async Task<T> PostRequest<T>(IRequest request, string path) where T : ApiResponse
        {
            string json = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            string stringResponse = await client.PostAsync(path, content).Result.Content.ReadAsStringAsync();
            T response = (T)new ApiResponse();

            try
            {
                response = JsonConvert.DeserializeObject<T>(stringResponse);
            }
            catch (Exception)
            {
                response = (T)new ApiResponse() { status = false, message = "Api error" };
            }

            return response;
        }
    }
}
