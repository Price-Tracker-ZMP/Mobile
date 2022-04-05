using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public interface IPriceTrackerApiService
    {
        Task AddGame(FetchedGame game);
        Task<FetchedGame> GetGameDetails(int gameId);
        Task<IEnumerable<FetchedGame>> GetGames();
        Task<ApiResponse<string>> Login(AuthRequest request);
        Task<ApiResponse<string>> Register(AuthRequest request);
    }
}