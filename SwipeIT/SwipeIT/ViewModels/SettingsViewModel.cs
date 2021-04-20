using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SettingsViewModel : BaseViewModel

    {
        private bool showImagePicker;

        public bool ShowImagePicker
        {
            get { return showImagePicker; }
            set
            {
                showImagePicker = value;
                OnPropertyChanged(nameof(ShowImagePicker));
            }
        }

        public Command<Account> SaveCommand => new Command<Account>(SaveAsync);
        public Command<string> AvatarSelectedCommand => new Command<string>(AvatarSelected);
        public Command ImageClickedCommand => new Command(ImageClicked);

        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        public User CurrentUser { get; set; }
        public List<string> AvatarList { get; set; }

        public SettingsViewModel()
        {
            AvatarList = new List<string> {
            "Icon1.png",
            "Icon2.png",
            "Icon3.png",
            "Icon4.png",
            };
            CurrentUser = (User)CurrentUserSingleton.CurrentUser;
            if (CurrentUserSingleton.CurrentUser is Developer)
            {
                IsDeveloper = true;
                IsRecruiter = false;
            }
            else if (CurrentUserSingleton.CurrentUser is Recruiter)
            {
                IsDeveloper = false;
                IsRecruiter = true;
            }
        }

        private void ImageClicked()
        {
            ShowImagePicker = true;
        }

        private void AvatarSelected(string imageURL)
        {
            CurrentUser.Image = imageURL;
            ShowImagePicker = false;
        }

        private async void SaveAsync(Account account)
        {
            if (account is Developer)
            {
                await DeveloperRepo.UpdateItemAsync((Developer)account);
            }
            else if (account is Recruiter)
            {
                await RecruiterRepo.UpdateItemAsync((Recruiter)account);
            }
        }
    }
}