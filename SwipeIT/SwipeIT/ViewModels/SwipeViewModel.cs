using SwipeIT.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class SwipeViewModel : BaseViewModel

    {
        private List<User> developersResult;

        public List<User> DevelopersResult
        {
            get { return developersResult; }
            set
            {
                developersResult = value;
                OnPropertyChanged(nameof(DevelopersResult));
            }
        }

        public Command<User> LikeCommand => new Command<User>(Like);
        public Command RefreshCommand => new Command(GetUserData);

        public SwipeViewModel()
        {
            DevelopersResult = new List<User>();
            GetUserData();
        }

        private async void GetUserData()
        {
            if (IsDeveloper)
            {
                var results = await RecruiterRepo.GetAllItemsAsync();
                developersResult.AddRange(results);
            }
            else if (IsRecruiter)
            {
                var results = await DeveloperRepo.GetAllItemsAsync();
                developersResult.AddRange(results);
            }
        }

        private async void Like(User UserClicked)
        {
            if (IsDeveloper)
            {
                if (((Developer)Current.User).Recruiters.FirstOrDefault(x => x.Id == UserClicked.Id) == null)
                {
                    ((Developer)Current.User).Recruiters.Add((Recruiter)UserClicked);
                    await DeveloperRepo.AddItemAsync((Developer)Current.User);
                }
            }
            else if (IsRecruiter)
            {
                if (((Recruiter)Current.User).Developers.FirstOrDefault(x => x.Id == UserClicked.Id) == null)
                {
                    ((Recruiter)Current.User).Developers.Add((Developer)UserClicked);
                    await RecruiterRepo.AddItemAsync((Recruiter)Current.User);
                }
            }
        }
    }
}