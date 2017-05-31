namespace Badge
{
	public partial class Constants
	{		
		// URLs
		public static string TwitterGetUserUrl = "https://api.twitter.com/1.1/account/verify_credentials.json";
		public static string TwitterRequestTokenUrl = "https://api.twitter.com/oauth/request_token";
		public static string TwitterAuthorizeUrl = "https://api.twitter.com/oauth/authorize";
		public static string TwitterAccessTokenUrl = "https://api.twitter.com/oauth/access_token";
		public static string TwitterCallbackUrl = "http://mobile.twitter.com/home";

		// Messaging Keys
		public static string ShowAuthUIMessage = "ShowAuthUIMessage";
		public static string SetMainPageMessage = "SetMainPageMessage";
		public static string PersonViewModelInitializedMessage = "PersonViewModelInitializedMessage";
	}
}