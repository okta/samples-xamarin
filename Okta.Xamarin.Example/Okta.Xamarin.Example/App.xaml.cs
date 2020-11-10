using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Okta.Xamarin.Example.Services;
using Okta.Xamarin.Example.Views;

namespace Okta.Xamarin.Example
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
