using MvvmHelpers.Commands;
using PriceTrackerMobile.Requests;
using PriceTrackerMobile.Services;
using PriceTrackerMobile.Services.Toast;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConirmPassword { get; set; }

        public AsyncCommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            Title = "Register Page";

            RegisterCommand = new AsyncCommand(Register);
        }

        async Task Register()
        {
            if (Password == ConirmPassword)
            {
                var response = await PriceTrackerApiService.Register(new AuthRequest(Email, Password));

                if (response.status)
                {
                    await Shell.Current.GoToAsync("..");
                    await new SuccessToastService().ShowAsync(response.message);
                }
                else
                    await new ErrorToastService().ShowAsync(response.message);
            }
            else
                await new ErrorToastService().ShowAsync("Passwords not equal");
        }
    }
}
