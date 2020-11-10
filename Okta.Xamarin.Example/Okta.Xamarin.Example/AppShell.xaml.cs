using System;
using System.Collections.Generic;
using Okta.Xamarin.Example.ViewModels;
using Okta.Xamarin.Example.Views;
using Xamarin.Forms;

namespace Okta.Xamarin.Example
{
    public partial class AppShell : global::Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            await OktaContext.Current.SignOut().ConfigureAwait(false);
        }
    }
}
