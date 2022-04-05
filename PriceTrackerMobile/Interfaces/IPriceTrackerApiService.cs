using PriceTrackerMobile.Models;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Services
{
    public interface IPriceTrackerApiService
    {
        Task AddGame(Game game);
        Task<Game> GetGameDetails(int gameId);
        Task<IEnumerable<Game>> GetGames();
        Task<ApiResponse<string>> Login(AuthRequest request);
        Task<ApiResponse<string>> Register(AuthRequest request);
    }
}