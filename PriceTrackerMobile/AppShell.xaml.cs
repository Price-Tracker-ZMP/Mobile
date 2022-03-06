using PriceTrackerMobile.Views;
using Xamarin.Forms;

namespace PriceTrackerMobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddItemPage), typeof(AddItemPage));
        }
    }
}
