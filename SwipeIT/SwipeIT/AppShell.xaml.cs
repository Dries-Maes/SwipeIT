using SwipeIT.Views;
using System;
using Xamarin.Forms;

namespace SwipeIT
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LikeOverviewPage), typeof(LikeOverviewPage));
            Routing.RegisterRoute(nameof(LikeOverviewDetailPage), typeof(LikeOverviewDetailPage));
            Routing.RegisterRoute(nameof(SwipePage), typeof(SwipePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}