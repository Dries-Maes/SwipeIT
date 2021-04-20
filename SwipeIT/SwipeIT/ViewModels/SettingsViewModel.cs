using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command<Account> SaveCommand => new Command<Account>(Save);

        private void Save(Account obj)
        {
            throw new NotImplementedException(); //Call update method
        }
    }
}