
using PriceTrackerMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceTrackerMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrackedItemsPage : ContentPage
    {

        public TrackedItemsPage()
        {
            InitializeComponent();
        }

        private async void StopTracking(object sender, System.EventArgs e)
        {
            Game item = ((MenuItem)sender).BindingContext as Game;
            if (item == null)
                return;

            await DisplayAlert("Item deleted from track list", item.Name, "Ok");
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
