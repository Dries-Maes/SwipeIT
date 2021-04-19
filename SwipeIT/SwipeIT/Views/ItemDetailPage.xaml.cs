using SwipeIT.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SwipeIT.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}