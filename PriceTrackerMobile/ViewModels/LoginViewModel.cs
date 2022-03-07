using MvvmHelpers.Commands;
using PriceTrackerMobile.Services;
using PriceTrackerMobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public AsyncCommand LoginCommand { get; }
        public AsyncCommand RegisterCommand { get; }

        public LoginViewModel()
        {
            Title = "Login Page";

            LoginCommand = new AsyncCommand(Login);
            RegisterCommand = new AsyncCommand(GoToRegisterPage);
        }

        async Task Login()
        {
            await PriceTrackerApiService.Login();
            await Shell.Current.GoToAsync($"//{nameof(TrackedItemsPage)}");
        }

        async Task GoToRegisterPage()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
