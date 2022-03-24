using MvvmHelpers.Commands;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Services;
using PriceTrackerMobile.Services.Toast;
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
            var response = await PriceTrackerApiService.Login( new AuthRequest(Email, Password));
            if (response.status)
            {
                Settings.Token = response.content;
                await Shell.Current.GoToAsync($"//{nameof(TrackedItemsPage)}");
                await new SuccessToastService().ShowAsync(response.message);
            }
            else
            {
                await new ErrorToastService().ShowAsync(response.message);
            }
        }

        async Task GoToRegisterPage()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
