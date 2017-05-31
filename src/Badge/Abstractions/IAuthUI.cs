using Xamarin.Auth;

namespace Badge
{
	public interface IAuthUI
	{
		void Show(OAuth1Authenticator auth);
	}
}