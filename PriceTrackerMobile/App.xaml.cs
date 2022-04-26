using PriceTrackerMobile.Interfaces;
using PriceTrackerMobile.Services;
using Xamarin.Forms;

namespace PriceTrackerMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IPriceTrackerApiService, PriceTrackerApiService>();
            DependencyService.Register<IHttpService, HttpService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
