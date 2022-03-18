using Xamarin.Forms;

namespace PriceTrackerMobile.Services.Toast
{
    public class ErrorToastService : ToastService
    {

        public ErrorToastService()
        {
            options.MessageOptions.Foreground = Color.Red;
        }
    }
}
