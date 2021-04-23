using SwipeIT.Models;
using SwipeIT.Services;
using SwipeIT.Services.TESTDbRepos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public CurrentUserSingleton CurrentUserSingleton { get; set; }
        public DeveloperDbRepo DeveloperRepo = new DeveloperDbRepo();
        public RecruiterDbRepo RecruiterRepo = new RecruiterDbRepo();
        public SkillDbRepo SkillsRepo = new SkillDbRepo();
        public AdminDbRepo AdminRepo = new AdminDbRepo();
        public bool IsDeveloper { get; set; }
        public bool IsRecruiter { get; set; }

        private bool isBusy = false;

        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        private string title = string.Empty;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public BaseViewModel()
        {
            CurrentUserSingleton = CurrentUserSingleton.GetSingleton();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}