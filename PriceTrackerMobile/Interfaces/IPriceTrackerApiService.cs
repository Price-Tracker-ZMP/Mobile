using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public interface IPriceTrackerApiService
    {
        Task AddGame(long gameId);
        Task<Game> GetGameDetails(int gameId);
        Task<ApiResponse<IEnumerable<Game>>> GetGames();
        Task<ApiResponse<string>> Login(AuthRequest request);
        Task<ApiResponse<string>> Register(AuthRequest request);
        Task<ApiResponse<List<FetchedGame>>> GetSteamGames();
    }
}