using PriceTrackerMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PriceTrackerMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}