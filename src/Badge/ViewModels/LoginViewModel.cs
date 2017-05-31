using System;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Auth;
using Xamarin.Forms;

namespace Badge
{
	public class LoginViewModel : BaseViewModel
	{
		readonly IAuthAccountStore _accountStore;

		public LoginViewModel()
		{
			_accountStore = DependencyService.Get<IAuthAccountStore>();
			
			TwitterAuthCommand = new Command((obj) => AuthenticateWithTwitter());
		}		
		
		public ICommand TwitterAuthCommand { get; private set; }
		
		void AuthenticateWithTwitter()
		{
			var auth = new OAuth1Authenticator(
				Constants.Secrets.ConsumerKey,
				Constants.Secrets.ConsumerSecret,
				new Uri(Constants.TwitterRequestTokenUrl),
				new Uri(Constants.TwitterAuthorizeUrl),
				new Uri(Constants.TwitterAccessTokenUrl),
				new Uri(Constants.TwitterCallbackUrl),
				null,
				false
			)
			{
				AllowCancel = true
			};
			auth.Completed += AuthCompleted;

			MessagingCenter.Send(this, Constants.ShowAuthUIMessage, auth);
		}
		
		async void AuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
		{
			var loggedInUser = e.Account;
			await _accountStore.Store(loggedInUser);
			
			MessagingCenter.Send(this, Constants.SetMainPageMessage);
		}
	}
}