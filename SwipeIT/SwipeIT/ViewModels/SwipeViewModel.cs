using Nest;
using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SwipeViewModel : BaseViewModel
    {
        public Command<Developer> LikeCommand => new Command<Developer>(Like);
        public Command LoadDevelopers => new Command(GetMockData);

        public SwipeViewModel()
        {
            GetMockData();
        }

        public async void GetMockData()
        {
            CurrentUserSingleton.DevelopersResult = await DeveloperRepo.GetAllItemsAsync();
        }

        private async void Like(Developer developer)
        {
            if (!((Recruiter)CurrentUserSingleton.CurrentUser).SelectedDevelopers.Contains(developer))
            {
                Models.Like like = new Models.Like
                {
                    Developer = developer,
                    DeveloperID = developer.ID,
                    Recruiter = (Recruiter)CurrentUserSingleton.CurrentUser,
                    RecruiterID = ((Recruiter)CurrentUserSingleton.CurrentUser).ID,
                };
                ((Recruiter)CurrentUserSingleton.CurrentUser).SelectedDevelopers.Add(developer);
                ((Recruiter)CurrentUserSingleton.CurrentUser).Likes.Add(like);
                await RecruiterRepo.AddItemAsync((Recruiter)CurrentUserSingleton.CurrentUser);
            }
        }
    }
}