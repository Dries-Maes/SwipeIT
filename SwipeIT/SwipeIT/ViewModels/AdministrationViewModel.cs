using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SwipeIT.Models;
using SwipeIT.Services.Repos;
using SwipeIT.Views;
using System;
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
        private ObservableCollection<DateLog> dateLogs;

        public ObservableCollection<DateLog> DateLogs
        {
            get { return dateLogs; }
            set { dateLogs = value; }
        }

        public ICommand LogoutCommand => new Command(Logout);

        private async void Logout()
        {
            //await Shell.Current.GoToAsync(nameof(LoginPage));
            var page = new NavigationPage(new LoginPage());
            await Application.Current.MainPage.Navigation.PushModalAsync(page, true);
        }

        public AdministrationViewModel()
        {
            SetDateLogs().Wait();
        }

        private async Task SetDateLogs()
        {
            DateLogRepo repo = new DateLogRepo();
            DateLogs = new ObservableCollection<DateLog>(await repo.GetLast10DateLogs());
        }
    }
}