using SwipeIT.Models;
using System.Collections.Generic;
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
            if (!((Recruiter)Current.User).Developers.Contains(developer))
            {
                ((Recruiter)Current.User).Developers.Add(developer);
                await RecruiterRepo.AddItemAsync((Recruiter)Current.User);
            }
        }
    }
}