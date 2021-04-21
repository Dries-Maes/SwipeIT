using SwipeIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel settingsViewModel;

        public SettingsPage()
        {
            settingsViewModel = new SettingsViewModel();
            InitializeComponent();
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            settingsViewModel.UpdateCurrentUser();
        }
    }
}