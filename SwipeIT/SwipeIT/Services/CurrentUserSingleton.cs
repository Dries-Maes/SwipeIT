using SwipeIT.Models;
using System.Collections.ObjectModel;

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
                AvailableLocations = new ObservableCollection<AvailableLocation> {
                new AvailableLocation{Province = Province.Henegouwen},
                new AvailableLocation{Province = Province.Antwerpen},
                new AvailableLocation{Province = Province.Luik},
                new AvailableLocation{Province = Province.Namen},
                }
            };
        }

        public static CurrentUserSingleton GetSingleton()
        {
            return instance ?? (instance = new CurrentUserSingleton());
        }
    }
}