using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
        }

        private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
        }
    }
}