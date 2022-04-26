using PriceTrackerMobile.Response;
using System.Threading.Tasks;

namespace PriceTrackerMobile.Interfaces
{
    public interface IHttpService
    {
        void Init(string baseUrl);
        Task<T> PostRequestAsync<T>(IRequest request, string path) where T : ApiResponse, new();
        Task<T> GetRequestAsync<T>(string path) where T : ApiResponse, new();
        Task<T> DeleteRequestAsync<T>(string path) where T : ApiResponse, new();
        void ApplayToken();
    }
}
