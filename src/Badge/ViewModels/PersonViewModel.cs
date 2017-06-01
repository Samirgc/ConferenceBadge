using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Badge
{
	public class PersonViewModel : BaseViewModel
	{
		IAuthAccountStore _accountStore;
		TwitterApi _twitterApi;
		AdafruitApi _adafruitApi;
		
		public PersonViewModel()
		{
			_accountStore = DependencyService.Get<IAuthAccountStore>();
			_twitterApi = new TwitterApi();
			_adafruitApi = new AdafruitApi();
			
			LogoutCommand = new Command(Logout);
			SendBadgeDataCommand = new Command(SendBadgeData);
		}

		public string LogoutButtonText => "Logout";
		public ICommand LogoutCommand { get; set; }
		public ICommand SendBadgeDataCommand { get; set; }
		
		bool sendBadgeDataButtonIsVisible;
		public bool SendBadgeDataButtonIsVisible
		{
			get { return sendBadgeDataButtonIsVisible; }
			set { SetProperty(ref sendBadgeDataButtonIsVisible, value); }
		}
		
		TwitterUser user;
		public TwitterUser User 
		{ 
			get { return user; }
			set { SetProperty(ref user, value); }
		}
		
		public void Init()
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				Task.Run(async () =>
				{
					User = await _twitterApi.GetUser();
					SendBadgeDataButtonIsVisible = true;
					MessagingCenter.Send(this, Constants.PersonViewModelInitializedMessage);
				});
			});						
		}
		
		void Logout()
		{			
			Task.Run(async() =>
			{
				Debug.WriteLine("Logout command issued");
				await _accountStore.Delete();
				MessagingCenter.Send(this, Constants.SetMainPageMessage);
			});			
		}
		
		void SendBadgeData()
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				var badgeData = new { name = User.Name, location = User.Location };
				var data = JsonConvert.SerializeObject(badgeData);
				Debug.WriteLine($"Sending to data feed: {data}");		
				Task.Run(async () => await _adafruitApi.SendData(data));
			});			
		}
	}
}