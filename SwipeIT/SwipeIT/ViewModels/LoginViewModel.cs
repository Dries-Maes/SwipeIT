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
            Accounts = new List<Account>();
            GetAccounts().Wait();

            Current.User = null;
            UserMail = "";
            UserPassword = "";
        }

        private async Task GetAccounts()
        {
            Accounts = await AdminRepo.GetAllAcountsAsync();
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
            return UserPassword == Current.User.Password;
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
                try // todo find user
                {
                    var account = Accounts.First(x => x.Email == UserMail);
                    if (account != null && account.Email != "admin")
                    {
                        List<User> list = new List<User>();
                        list.AddRange(await DeveloperRepo.GetAllItemsAsync());
                        list.AddRange(await RecruiterRepo.GetAllItemsAsync());
                        User user = list.FirstOrDefault(x => x.Id == account.Id);
                        if (user is Developer)
                        {
                            Current.User = user;
                        }
                        else if (user is Recruiter)
                        {
                            Current.User = user;
                        }
                    }
                    else if (account.Email == "admin")
                    {
                        // Admin moet niet een current user hebben (todo)
                        Current.User = (User)account;
                    }
                }
                catch (Exception)
                {
                    ErrorMessage += "User not Found\n";
                    return;
                }

                //todo user exists, let's continue
                if (!VerifyPassword())
                {
                    ErrorMessage += "Password Mismatch\n";
                    return;
                }
                // todo password check passes when you got here so we decide were to go from here

                // todo Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                IsRecruiter = false;
                IsDeveloper = false;
                switch (Current.User)
                {
                    case Developer developer:
                        IsDeveloper = true;
                        await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                        break;

                    case Recruiter recruiter:
                        IsRecruiter = true;
                        await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");
                        break;

                    default:
                        await Shell.Current.GoToAsync(nameof(AdministrationPage));
                        break;
                }
            }
        }
    }
}