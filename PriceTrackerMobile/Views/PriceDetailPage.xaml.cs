using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;
using PriceTrackerMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PriceTrackerMobile.Views
{
    [QueryProperty(nameof(GameId), nameof(GameId))]
    [QueryProperty(nameof(GameName), nameof(GameName))]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceDetailPage : ContentPage
    {
        public string GameId { get; set; }
        public string GameName { get; set; }

        public PriceDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is PriceDetailViewModel viewModel)
            {
                CrossDeviceOrientation.Current.LockOrientation(DeviceOrientations.Landscape);
                int.TryParse(GameId, out var idResult);
                await viewModel.LoadDetails(idResult, GameName);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossDeviceOrientation.Current.LockOrientation(DeviceOrientations.Portrait);
        }
    }
}