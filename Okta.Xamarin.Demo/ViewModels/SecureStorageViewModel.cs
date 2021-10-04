using Newtonsoft.Json;
using Okta.Xamarin.Demo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Okta.Xamarin.Demo.ViewModels
{
	public class SecureStorageViewModel : BaseViewModel
	{
		public SecureStorageViewModel(SecureStoragePage demoPage)
		{
			Page = demoPage;

			OktaContext.AddSecureStorageReadStartedListener(OnSecureStorageReadStarted);
			OktaContext.AddSecureStorageReadCompletedListener(OnSecureStorageReadCompleted);
			OktaContext.AddSecureStorageReadExceptionListener(OnSecureStorageReadException);
			OktaContext.AddSecureStorageWriteStartedListener(OnSecureStorageWriteStarted);
			OktaContext.AddSecureStorageWriteCompletedListener(OnSecureStorageWriteCompleted);
			OktaContext.AddSecureStorageWriteExceptionListener(OnSecureStorageWriteException);
			OktaContext.AddLoadStateCompletedListener(OnLoadStateCompleted);
		}

		protected void OnLoadStateCompleted(object sender, SecureStorageEventArgs eventArgs)
		{
			SetStateDisplay(eventArgs.OktaStateManager);
		}

		protected void OnSecureStorageReadStarted(object sender, SecureStorageEventArgs eventArgs)
		{
			ShowWorkingImage();
		}

		protected void OnSecureStorageReadCompleted(object sender, SecureStorageEventArgs eventArgs)
		{
			HideWorkingImage();
		}

		protected void OnSecureStorageReadException(object sender, SecureStorageExceptionEventArgs eventArgs)
		{
			HideWorkingImage();
			Page.DisplayAlert("Secure Storage", $"Exception occurred reading from secure storage: {eventArgs.Exception?.Message}", "OK");
		}

		protected void OnSecureStorageWriteStarted(object sender, SecureStorageEventArgs eventArgs)
		{
			ShowWorkingImage();
		}

		protected void OnSecureStorageWriteCompleted(object sender, SecureStorageEventArgs eventArgs)
		{
			HideWorkingImage();
		}

		protected void OnSecureStorageWriteException(object sender, SecureStorageExceptionEventArgs eventArgs)
		{
			HideWorkingImage();
			Page.DisplayAlert("Secure Storage", $"Exception occurred writing to secure storage: {eventArgs.Exception?.Message}", "OK");
		}

		public Command LoadStateCommand => new Command(async () => await OktaContext.LoadStateAsync());

		public Command SaveStateCommand => new Command(async () =>
		{
			await OktaContext.SaveStateAsync();
			await Page.DisplayAlert("Secure Storage", "State saved to secure storage", "OK");
		});

		public Command ClearStateCommand => new Command(async () =>
		{
			await OktaContext.ClearStateAsync();
			await Page.DisplayAlert("Secure Storage", "State cleared from secure storage", "OK");
		});

		public Command KillAppCommand => new Command(() => System.Diagnostics.Process.GetCurrentProcess().Kill());

		private void SetStateDisplay(IOktaStateManager stateManager = null)
		{
			stateManager = stateManager ?? OktaContext.Current.StateManager;
			string json = stateManager.ToJson();
			Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
			Page.DisplayData(dictionary, "ResponseDisplay");
		}
	}
}
