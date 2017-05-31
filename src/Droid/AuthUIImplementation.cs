using System;
using Android.Content;
using Android.Support.CustomTabs;
using Badge.Droid;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency (typeof (AuthUIImplementation))]

namespace Badge.Droid
{
	public class AuthUIImplementation : IAuthUI
	{
		public void Show(OAuth1Authenticator auth)
		{
			var ui = auth.GetUI(Forms.Context);
			var intent = ui as Intent;
			if (intent != null)
			{
				Forms.Context.StartActivity(intent);
			}
		}
	}
}