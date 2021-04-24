using SwipeIT.Models;
using System.Collections.ObjectModel;

namespace SwipeIT.Services
{
    public class Current : ObservableObject
    {
        private static Current instance;
        private User user;

        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private Current()
        {
        }

        public static Current GetSingleton()
        {
            return instance ?? (instance = new Current());
        }
    }
}