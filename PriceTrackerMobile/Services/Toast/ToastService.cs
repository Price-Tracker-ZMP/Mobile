using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.CommunityToolkit.UI.Views.Options;
using Xamarin.Forms;

namespace PriceTrackerMobile.Services.Toast
{
    public class ToastService
    {
        protected const double TOAST_DURATION = 1.5f;
        protected const double TOAST_RADIUS = 10f;
        protected readonly ToastOptions options;

        public ToastService()
        {
            options = new ToastOptions()
            {
                Duration = TimeSpan.FromSeconds(TOAST_DURATION),
                CornerRadius = new Thickness(TOAST_RADIUS),
                MessageOptions = new MessageOptions()
                {
                    Foreground = Color.White
                }
            };
        }

        public async Task ShowAsync(string message)
        {
            options.MessageOptions.Message = message;
            await DisplayToast(options);
        }

        public async Task ShowAsync(string[] messages)
        {
            foreach (string message in messages)
            {
                options.MessageOptions.Message = message;
                await DisplayToast(options);
                Thread.Sleep((int)TOAST_DURATION * 1000);
            }
        }

        protected async Task DisplayToast(ToastOptions toastOptions)
        {
            await VisualElementExtension.DisplayToastAsync(Application.Current.MainPage, toastOptions);
        }
    }
}
