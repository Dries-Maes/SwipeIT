using SwipeIT.Models;
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
        public Command<Developer> SearchForUsersCommand => new Command<Developer>(SearchForUsers);

        private void SearchForUsers(Developer obj)
        {
            allUsers = new List<User>();
            GetUsers().Wait();
            AllUsersListCollection = new ObservableCollection<User>(allUsers.Where(x =>
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
            allUsersListCollection = new ObservableCollection<User>(allUsers);
        }

        private async Task GetUsers()
        {
            allUsers = new List<User>();
            allUsers.AddRange(await DeveloperRepo.GetAllItemsAsync());
            allUsers.AddRange(await RecruiterRepo.GetAllItemsAsync());
        }
    }
}