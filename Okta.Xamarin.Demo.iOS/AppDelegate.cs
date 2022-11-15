using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Okta.Xamarin.iOS;
using UIKit;
using Xamarin.Forms;

namespace Okta.Xamarin.Demo.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		//
		// This method is invoked when the application has loaded and is ready to run. In this 
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
			global::Xamarin.Forms.Forms.Init();
			LoadApplication(new OktaDemoApp());

			bool result = base.FinishedLaunching(app, options);

			//  *** OKTA ***
			// for demo purposes go to the profile page after sign in and sign out
			OktaContext oktaContext = OktaPlatform.InitAsync(Window).Result;
			oktaContext.SignInCompleted += (sender, args) => Shell.Current.GoToAsync("//ProfilePage");
			oktaContext.SignOutCompleted += (sender, args) => Shell.Current.GoToAsync("//ProfilePage");
			// *** / end OKTA ***


			// Additional logic to execute can go here if necessary

			return result;
		}

		public override bool OpenUrl
		(
			UIApplication application,
			NSUrl url,
			string sourceApplication,
			NSObject annotation
		)
		{
			return OktaPlatform.IsOktaCallback(application, url, sourceApplication, annotation);
		}
	}
}
