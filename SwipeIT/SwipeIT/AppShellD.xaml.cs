using SwipeIT.Views;
using System;
using Xamarin.Forms;

namespace SwipeIT
{
    public partial class AppShellD : Xamarin.Forms.Shell
    {
        public AppShellD()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(AdministrationPage), typeof(AdministrationPage));
            Routing.RegisterRoute(nameof(UsersAdministrationPage), typeof(UsersAdministrationPage));
            Routing.RegisterRoute(nameof(SkillsAdministrationPage), typeof(SkillsAdministrationPage));
            Routing.RegisterRoute(nameof(AdministratorSettingsPage), typeof(AdministratorSettingsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}