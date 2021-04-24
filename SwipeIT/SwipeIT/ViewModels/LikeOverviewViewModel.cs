using SwipeIT.Models;
using SwipeIT.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class LikeOverviewViewModel : BaseViewModel
    {
        private ObservableCollection<User> connectionList;

        public ObservableCollection<User> ConnectionList
        {
            get { return connectionList; }
            set
            {
                connectionList = value;
                OnPropertyChanged(nameof(ConnectionList));
            }
        }

        public Command<User> DeleteCommand => new Command<User>(DeleteDeveloperFromList);
        public Command<User> DeveloperTappedCommand => new Command<User>(OnDeveloperSelected);

        public LikeOverviewViewModel()
        {
            ConnectionList = new ObservableCollection<User>();
            InitiateResultList().Wait();
        }

        public async Task InitiateResultList()
        {
            if (IsDeveloper)
            {
                var result = await DeveloperRepo.GetItemAsync(Current.User.Id);
                foreach (var item in result.Recruiters)
                {
                    ConnectionList.Add(item);
                }
            }
            else if (IsRecruiter)
            {
                var result = await RecruiterRepo.GetItemAsync(Current.User.Id);
                foreach (var item in result.Developers)
                {
                    ConnectionList.Add(item);
                }
            }
        }

        private void DeleteDeveloperFromList(User DeletedUser)
        {
            if (IsDeveloper)
            {
                ((Developer)Current.User).Recruiters.Remove((Recruiter)DeletedUser);
                connectionList.Remove(DeletedUser);
                DeveloperRepo.AddItemAsync((Developer)Current.User);
            }
            else if (IsRecruiter)
            {
                ((Recruiter)Current.User).Developers.Remove((Developer)DeletedUser);
                connectionList.Remove(DeletedUser);
                RecruiterRepo.AddItemAsync((Recruiter)Current.User);
            }
        }

        private async void OnDeveloperSelected(User DeletedUser)
        {
            await Shell.Current.GoToAsync($"{nameof(LikeOverviewDetailPage)}?{nameof(LikeOverviewDetailViewModel.DeveloperID)}={DeletedUser.Id}");
        }
    }
}