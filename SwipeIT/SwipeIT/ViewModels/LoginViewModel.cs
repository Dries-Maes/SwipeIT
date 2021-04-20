using SwipeIT.Models;
using SwipeIT.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Linq;

namespace SwipeIT.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsRecruiter { get; set; }
        public bool IsDeveloper { get; set; }
        public string UserPassword { get; set; }
        public string UserMail { get; set; }
        public List<Developer> DevelopersResult;
        public List<Recruiter> RecruiterResult;
        public List<Account> Accounts = new List<Account>();

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            GetMockData();

            LoginCommand = new Command(OnLoginClicked);
        }

        private void GetMockData()
        {
            DevelopersResult = DeveloperRepo.GetDevelopers();
            RecruiterResult = RecruiterRepo.GetRecruiters();
            Accounts.AddRange(DevelopersResult);
            Accounts.AddRange(RecruiterResult);
        }

        private async void OnLoginClicked(object obj)
        {
            try
            {
                CurrentUserSingleton.CurrentUser = Accounts.First(x => x.Email == UserMail);
            }
            catch (Exception)
            {
                throw; // User not found
            }
            //user exists, let's continue
            if (CurrentUserSingleton.CurrentUser is Developer developer)
            {
                await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
            }
            else if (CurrentUserSingleton.CurrentUser is Recruiter recruiter)
            {
                await Shell.Current.GoToAsync($"//{nameof(LikeOverviewPage)}");
            }
            else if (CurrentUserSingleton.CurrentUser is Admin admin)
            {
                // do admin stuff
                throw new NotImplementedException();
            }

            //       if (CurrentUserSingleton.CurrentUser.Password!=UserPassword) {}
            //              // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        }
    }
}