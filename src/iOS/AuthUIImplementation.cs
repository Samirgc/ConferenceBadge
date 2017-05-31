using System;
using Badge.iOS;
using Xamarin.Auth;

[assembly: Xamarin.Forms.Dependency (typeof (AuthUIImplementation))]

namespace Badge.iOS
{
	public class AuthUIImplementation : IAuthUI
	{
		public void Show(OAuth1Authenticator auth)
		{
			throw new NotImplementedException();
		}
	}
}