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
    public partial class SettingsLocationsPage : ContentPage
    {
        public SettingsLocationsPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            SettingsLocationsViewModel settingsLocationsViewModel = new SettingsLocationsViewModel();
            settingsLocationsViewModel.UpdateCurrentUser();
        }
    }
}