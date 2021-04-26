using SwipeIT.Models;
using SwipeIT.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    internal class UsersAdministrationViewModel : BaseViewModel
    {
        private string searchText;

        private List<User> allUsers;

        public List<User> AllUsers
        {
            get => allUsers;
            set
            {
                allUsers = value;
                OnPropertyChanged(nameof(AllUsers));
            }
        }

        public Command<Developer> SearchForUsersCommand => new Command<Developer>(SearchForUsers);
        public Command<User> NavigateToSettingsCommand => new Command<User>(NavigateToSettings);

        private ObservableCollection<User> allUsersListCollection;

        public ObservableCollection<User> AllUsersListCollection
        {
            get { return allUsersListCollection; }
            set
            {
                allUsersListCollection = value;
                OnPropertyChanged(nameof(AllUsersListCollection));
            }
        }

        public UsersAdministrationViewModel()
        {
            GetUsers().Wait();
            allUsersListCollection = new ObservableCollection<User>(AllUsers);
        }

        public async void NavigateToSettings(User user)
        {
            Current.User = user;
            await Shell.Current.GoToAsync($"{nameof(SettingsPage)}");
        }

        private async Task GetUsers()
        {
            AllUsers = new List<User>();
            AllUsers.AddRange(await DeveloperRepo.GetAllItemsAsync());
            AllUsers.AddRange(await RecruiterRepo.GetAllItemsAsync());
        }

        private void SearchForUsers(Developer obj)
        {
            AllUsers = new List<User>();
            GetUsers().Wait();
            AllUsersListCollection = new ObservableCollection<User>(AllUsers.Where(x =>
                    x.Email.ToLower().Contains(searchText.ToLower()) || x.FirstName.ToLower().Contains(searchText.ToLower())
                                                                     || x.LastName.ToLower().Contains(searchText.ToLower())).ToList());
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = string.IsNullOrWhiteSpace(value) ? string.Empty : value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
    }
}