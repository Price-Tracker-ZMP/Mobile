namespace PriceTrackerMobile.Response
{
    public class ApiResponse
    {
        public bool status;
        public string message;
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T content;
    }
}
