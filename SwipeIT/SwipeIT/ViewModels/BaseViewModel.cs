using SwipeIT.Models;
using SwipeIT.Services;
using SwipeIT.Services.TESTDbRepos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SwipeIT.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Current Current { get; set; }

        public IGenericRepo<Developer> DeveloperRepo = new DeveloperRepo();
        public IGenericRepo<Recruiter> RecruiterRepo = new RecruiterRepo();
        public IGenericRepo<Skill> SkillsRepo = new GenericRepo<Skill>();
        public IGenericRepo<Admin> AdminRepo = new GenericRepo<Admin>();
        public IGenericRepo<ObservableObject> GenericRepo = new GenericRepo<ObservableObject>();
        private bool isDeveloper;

        public bool IsDeveloper
        {
            get { return isDeveloper; }
            set
            {
                isDeveloper = value;
                OnPropertyChanged(nameof(IsDeveloper));
            }
        }

        private bool isRecruiter;

        public bool IsRecruiter
        {
            get { return isRecruiter; }
            set
            {
                isRecruiter = value;
                OnPropertyChanged(nameof(IsRecruiter));
            }
        }

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
            Current = Current.GetSingleton();
            SetBools();
        }

        private void SetBools()
        {
            switch (Current.User)
            {
                case Developer _:
                    IsDeveloper = true;
                    break;

                case Recruiter _:
                    IsRecruiter = true;
                    break;
            }
        }

        internal void DeleteDb()
        {
            using (var dbContext = new SwipeITDBContext())
            {
                dbContext.DeleteDb();
            }
        }

        public async void AddDummyData()
        {
            var factory = new MockData();
            await AdminRepo.AddItemsAsync(factory.GetAdminList());
            await DeveloperRepo.AddItemsAsync(factory.GetDeveloperList());
            await RecruiterRepo.AddItemsAsync(factory.GetRecruiterList());
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