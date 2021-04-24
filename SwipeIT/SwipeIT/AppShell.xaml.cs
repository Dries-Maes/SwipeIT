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
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}