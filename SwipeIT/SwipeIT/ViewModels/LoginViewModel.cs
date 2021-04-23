using SwipeIT.Models;
using SwipeIT.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsSignUp { get; set; }
        public string UserPassword { get; set; }
        public string VerificationPassword { get; set; }
        public string UserMail { get; set; }
        public List<Developer> DevelopersResult;
        public List<Recruiter> RecruiterResult;
        public List<Account> Accounts;
        public Command LoginCommand => new Command(OnLoginClicked);

        public LoginViewModel()
        {
            Accounts = new List<Account>();
            GetMockData();
            CurrentUserSingleton.CurrentUser = null;
            UserMail = "";
            UserPassword = "";
        }

        private async void GetMockData()
        {
            DevelopersResult = await DeveloperRepo.GetAllItemsAsync();
            RecruiterResult = await RecruiterRepo.GetAllItemsAsync();
            Accounts.AddRange(DevelopersResult);
            Accounts.AddRange(RecruiterResult);
        }

        private bool RequiredFields()
        {
            return !(String.IsNullOrEmpty(UserMail) || String.IsNullOrEmpty(UserPassword));
        }

        private bool ErrorInFormValues()
        {
            bool retVal = false;
            if (!PassWordsMatch())
            {
                ErrorMessage += "Passwords don't match\n";
                retVal = true;
            }

            if (EmptyFields())
            {
                ErrorMessage += "These required fields cannot be empty\n";
                retVal = true;
            }

            if (IsDeveloper == false && IsRecruiter == false)
            {
                ErrorMessage += "please select your Developer or Recruiter role\n";
                retVal = true;
            }
            return retVal;
        }

        private bool EmptyFields()
        {
            return String.IsNullOrEmpty(LastName) || String.IsNullOrEmpty(FirstName);
        }

        private bool PassWordsMatch()
        {
            return UserPassword == VerificationPassword;
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
                    Password = UserPassword,
                    FirstName = FirstName,
                    LastName = LastName,
                };
                await RecruiterRepo.AddItemAsync((Recruiter)CurrentUserSingleton.CurrentUser);
            }
            // todo admin (release 3)
        }

        private void SetRoleBools()
        {
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
            else
            {
                IsDeveloper = false;
                IsRecruiter = false;
            }
        }

        private async void OnLoginClicked(object obj)
        {
            SetRoleBools();
            ErrorMessage = "";
            if (UserMail == "Admin" && UserPassword == "Admin")
            {
                CurrentUserSingleton.CurrentUser = new Admin()
                {
                    Email = UserMail,
                    Password = UserPassword
                };
                await Shell.Current.GoToAsync(nameof(AdministrationPage));
            }

            if (IsSignUp)
            {
                if (!RequiredFields())
                {
                    ErrorMessage = "Email and Password fields cannot be empty\n";
                    return;
                }

                if (Accounts.Where(x => x.Email == UserMail).ToList().Count == 0)
                {
                    if (ErrorInFormValues()) return;
                    await CreateNewUser();
                    await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                }
                else
                {
                    ErrorMessage += "User already exists\n";
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
                    ErrorMessage += "User not Found\n";
                    return;
                }

                //user exists, let's continue
                if (!VerifyPassword())
                {
                    ErrorMessage += "Password Mismatch\n";
                    return;
                }
                // password check passes when you got here so we decide were to go from here
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                switch (CurrentUserSingleton.CurrentUser)
                {
                    case Developer developer:
                        await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                        break;

                    case Recruiter recruiter:
                        await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");
                        break;

                    case Admin admin:
                        // do admin stuff
                        throw new NotImplementedException();
                }
            }
        }
    }
}