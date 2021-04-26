using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SwipeIT.Models;
using SwipeIT.Views;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class AdministrationViewModel : BaseViewModel
    {
        public List<Account> UserDateLogs { get; set; }

        public ICommand LogoutCommand => new Command(Logout);

        private async void Logout()
        {
            var page = new NavigationPage(new LoginPage());
            await Application.Current.MainPage.Navigation.PushModalAsync(page, true);
        }

        public AdministrationViewModel()
        {
            SetUsers().Wait();
        }

        private async Task<List<Account>> GetUsers()
        {
            var userList = new List<Account>();
            userList.AddRange(await AdminRepo.GetAllItemsAsync());
            userList.AddRange(await DeveloperRepo.GetAllItemsAsync());
            userList.AddRange(await RecruiterRepo.GetAllItemsAsync());
            return userList;
        }

        private async Task SetUsers()
        {
            List<Account> temp = await GetUsers();
            UserDateLogs = temp.OrderByDescending(x => x.DateLog.DateModified).Take(25).ToList();
        }
    }
}