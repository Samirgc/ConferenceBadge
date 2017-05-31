using System;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace Badge
{
	public class TwitterUser : MvvmHelpers.ObservableObject
	{
		JObject _jObject;
		public TwitterUser(JObject jObject)
		{
			_jObject = jObject;
			
			Name = _jObject["name"].ToStringOrEmpty();
			Location = _jObject["location"].ToStringOrEmpty();
			ProfileImageUrl = _jObject["profile_image_url"].ToStringOrEmpty();
			ProfileImageHttpsUrl = _jObject["profile_image_url_https"].ToStringOrEmpty();
			ProfileBackgroundColor = Color.FromHex(_jObject["profile_background_color"].ToStringOrEmpty());
		}

		string name;
		public string Name
		{ 
			get { return name; }
			set { SetProperty(ref name, value); }
		}

		string location;
		public string Location
		{ 
			get { return location; }
			set { SetProperty(ref location, value); }
		}

		string profileImageUrl;
		public string ProfileImageUrl
		{ 
			get { return profileImageUrl; }
			set { SetProperty(ref profileImageUrl, value); }
		}
		
		string profileImageHttpsUrl;
		public string ProfileImageHttpsUrl
		{ 
			get { return profileImageHttpsUrl; }
			set { SetProperty(ref profileImageHttpsUrl, value); }
		}

		Color profileBackgroundColor;
		public Color ProfileBackgroundColor
		{ 
			get { return profileBackgroundColor; }
			set { SetProperty(ref profileBackgroundColor, value); }
		}
	}
	
	public static class JObjectExtensions
	{
		public static string ToStringOrEmpty(this JToken token)
		{
			return token.ToObject<string>();
		}
	}
}