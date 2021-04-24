using SwipeIT.Views;
using System;
using Xamarin.Forms;

namespace SwipeIT
{
    public partial class AppShellDeveloper : Xamarin.Forms.Shell
    {
        public AppShellDeveloper()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LikeOverviewPage), typeof(LikeOverviewPage));
            Routing.RegisterRoute(nameof(LikeOverviewDetailPage), typeof(LikeOverviewDetailPage));
            Routing.RegisterRoute(nameof(SwipePage), typeof(SwipePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}