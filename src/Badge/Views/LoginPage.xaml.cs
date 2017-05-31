using Xamarin.Forms;
using Xamarin.Auth;

namespace Badge
{
	public partial class LoginPage : ContentPage
	{
		readonly IAuthUI _authUI;
		
		public LoginPage()
		{
			InitializeComponent();

			BindingContext = new LoginViewModel();
			
			_authUI = DependencyService.Get<IAuthUI>();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Subscribe<LoginViewModel, OAuth1Authenticator>(this, Constants.ShowAuthUIMessage, ShowUI);
			MessagingCenter.Subscribe<LoginViewModel>(this, Constants.SetMainPageMessage, SetMainPage);
		}
		
		protected override void OnDisappearing()
		{			
			MessagingCenter.Unsubscribe<LoginViewModel>(this, Constants.SetMainPageMessage);
			MessagingCenter.Unsubscribe<LoginViewModel>(this, Constants.ShowAuthUIMessage);
			base.OnDisappearing();
		}
		
		void ShowUI(LoginViewModel sender, OAuth1Authenticator auth)
		{
			_authUI.Show(auth);
		}
		
		void SetMainPage(LoginViewModel sender)
		{
			App.SetMainPage();
		}
	}
}