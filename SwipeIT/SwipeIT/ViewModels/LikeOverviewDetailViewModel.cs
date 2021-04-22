using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace SwipeIT.ViewModels
{
    [QueryProperty(nameof(DeveloperID), nameof(DeveloperID))]
    public class LikeOverviewDetailViewModel : BaseViewModel
    {
        private Developer selectedDeveloper;

        public Developer SelectedDeveloper
        {
            get => selectedDeveloper;
            set
            {
                selectedDeveloper = value;
                OnPropertyChanged(nameof(SelectedDeveloper));
            }
        }

        private int developerID;

        public int DeveloperID
        {
            get => developerID;
            set
            {
                developerID = value;
                LoadSelectedDeveloper(value);
            }
        }

        public Command SendMailCommand => new Command(SendMail);

        public LikeOverviewDetailViewModel()
        {
            SelectedDeveloper = new Developer();
        }

        private async void LoadSelectedDeveloper(int id)
        {
            try
            {
                var dev = await DeveloperRepo.GetItemAsync(id);
                SelectedDeveloper = dev;
            }
            catch (Exception)
            {
                //Debug
            }
        }

        private void SendMail()
        {
            Launcher.OpenAsync(new Uri($"mailto:{SelectedDeveloper.Email}?subject=SwipeIT found a Like!&body=Hey, {SelectedDeveloper.FirstName}!\nWe at {((Recruiter)CurrentUserSingleton.CurrentUser).Company} might have an interesting job offer for you.\nContact us for more information."));
        }
    }
}