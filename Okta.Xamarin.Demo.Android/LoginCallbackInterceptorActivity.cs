using Android.App;
using Android.Content;
using Android.Content.PM;
using Okta.Xamarin.Android;

namespace Okta.Xamarin.Demo.Droid
{
    [Activity(Label = "LogincCallbackInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleInstance)]
    [
        IntentFilter
        (
            actions: new[] { Intent.ActionView },
            Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
            DataSchemes = new[] { "com.okta.xamarin.android.login" },
            DataPath = "/callback"
        )
    ]
    public class LoginCallbackInterceptorActivity : OktaLoginCallbackInterceptorActivity<MainActivity>
    {
    }
}