using MvvmHelpers.Commands;
using PriceTrackerMobile.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PriceTrackerMobile.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        public AsyncCommand RegisterCommand { get; }

        public RegisterViewModel()
        {
            Title = "Register Page";

            RegisterCommand = new AsyncCommand(Register);
        }

        async Task Register()
        {
            await PriceTrackerApiService.Register();
            await Shell.Current.GoToAsync("..");
        }
    }
}
