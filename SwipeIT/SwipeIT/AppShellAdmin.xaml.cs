using SwipeIT.Views;
using System;
using Xamarin.Forms;

namespace SwipeIT
{
    public partial class AppShellAdmin : Xamarin.Forms.Shell
    {
        public AppShellAdmin()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AdministrationPage), typeof(AdministrationPage));
            Routing.RegisterRoute(nameof(UsersAdministrationPage), typeof(UsersAdministrationPage));
            Routing.RegisterRoute(nameof(SkillsAdministrationPage), typeof(SkillsAdministrationPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }
    }
}