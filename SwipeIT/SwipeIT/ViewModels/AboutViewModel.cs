using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command AddDummyDataCommand => new Command(AddDummyData);
        public Command DeleteDbCommand => new Command(DeleteDb);

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}