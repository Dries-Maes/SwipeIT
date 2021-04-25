using SwipeIT.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
            AllUsersListCollection = new ObservableCollection<User>(allUsers);
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
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
            AllUsersListCollection = new ObservableCollection<User>(allUsers.Where(x => x.Email.Contains("rch")).ToList());
        }

        private async Task GetUsers()
        {
            allUsers = new List<User>();
            allUsers.AddRange(await DeveloperRepo.GetAllItemsAsync());
            allUsers.AddRange(await RecruiterRepo.GetAllItemsAsync());
        }
    }
}