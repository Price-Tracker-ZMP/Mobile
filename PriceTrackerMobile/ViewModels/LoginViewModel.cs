using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace PriceTrackerMobile.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AsyncCommand LoginCommand { get; }
        public AsyncCommand RegisterCommand { get; }

        public LoginViewModel()
        {
            Title = "Login Page";

            LoginCommand = new AsyncCommand(Login);
            RegisterCommand = new AsyncCommand(Register);
        }

        async Task Login()
        {

        }

        async Task Register()
        {

        }
    }
}
