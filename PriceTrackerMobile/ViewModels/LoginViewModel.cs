using MvvmHelpers.Commands;
using PriceTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            await Shell.Current.GoToAsync($"//{nameof(TrackedItemsPage)}");
        }

        async Task Register()
        {

        }
    }
}
