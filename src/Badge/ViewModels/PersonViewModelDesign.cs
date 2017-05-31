using System.ComponentModel;
using System.Windows.Input;

namespace Badge
{
	public class PersonViewModelDesign : INotifyPropertyChanged
	{
		public PersonViewModelDesign()
		{
			User = InitUser();
			SendBadgeDataButtonIsVisible = true;
			LogoutButtonText = "Logout";
		}
		
		public ICommand LogoutCommand { get; set; }
		public ICommand SendBadgeDataCommand { get; set; }

		string logoutButtonText;
		public string LogoutButtonText
		{
			get { return logoutButtonText; }
			set
			{
				logoutButtonText = value;
				OnPropertyChanged("LogoutButtonText");
			}
		}

		bool visible;
		public bool SendBadgeDataButtonIsVisible
		{
			get { return visible; }
			set
			{
				visible = value;
				OnPropertyChanged("SendBadgeDataButtonIsVisible");
			}
		}
		
		TwitterUser user;
		public TwitterUser User
		{
			get { return user; }
			set
			{
				user = value;
				OnPropertyChanged("User");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
	    {
	        var handler = PropertyChanged;
	        if (handler != null)
	            handler(this, new PropertyChangedEventArgs(propertyName));
	    }

		public void Init()
		{
		}

		static TwitterUser InitUser()
		{
			var user = new TwitterUser(new Newtonsoft.Json.Linq.JObject());
			user.Name = "Chris Riesgo";
			user.Location = "Nashville, TN";
			user.ProfileImageHttpsUrl = "";
			return user;
		}
	}
}