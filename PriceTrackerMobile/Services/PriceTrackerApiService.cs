using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.Services
{
    public class PriceTrackerApiService : IPriceTrackerApiService
    {
        readonly string baseUrl = "https://zmp-price-tracker.herokuapp.com/";
        IHttpService<ApiResponse> httpClient;

        public PriceTrackerApiService()
        {
            httpClient = DependencyService.Get<IHttpService<ApiResponse>>();
            httpClient.Init(baseUrl);
        }

        public async Task<ApiResponse<IEnumerable<Game>>> GetGames()
        {
            var getGamesResponse = await httpClient.GetRequestAsync<ApiResponse<IEnumerable<Game>>>("user-info/user-games");

            return getGamesResponse;
        }

        public async Task<ApiResponse> AddGame(long gameId)
        {
            ApiResponse response = await httpClient.PostRequestAsync<ApiResponse>(new AddGameByIdRequest() { gameId = gameId }, "add-game/by-id");

            return response;
        }

        public async Task<ApiResponse> AddGameByLink(string link)
        {
            ApiResponse response = await httpClient.PostRequestAsync<ApiResponse>(new AddGameByLinkRequest() { link = link }, "add-game/by-link");

            return response;
        }

        public async Task<ApiResponse> DeleteGame(long gameId)
        {
            ApiResponse deleteResponse = await httpClient.DeleteRequestAsync<ApiResponse>($"delete/game/{gameId}");

            return deleteResponse;
        }

        public async Task<ApiResponse<string>> Login(AuthRequest request)
        {
            ApiResponse<string> loginResponse = await httpClient.PostRequestAsync<ApiResponse<string>>(request, "auth/login");

            return loginResponse;
        }

        public async Task<ApiResponse> Register(AuthRequest request)
        {
            ApiResponse registerResponse = await httpClient.PostRequestAsync<ApiResponse>(request, "auth/register");

            return registerResponse;
        }

        public async Task<ApiResponse<PriceHistory>> GetGamePriceHistory(int gameId)
        {
            var priceHistoryResponse = await httpClient.GetRequestAsync<ApiResponse<PriceHistory>>($"get/game-price-history/{gameId}");

            return priceHistoryResponse;
        }

        public async Task<ApiResponse<List<FetchedGame>>> GetSteamGames()
        {
            var getGamesResponse = await httpClient.GetRequestAsync<ApiResponse<List<FetchedGame>>>("get-steam-games-list");

            return getGamesResponse;
        }

        public void ApplayToken()
        {
            httpClient.ApplayToken();
        }
    }
}
