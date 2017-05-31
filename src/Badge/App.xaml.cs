using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Badge
{	
	public partial class App : Application
	{	
		public static NavigationPage NavPage { get; set; }
		
		public App()
		{
			InitializeComponent();			
			SetMainPage();
		}
		
		public static void SetMainPage()
		{
			var accountStore = DependencyService.Get<IAuthAccountStore>();
			
			if (!accountStore.HasAccount())
			{
				Current.MainPage = new LoginPage();
			}
			else
			{ 
				NavPage = new NavigationPage(new PersonPage());
				Current.MainPage = NavPage;
			}
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}