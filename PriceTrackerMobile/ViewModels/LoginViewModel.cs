using MvvmHelpers.Commands;
using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Requests;
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
        public bool AutoLogIn { get; set; }

        public AsyncCommand LoginCommand { get; }
        public AsyncCommand RegisterCommand { get; }

        IPriceTrackerApiService apiService;

        public LoginViewModel()
        {
            Title = "Login Page";
            AutoLogIn = Settings.AutoLogIn;
            apiService = DependencyService.Get<IPriceTrackerApiService>();

            LoginCommand = new AsyncCommand(Login);
            RegisterCommand = new AsyncCommand(GoToRegisterPage);

            _ = AutoLogin();
        }

        async Task Login()
        {
            Response.ApiResponse<string> response = await apiService.Login( new AuthRequest(Email, Password));

            if (response.status)
            {
                Settings.AutoLogIn = AutoLogIn;
                Settings.Token = response.content;
                apiService.ApplayToken();
                await Shell.Current.GoToAsync($"//{nameof(TrackedItemsPage)}");
                await new SuccessToastService().ShowAsync(response.message);
            }
            else
                await new ErrorToastService().ShowAsync(response.message);
        }

        async Task AutoLogin()
        {
            if (AutoLogIn && Settings.Token != "")
            {
                apiService.ApplayToken();
                await Shell.Current.GoToAsync($"//{nameof(TrackedItemsPage)}");
                await new SuccessToastService().ShowAsync("Auto logged!");
            }
        }

        async Task GoToRegisterPage()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
