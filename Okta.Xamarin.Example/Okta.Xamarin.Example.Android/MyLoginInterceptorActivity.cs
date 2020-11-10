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
using Okta.Xamarin.Android;

namespace Okta.Xamarin.Example.Droid
{
    [Activity(Label = "MyLoginInterceptorActivity")]
    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataSchemes = new[] { "com.okta.xamarin.android.login" },
            DataPath = "/callback"
        )
    ]
    public class MyLoginInterceptorActivity : LoginCallbackInterceptorActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}