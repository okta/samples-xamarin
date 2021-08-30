using Okta.Xamarin.Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Okta.Xamarin.Demo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SecureStoragePage : ContentPage
	{
		public SecureStoragePage()
		{
			InitializeComponent();
			BindingContext = new SecureStorageViewModel(this);
		}
	}
}