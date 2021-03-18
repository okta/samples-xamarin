# Okta.Xamarin Usage Guide

To run this demo follow the steps in this guide.

## Setup Okta Account and Application

To create an Okta account and application do the following:

1. To create an Okta account see [Developer Signup](https://developer.okta.com/signup/).
2. In your `Okta Developer Console` add an application; follow the directions at [Set up your Application](https://developer.okta.com/docs/guides/implement-auth-code-pkce/setup-app/) and accept the defaults.
3. In your `Okta Developer Console` register your application's login and logout redirect callbacks, see [Register Redirects](#register-redirects).
4. Configure the demo application to use the values registered in the previous step, see [Configure Your Application](#configure-your-application).
5. Run the demo application.

## Register Redirects

To register redirect URIs do the following:

1. Sign in to your `Okta Developer Console` as an administrator.
2. Click the `Applications` tab and select your application.  If you need to set up your application see [Set up your Application](https://developer.okta.com/docs/guides/implement-auth-code-pkce/setup-app/). 
3. Ensure you are on the `General` tab, then go to `General Settings` and click `Edit`.
4. Go to the `Login` section.
5. Below `Login redirect URIs` click the `Add URI` button.
6. Enter the following values:
    ```
    com.okta.xamarin.android.login:/callback
    com.okta.xamarin.ios.login:/callback
    ```
7. Below `Logout redirect URIs` click the `Add URI` button.
8. Enter the following values:
    ```
    com.okta.xamarin.android.logout:/callback
    com.okta.xamarin.ios.logout:/callback
    ```
9. Click `Save`.

## Configure the Demo Application

This section describes how to configure the demo application.  These instructions assume you are using `Visual Studio` and were tested with `Visual Studio Community 2019` Version 16.8.0.

### Android Configuration

To configure the demo Android application do the following:

1. In the `Assets` folder of the `Okta.Xamarin.Demo.Android` project, edit the file called `OktaConfig.xml`.
2. Replace `{ClientId}` and `{yourOktaDomain}` with appropriate values, see [Find your Application's credentials](https://developer.okta.com/docs/guides/find-your-app-credentials/findcreds/).

### iOS Configuration

To configure your iOS application do the following:

1. Right click the `OktaConfig.plist` file and select `View Code`.
2. Replace `{ClientId}` and `{yourOktaDomain}` with appropriate values for your application, see [Find your Application's credentials](https://developer.okta.com/docs/guides/find-your-app-credentials/findcreds/).
