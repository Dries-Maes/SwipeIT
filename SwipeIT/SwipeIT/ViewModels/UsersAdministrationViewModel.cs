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
    internal class UsersAdministrationViewModel : BaseViewModel
    {
        private string searchText;
        private List<User> allUsers;

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
            GetSkills().Wait();
        }

        private async Task GetSkills()
        {
            allUsers = new List<User>();
            allUsers.AddRange(await DeveloperRepo.GetAllItemsAsync());
            allUsers.AddRange(await RecruiterRepo.GetAllItemsAsync());
            AllUsersListCollection = new ObservableCollection<User>(allUsers);
        }
    }
}