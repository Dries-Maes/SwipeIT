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
        private List<Developer> developersResult;

        public List<Developer> DevelopersResult
        {
            get { return developersResult; }
            set
            {
                developersResult = value;
                OnPropertyChanged(nameof(DevelopersResult));
            }
        }

        public Command<Developer> LikeCommand => new Command<Developer>(Like);
        public Command RefreshCommand => new Command(GetUserData);

        public SwipeViewModel()
        {
            DevelopersResult = new List<Developer>();
            GetUserData();
        }

        private async void GetUserData()
        {
            DevelopersResult = await DeveloperRepo.GetAllItemsAsync();
        }

        private async void Like(Developer developer)
        {
            if (!((Recruiter)CurrentUserSingleton.CurrentUser).Developers.Contains(developer))
            {
                ((Recruiter)CurrentUserSingleton.CurrentUser).Developers.Add(developer);
                await RecruiterRepo.AddItemAsync((Recruiter)CurrentUserSingleton.CurrentUser);
            }
        }
    }
}