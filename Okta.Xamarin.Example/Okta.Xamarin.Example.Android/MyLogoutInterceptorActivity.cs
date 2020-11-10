using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.PlatformConfiguration;
using Okta.Xamarin.Android;

namespace Okta.Xamarin.Example.Android
{
    [Activity(Label = "MyLogoutInterceptorActivity")]
    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataSchemes = new[] { "com.okta.xamarin.android.logout" },
            DataPath = "/callback"
        )
    ]
    public class MyLogoutInterceptorActivity : LogoutCallbackInterceptorActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}