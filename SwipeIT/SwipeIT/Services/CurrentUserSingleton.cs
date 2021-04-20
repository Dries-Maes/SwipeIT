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
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private CurrentUserSingleton()
        {
            CurrentUser = new Recruiter
            {
                FirstName = "Pieter",
                LastName = "Pallieter",
                Email = "Pieter@pietercorp.org",
                Image = "Icon27.png",
                Company = "PCorp",
                Locations = new ObservableCollection<Location> {
                Location.Henegouwen,
                Location.Antwerpen,
                Location.Luik,
                Location.Namen
                }
            };
        }

        public static CurrentUserSingleton GetSingleton()
        {
            if (instance == null)
            {
                instance = new CurrentUserSingleton();
            }
            return instance;
        }
    }
}