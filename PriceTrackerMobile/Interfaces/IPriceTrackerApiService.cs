using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Interfaces
{
    public interface IPriceTrackerApiService
    {
        Task<ApiResponse<object>> AddGame(long gameId);
        Task<ApiResponse<object>> AddGameByLink(string link);
        Task<ApiResponse<object>> DeleteGame(long gameId);
        Task<Game> GetGameDetails(int gameId);
        Task<ApiResponse<IEnumerable<Game>>> GetGames();
        Task<ApiResponse<string>> Login(AuthRequest request);
        Task<ApiResponse<string>> Register(AuthRequest request);
        Task<ApiResponse<List<FetchedGame>>> GetSteamGames();
    }
}