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
        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        public SettingsViewModel()
        {
            if (CurrentUserSingleton.CurrentUser is Developer)
            {
                IsDeveloper = true;
                IsRecruiter = false;
            }
            else if (CurrentUserSingleton.CurrentUser is Developer)
            {
                IsDeveloper = false;
                IsRecruiter = true;
            }
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