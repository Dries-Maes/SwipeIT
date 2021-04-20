using SwipeIT.Models;
using SwipeIT.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SwipeIT.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsRecruiter { get; set; }
        public bool IsDeveloper { get; set; }
        private string errorMessage;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsSignUp { get; set; }
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
            if (IsSignUp)
            {
                if (Accounts.Where(x => x.Email == UserMail).ToList().Count == 0)
                {
                    CreateNewUser();
                    await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                }
                else
                {
                    ErrorMessage = "User already exists";
                    return;
                }
            }
            else
            {
                try // find user
                {
                    CurrentUserSingleton.CurrentUser = Accounts.First(x => x.Email == UserMail);
                }
                catch (Exception)
                {
                    ErrorMessage = "User not Found";
                    return;
                }

                //user exists, let's continue
                if (!VerifyPassword())
                {
                    ErrorMessage = "Password Mismatch";
                    return;
                }

                switch (CurrentUserSingleton.CurrentUser)
                {
                    case Developer developer:
                        await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                        break;

                    case Recruiter recruiter:
                        await Shell.Current.GoToAsync($"//{nameof(LikeOverviewPage)}");
                        break;

                    case Admin admin:
                        // do admin stuff
                        throw new NotImplementedException();
                }
            }

            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
        }

        private bool VerifyPassword()
        {
            return UserPassword == CurrentUserSingleton.CurrentUser.Password;
        }

        private async Task CreateNewUser()
        {
            if (IsDeveloper)
            {
                Developer temp = new Developer
                {
                    Email = UserMail,
                    Password = UserPassword,
                    FirstName = FirstName,
                    LastName = LastName,
                };
                CurrentUserSingleton.CurrentUser = temp;
                await DeveloperRepo.AddItemAsync((Developer)CurrentUserSingleton.CurrentUser);
            }

            if (IsRecruiter)
            {
                CurrentUserSingleton.CurrentUser = new Recruiter
                {
                    Email = UserMail,
                    Password = UserPassword
                };
                await RecruiterRepo.AddItemAsync((Recruiter)CurrentUserSingleton.CurrentUser);
            }
            // todo admin (release 3)
        }
    }
}