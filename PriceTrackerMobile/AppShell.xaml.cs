﻿using PriceTrackerMobile.Views;
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
        }
    }
}
