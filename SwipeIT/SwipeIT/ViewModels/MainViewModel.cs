using Nest;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public List<Developer> DevelopersResult { get; set; }

        public Command<Developer> LikeCommand => new Command<Developer>(Like);

        public MainViewModel()
        {
            DevelopersResult = new List<Developer>();
            GetMockData();
        }

        private void GetMockData()
        {
            DevelopersResult = DeveloperRepo.GetDevelopers();
        }

        private void Like(Developer developer)
        {
            ((Recruiter)CurrentUserSingleton.CurrentUser).SelectedDevelopers.Add(developer);
        }
    }
}