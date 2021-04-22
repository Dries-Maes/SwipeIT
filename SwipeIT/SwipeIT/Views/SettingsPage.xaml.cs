using SwipeIT.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var pickedResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choose Your Profile Picture"
            });

            if (pickedResult != null)
            {
                var stream = await pickedResult.OpenReadAsync();
                PickedImage.Source = ImageSource.FromStream(() => stream);
            }
        }
    }
}