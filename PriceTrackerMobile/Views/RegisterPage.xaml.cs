using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceTrackerMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            CrossDeviceOrientation.Current.LockOrientation(DeviceOrientations.Portrait);
            Email.Text = "";
            Password.Text = "";
            ConfirmPassword.Text = "";
        }
    }
}