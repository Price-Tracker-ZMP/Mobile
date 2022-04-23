using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;
using PriceTrackerMobile.ViewModels;
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

        protected override async void OnAppearing()
        {
            CrossDeviceOrientation.Current.LockOrientation(DeviceOrientations.Portrait);

            if (BindingContext is TrackedItemsViewModel viewModel)
            {
                await viewModel.RefreshPage();
            }
        }
    }
}
