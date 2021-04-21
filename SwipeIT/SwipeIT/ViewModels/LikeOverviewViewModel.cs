﻿using SwipeIT.Models;
using SwipeIT.Views;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class LikeOverviewViewModel : BaseViewModel
    {
        private bool test;

        public bool Test
        {
            get { return test; }
            set
            {
                test = value;
                OnPropertyChanged(nameof(Test));
            }
        }

        public Command<Developer> DeleteCommand => new Command<Developer>(DeleteDeveloperFromList);
        public Command<Developer> DeveloperTappedCommand => new Command<Developer>(OnDeveloperSelected);

        private void DeleteDeveloperFromList(Developer developer)
        {
            ((Recruiter)CurrentUserSingleton.CurrentUser).SelectedDevelopers.Remove(developer);
        }

        private async void OnDeveloperSelected(Developer developer)
        {
            await Shell.Current.GoToAsync($"{nameof(LikeOverviewDetailPage)}?{nameof(LikeOverviewDetailViewModel.DeveloperID)}={developer.ID}");
        }
    }
}