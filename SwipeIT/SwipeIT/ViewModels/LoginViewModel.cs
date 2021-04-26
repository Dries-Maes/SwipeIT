using SwipeIT.Models;
using SwipeIT.Services;
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
            var tasks = new List<Task>
            {
            GetAdmins(),
            GetDevelopers(),
            GetRecruiters(),
            AddMockDataIfDbIsEmpty(),
            };
            await Task.WhenAll(tasks);
        }

        private async Task GetRecruiters()
        {
            Accounts.AddRange(await RecruiterRepo.GetAllItemsAsync());
        }

        private async Task GetDevelopers()
        {
            Accounts.AddRange(await DeveloperRepo.GetAllItemsAsync());
        }

        private async Task GetAdmins()
        {
            Accounts.AddRange(await AdminRepo.GetAllItemsAsync());
        }

        private async Task AddMockDataIfDbIsEmpty()
        {
            if (Accounts.Count == 0)
            {
                var mockData = new MockData();
                mockData.AddDummyData();
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
            retVal = CheckIfPasswordsMatch(retVal);
            retVal = CheckForEmptyFields(retVal);
            retVal = CheckIfRoleIsSelected(retVal);
            return retVal;
        }

        private bool CheckIfRoleIsSelected(bool retVal)
        {
            if (IsDeveloper == false && IsRecruiter == false)
            {
                ErrorMessage += "please select your Developer or Recruiter role\n";
                retVal = true;
            }

            return retVal;
        }

        private bool CheckForEmptyFields(bool retVal)
        {
            if (EmptyFields())
            {
                ErrorMessage += "These required fields cannot be empty\n";
                retVal = true;
            }

            return retVal;
        }

        private bool CheckIfPasswordsMatch(bool retVal)
        {
            if (PassWordsMatch()) return retVal;
            ErrorMessage += "Passwords don't match\n";
            return true;
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
            var tasks = new List<Task>
            {
            CreateDeveloperAccount(),
            CreateRecruiterAccount(),
            Login(),
            };
            await Task.WhenAll(tasks);
        }

        private async Task CreateRecruiterAccount()
        {
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

        private async Task CreateDeveloperAccount()
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
        }

        private async void OnLoginClicked(object obj)
        {
            Current.User = null;
            ErrorMessage = "";
            CheckIfRequiredFieldsAreFilledIn();
            if (IsSignUp)
            {
                await SignUp();
            }
            else
            {
                await CheckLoginDetails();
            }

            await Login();
        }

        private void CheckIfRequiredFieldsAreFilledIn()
        {
            if (RequiredFields()) return;
            ErrorMessage = "Email and Password fields cannot be empty\n";
            return;
        }

        private async Task CheckLoginDetails()
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

            if (!VerifyPassword())
            {
                ErrorMessage += "Password Mismatch\n";
                return;
            }
            Current.User = null;
            UserMail = "";
            UserPassword = "";
            List<Admin> adminlist = await AdminRepo.GetAllItemsAsync();
            var admin = adminlist.FirstOrDefault(x => x.Id == account.Id);
            if (admin != null)
            {
                Application.Current.MainPage = new AppShellAdmin();
                return;
            }

            Current.User = (User)Accounts.FirstOrDefault(x => x.Id == account.Id);
        }

        private async Task Login()
        {
            switch (Current.User)
            {
                case Developer _:
                    App.Current.MainPage = new AppShellDeveloper();
                    await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                    break;

                case Recruiter _:
                    App.Current.MainPage = new AppShellRecruiter();
                    await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");
                    break;
            }
        }

        private async Task SignUp()
        {
            if (Accounts.Where(x => x.Email == UserMail).ToList().Count == 0)
            {
                if (ErrorInFormValues()) return;
                await CreateNewUser();
            }
            else
            {
                ErrorMessage += "User already exists\n";
                return;
            }
        }

        private void CheckIfUserExists()
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
        }
    }
}