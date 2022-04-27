using PriceTrackerMobile.Interfaces;

namespace PriceTrackerMobile.Response
{
    public class ApiResponse : IApiResponse
    {
        public bool status;
        public string message;
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T content;
    }
}
