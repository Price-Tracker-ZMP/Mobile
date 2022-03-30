using PriceTrackerMobile.Interfaces;

namespace PriceTrackerMobile.Requests
{
    public class AuthRequest : IRequest
    {
        public string email;
        public string password;

        public AuthRequest(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
