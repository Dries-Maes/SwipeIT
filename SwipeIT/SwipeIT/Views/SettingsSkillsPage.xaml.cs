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
    public partial class SettingsSkillsPage : ContentPage

    {
        public SettingsSkillsPage()

        {
            InitializeComponent();
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            SettingsSkillsViewModel settingsSkillsViewModel = new SettingsSkillsViewModel();
            settingsSkillsViewModel.UpdateCurrentUser();
        }
    }
}