using System.Threading.Tasks;

namespace PriceTrackerMobile.Interfaces
{
    public interface IHttpService<T> where T : IApiResponse, new()
    {
        void Init(string baseUrl);
        void ApplayToken();
        Task<T2> PostRequestAsync<T2>(IRequest request, string path) where T2 : T, new();
        Task<T2> GetRequestAsync<T2>(string path) where T2 : T, new();
        Task<T2> DeleteRequestAsync<T2>(string path) where T2 : T, new();
    }
}
