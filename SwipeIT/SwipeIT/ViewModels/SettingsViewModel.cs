using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Account CurrentUser { get; set; }
        public Command<Account> SaveCommand => new Command<Account>(SaveAsync);

        public SettingsViewModel()
        {
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