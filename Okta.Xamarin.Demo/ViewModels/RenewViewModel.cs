using Newtonsoft.Json;
using Okta.Xamarin.Demo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Okta.Xamarin.Demo.ViewModels
{
	public class RenewViewModel : BaseViewModel
	{
		readonly Entry refreshTokenEntry;
		readonly Label accessTokenLabel;

		public RenewViewModel(RenewPage renewPage)
		{
			Page = renewPage;
			refreshTokenEntry = Page?.FindByName<Entry>("RefreshTokenEntry");
			accessTokenLabel = Page?.FindByName<Label>("AccessTokenLabel");
			OktaContext.AddRenewStartedListener(OnRenewStarted);
			OktaContext.AddRenewCompletedListener(OnRenewCompleted);
		}

		public Command GoToRevokePageCommand => new Command(async () => await Shell.Current.GoToAsync(nameof(RevokePage)));

		public Command GoToIntrospectPageCommand => new Command(async () => await Shell.Current.GoToAsync(nameof(IntrospectPage)));

		public Command RenewCommand => new Command(async () =>
		{
			if (!string.IsNullOrEmpty(OktaContext.RefreshToken))
			{
				CheckBox refreshIdTokenCheckBox = Page?.FindByName<CheckBox>("RefreshIdTokenCheckBox");
				_ = await OktaContext.Current.RenewAsync(refreshTokenEntry.Text, refreshIdTokenCheckBox.IsChecked);
			}
			else
			{
				await Page.DisplayAlert("offline_access", "Refresh token was not found, be sure to specify the 'offline_access' scope in your configuration.  \r\n\r\nSee, https://github.com/okta/okta-oidc-xamarin#refresh-tokens.", "OK");
			}
		});

		public Command OpenRefreshTokenReference => new Command(async () => await Browser.OpenAsync("https://developer.okta.com/docs/guides/refresh-tokens/refresh-token-rotation/"));

		protected void OnRenewStarted(object sender, RenewEventArgs renewEventArgs)
		{
			refreshTokenEntry.Text = string.Empty;
			accessTokenLabel.Text = string.Empty;
			Page?.DisplayMessage("Renewing tokens...");
			ShowWorkingImage();
		}

		protected void OnRenewCompleted(object sender, RenewEventArgs renewEventArgs)
		{
			RenewResponse renewResponse = renewEventArgs.Response;
			refreshTokenEntry.Text = renewResponse.RefreshToken;
			accessTokenLabel.Text = renewResponse.AccessToken;
			renewResponse = renewEventArgs.Response;
			string renewJson = JsonConvert.SerializeObject(renewResponse);
			Dictionary<string, object> response =JsonConvert.DeserializeObject<Dictionary<string, object>>(renewJson);
			Page?.SetChildData("ResponseDisplay", response);
			IntrospectViewModel.IntrospectResponse = null;
			HideWorkingImage();
		}
	}
}
