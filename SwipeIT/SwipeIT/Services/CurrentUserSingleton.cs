using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace SwipeIT.Services
{
    public class CurrentUserSingleton : ObservableObject
    {
        private static CurrentUserSingleton instance;
        private Account currentUser;

        public Account CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private List<Developer> developersResult;

        public List<Developer> DevelopersResult
        {
            get { return developersResult; }
            set
            {
                developersResult = value;
                OnPropertyChanged(nameof(DevelopersResult));
            }
        }

        private CurrentUserSingleton()
        {
        }

        public static CurrentUserSingleton GetSingleton()
        {
            return instance ?? (instance = new CurrentUserSingleton());
        }
    }
}