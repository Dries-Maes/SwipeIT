using SwipeIT.Models;
using SwipeIT.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}