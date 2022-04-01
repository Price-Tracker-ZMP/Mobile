using PriceTrackerMobile.Helpers;
using PriceTrackerMobile.Views;
using Xamarin.Forms;

namespace PriceTrackerMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
            Routing.RegisterRoute(nameof(TrackedItemsPage), typeof(TrackedItemsPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(PriceDetailPage), typeof(PriceDetailPage));
        }

        async void Logout_Clicked(object sender, System.EventArgs e)
        {
            Settings.Token = "";
            Settings.AutoLogIn = false;
            await Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
