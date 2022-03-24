namespace PriceTrackerMobile.Response
{
    public class ApiResponse<T>
    {
        public bool status;
        public string message;
        public T content;
    }
}
