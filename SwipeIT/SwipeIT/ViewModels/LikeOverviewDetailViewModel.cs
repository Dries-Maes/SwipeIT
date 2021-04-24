using SwipeIT.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    [QueryProperty(nameof(DeveloperID), nameof(DeveloperID))]
    public class LikeOverviewDetailViewModel : BaseViewModel
    {
        private User selectedDeveloper;

        public User SelectedDeveloper
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

        public string DeveloperExperience
        {
            get
            {
                return GetDeveloperExperienceString();
            }
            set
            {
                DeveloperExperience = value;
                OnPropertyChanged(nameof(DeveloperExperience));
            }
        }

        public Command SendMailCommand => new Command(SendMail);
        public Command OpenMapCommand => new Command(OpenMapApp);

        public LikeOverviewDetailViewModel()
        {
        }

        private string GetDeveloperExperienceString()
        {
            string experience;
            if (SelectedDeveloper.YearsOfExperience <= 2)
            {
                experience = "Junior";
            }
            else if (SelectedDeveloper.YearsOfExperience <= 5)
            {
                experience = "Medior";
            }
            else
            {
                experience = "Senior";
            }
            return $"({experience} ({SelectedDeveloper.YearsOfExperience}Yrs))";
        }

        private async void LoadSelectedDeveloper(int id)
        {
            switch (Current.User)
            {
                case Developer _:
                    _ = new Developer();
                    Developer result = await DeveloperRepo.GetItemAsync(id);
                    SelectedDeveloper = result;
                    break;

                case Recruiter _:
                    _ = new Recruiter();
                    Recruiter result2 = await RecruiterRepo.GetItemAsync(id);
                    SelectedDeveloper = result2;
                    break;
            }
        }

        private async void SendMail()
        {
            await Launcher.OpenAsync(new Uri($"mailto:{SelectedDeveloper.Email}?subject=SwipeIT found a Like!&body=Hey, {SelectedDeveloper.FirstName}!\nWe at {((Recruiter)Current.User).Company} might have an interesting job offer for you.\nContact us for more information."));
        }

        private async void OpenMapApp()
        {
            if (IsDeveloper)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    string address = ((Developer)selectedDeveloper).Address.Replace(" ", "+");
                    await Launcher.OpenAsync($"geo:0,0?q={address}+BE");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync($"bingmaps:?where={((Developer)SelectedDeveloper).Address}");
                }
            }
        }
    }
}