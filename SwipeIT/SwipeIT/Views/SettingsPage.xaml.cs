using SwipeIT.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            SettingsViewModel settingsViewModel = new SettingsViewModel();
            settingsViewModel.UpdateCurrentUser();
        }

        private void ShowPassword_OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Password.IsPassword = !ShowPassword.IsChecked;
        }
    }
}