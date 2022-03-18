using Xamarin.Forms;

namespace PriceTrackerMobile.Services.Toast
{
    public class SuccessToastService : ToastService
    {

        public SuccessToastService()
        {
            options.MessageOptions.Foreground = Color.Green;
        }
    }
}
