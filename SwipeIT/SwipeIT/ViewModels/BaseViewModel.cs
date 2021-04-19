using SwipeIT.Models;
using SwipeIT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
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

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public DeveloperRepo developerRepo = DeveloperRepo.GetSingleton();
        public RecruiterRepo recruiterRepo = RecruiterRepo.GetSingleton();
        public SkillsRepo skillsRepo = SkillsRepo.GetSingleton();

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
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
            CurrentUser = new Recruiter //TODO LOGIN SCHERM MOCK RECRUITER
            {
                Name = "Pieter",
                Email = "Pieter2"
            };
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