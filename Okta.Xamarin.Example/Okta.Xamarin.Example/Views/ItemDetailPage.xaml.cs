using System.ComponentModel;
using Xamarin.Forms;
using Okta.Xamarin.Example.ViewModels;

namespace Okta.Xamarin.Example.Views
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