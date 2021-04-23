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
        }

        public static CurrentUserSingleton GetSingleton()
        {
            return instance ?? (instance = new CurrentUserSingleton());
        }
    }
}