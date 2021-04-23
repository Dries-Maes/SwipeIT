﻿using SwipeIT.Models;
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

            CurrentUserSingleton.CurrentUser = null;
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
                    CurrentUserSingleton.CurrentUser = Accounts.First(x => x.Email == UserMail);
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
                switch (CurrentUserSingleton.CurrentUser)
                {
                    case Developer developer:
                        IsDeveloper = true;
                        await Shell.Current.GoToAsync($"//{nameof(SettingsPage)}");
                        break;

                    case Recruiter recruiter:
                        IsRecruiter = true;
                        await Shell.Current.GoToAsync($"//{nameof(SwipePage)}");
                        break;

                    case Admin admin:

                        await Shell.Current.GoToAsync(nameof(AdministrationPage));
                        break;
                }
            }
        }
    }
}