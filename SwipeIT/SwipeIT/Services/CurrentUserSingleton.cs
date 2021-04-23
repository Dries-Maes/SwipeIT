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

        private CurrentUserSingleton()
        {
            CurrentUser = new Recruiter
            {
                FirstName = "Pieter",
                Email = "Pieter@pietercorp.org",
                Image = "Icon27.png",
                Company = "PCorp",
                Locations = new ObservableCollection<Location> {
                new Location{Province = Province.Henegouwen},
                new Location{Province = Province.Antwerpen},
                new Location{Province = Province.Luik},
                new Location{Province = Province.Namen},
                }
            };
        }

        public static CurrentUserSingleton GetSingleton()
        {
            return instance ?? (instance = new CurrentUserSingleton());
        }
    }
}