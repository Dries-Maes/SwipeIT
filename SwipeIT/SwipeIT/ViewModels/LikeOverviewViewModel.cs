using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Command TestCommand => new Command(Testmethod);

        private void DeleteDeveloperFromList(Developer developer)
        {
            ((Recruiter)CurrentUserSingleton.CurrentUser).SelectedDevelopers.Remove(developer);
        }

        private void Testmethod()
        {
            Test = true;
        }
    }
}