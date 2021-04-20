using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class LikeOverviewViewModel : BaseViewModel
    {
        public Command<Developer> DeleteCommand => new Command<Developer>(DeleteDeveloperFromList);

        private void DeleteDeveloperFromList(Developer developer)
        {
            ((Recruiter)CurrentUserSingleton.CurrentUser).SelectedDevelopers.Remove(developer);
        }
    }
}