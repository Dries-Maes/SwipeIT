using SwipeIT.ViewModels;
using SwipeIT.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SwipeIT
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LikeOverviewPage), typeof(LikeOverviewPage));
            Routing.RegisterRoute(nameof(LikeOverviewDetailPage), typeof(LikeOverviewDetailPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}