using System;
using Elasticsearch.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdministrationPage : ContentPage
    {
        public AdministrationPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender == Users)
            {
                App.Current.MainPage = new UsersAdministrationPage();
            }
            else if (sender == Admin)
            {
                App.Current.MainPage = new AdministratorSettingsPage();
            }
            else if (sender == Skills)
            {
                App.Current.MainPage = new SkillsAdministrationPage();
            }
        }
    }
}