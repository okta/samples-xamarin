using Okta.Xamarin.Demo.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Okta.Xamarin.Demo.ViewModels
{
	public class MobileWidgetViewModel :BaseViewModel
	{
		public MobileWidgetViewModel(MobileWidgetPage mobileWidgetPage)
		{
			Page = mobileWidgetPage;
		}
	}
}
