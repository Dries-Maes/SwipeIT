using SwipeIT.ViewModels;
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
    public partial class SwipePage : ContentPage
    {
        public SwipePage()
        {
            InitializeComponent();
        }

        private void OnFavoriteSwipeItemInvoked(object sender, EventArgs e)
        {
        }

        private void OnDeleteSwipeItemInvoked(object sender, EventArgs e)
        {
        }

        private void LoadData(object sender, EventArgs e)
        {
            SwipeViewModel viewModel = new SwipeViewModel();
            viewModel.GetMockData();
        }
    }
}