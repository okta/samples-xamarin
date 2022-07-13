using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Okta.Xamarin.Android;
using X = Android.Content;

namespace Okta.Xamarin.Demo.Droid
{
	[Activity(Label = "MainActivity", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override async void OnCreate(Bundle savedInstanceState)
		{
			//  *** OKTA ***
			// for demo purposes go to the profile page after sign in and sign out
			OktaContext oktaContext = await OktaPlatform.InitAsync(this);
			oktaContext.SignInCompleted += (sender, args) => Shell.Current.GoToAsync("//ProfilePage", true);
			oktaContext.SignOutCompleted += (sender, args) => Shell.Current.GoToAsync("//ProfilePage", true);
			// *** / end OKTA ***

			base.OnCreate(savedInstanceState);

			global::Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

			LoadApplication(new OktaDemoApp());
		}
	}
}
