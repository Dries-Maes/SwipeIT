using SwipeIT.Models;
using SwipeIT.Services;
using SwipeIT.Views;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SwipeIT.Services;

namespace SwipeIT.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string errorMessage;
        private Account account;

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
        public List<Admin> AdminsResult;
        public List<Account> Accounts;
        public Command LoginCommand => new Command(OnLoginClicked);

        public LoginViewModel()
        {
            GetAccounts().Wait();
        }

        private async Task GetAccounts()
        {
            Accounts = new List<Account>();
            Accounts.AddRange(await AdminRepo.GetAllItemsAsync());
            Accounts.AddRange(await DeveloperRepo.GetAllItemsAsync());
            Accounts.AddRange(await RecruiterRepo.GetAllItemsAsync());
            await AddMockDataIfDbIsEmpty();
        }

        private async Task AddMockDataIfDbIsEmpty()
        {
            if (Accounts.Count == 0)
            {
                AddDummyData();
                await GetAccounts();
            }
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
            return UserPassword == account.Password;
        }

        private async Task CreateNewUser()
        {
            if (IsDeveloper)
            {
                Current.User = new Developer
                {
                    Email = UserMail,
                    Password = UserPassword,
                    FirstName = FirstName,
                    LastName = LastName,
                };
                await DeveloperRepo.AddItemAsync((Developer)Current.User);
            }

            if (IsRecruiter)
            {
                Current.User = new Recruiter
                {
                    Email = UserMail,
                    Password = UserPassword,
                    FirstName = FirstName,
                    LastName = LastName,
                };
                await RecruiterRepo.AddItemAsync((Recruiter)Current.User);
            }
        }

        private async void OnLoginClicked(object obj)
        {
            ErrorMessage = "";

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
                try
                {
                    account = Accounts.First(x => x.Email == UserMail);
                }
                catch (Exception)
                {
                    ErrorMessage += "User not Found\n";
                    return;
                }

                //todo user exists, let's continue, find check pass and if passes set that user
                if (!VerifyPassword())
                {
                    ErrorMessage += "Password Mismatch\n";
                    return;
                }
                // todo password check passes when you got here so we decide were to go from here
                Current.User = null;
                UserMail = "";
                UserPassword = "";
                List<Admin> adminlist = await AdminRepo.GetAllItemsAsync();
                var admin = adminlist.FirstOrDefault(x => x.Id == account.Id);
                if (admin != null)
                {
                    App.Current.MainPage = new AdministrationPage();
                }

                if (!(Accounts.FirstOrDefault(x => x.Id == account.Id) is Admin))
                {
                    Current.User = (User)Accounts.FirstOrDefault(x => x.Id == account.Id);
                }

                //todo an admin is not a user so a user let's find out
                //  Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

                switch (Current.User)
                {
                    case Developer _:
                        App.Current.MainPage = new AppShell();
                        await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                        break;

                    case Recruiter _:
                        App.Current.MainPage = new AppShellR();
                        await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");
                        break;
                }
            }
        }
    }
}