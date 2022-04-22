using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Interfaces
{
    public interface IPriceTrackerApiService
    {
        Task<ApiResponse> AddGame(long gameId);
        Task<ApiResponse> AddGameByLink(string link);
        Task<ApiResponse> DeleteGame(long gameId);
        Task<ApiResponse<PriceHistory>> GetGamePriceHistory(int gameId);
        Task<ApiResponse<IEnumerable<Game>>> GetGames();
        Task<ApiResponse<string>> Login(AuthRequest request);
        Task<ApiResponse> Register(AuthRequest request);
        Task<ApiResponse<List<FetchedGame>>> GetSteamGames();
    }
}