using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Okta.Xamarin.Android;

namespace Okta.Xamarin.Demo.Droid
{
	[Activity(Label = "OktaCallbackActivity", NoHistory = true, LaunchMode = LaunchMode.SingleInstance)]
	[
		IntentFilter
		(
			actions: new[] { Intent.ActionView },		
			Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
			DataSchemes = new[] { "com.okta.xamarin.android.login", "com.okta.xamarin.android.logout" },
			DataPath = "/callback"
		)
	]
	public class OktaCallbackActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			OktaPlatform.HandleCallback(this, typeof(MainActivity));
		}
	}
}