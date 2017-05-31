using Xamarin.Forms;

namespace Badge
{
	public partial class PersonPage : ContentPage
	{		
		public PersonPage()
		{
			InitializeComponent();
			BindingContext = new PersonViewModel();
			
			LogoutToolbarItem = new ToolbarItem()
			{
				Text = ViewModel.LogoutButtonText,
				Command = ViewModel.LogoutCommand
			};
		}

		PersonViewModel ViewModel => BindingContext as PersonViewModel;
		ToolbarItem LogoutToolbarItem { get; set; }

		protected override void OnAppearing()
		{
			base.OnAppearing();

			MessagingCenter.Subscribe<PersonViewModel>(this, Constants.PersonViewModelInitializedMessage, ViewModelInitialized);
			MessagingCenter.Subscribe<PersonViewModel>(this, Constants.SetMainPageMessage, SetMainPage);
			ViewModel.Init();			
		}
		
		protected override void OnDisappearing()
		{
			MessagingCenter.Unsubscribe<PersonViewModel>(this, Constants.SetMainPageMessage);
			MessagingCenter.Unsubscribe<PersonViewModel>(this, Constants.PersonViewModelInitializedMessage);
			base.OnDisappearing();
		}
		
		void ViewModelInitialized(PersonViewModel sender)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				App.NavPage.BarBackgroundColor = ViewModel.User.ProfileBackgroundColor;
				ToolbarItems.Add(LogoutToolbarItem);
			});
		}
		
		void SetMainPage(PersonViewModel sender)
		{
			App.SetMainPage();
		}
	}
}