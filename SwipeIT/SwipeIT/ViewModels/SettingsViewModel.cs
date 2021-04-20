using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command<Account> SaveCommand => new Command<Account>(SaveAsync);
        public Command<string> AvatarSelectedCommand => new Command<string>(AvatarSelected);
        public Command<string> ImageClickedCommand => new Command<string>(ImageClicked);

        public bool ShowImagePicker { get; set; }
        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        public User CurrentUser { get; set; }
        public List<string> AvatarList { get; set; }

        public SettingsViewModel()
        {
            AvatarList = new List<string> {
            "icon01.png",
            "icon02.png",
            "icon03.png",
            "icon04.png",
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

        private void ImageClicked(string obj)
        {
            ShowImagePicker = true;
        }

        private void AvatarSelected(string obj)
        {
            CurrentUser.Image = obj;
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