using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SwipeIT.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public Command DeleteDbCommand => new Command(DeleteDb);

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/Dries-Maes/SwipeIT"));
        }

        public ICommand OpenWebCommand { get; }
    }
}