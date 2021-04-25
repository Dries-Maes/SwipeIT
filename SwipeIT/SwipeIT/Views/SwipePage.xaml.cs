using System;

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
    }
}