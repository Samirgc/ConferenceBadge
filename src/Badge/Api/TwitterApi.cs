﻿using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;

namespace Badge
{
	public class TwitterApi
	{
		IAuthAccountStore _accountStore;
		public TwitterApi()
		{		
			_accountStore = DependencyService.Get<IAuthAccountStore>();
		}
		
		public async Task<TwitterUser> GetUser()
		{
			var account = await _accountStore.GetFirst();

			var request = new OAuth1Request("GET", 
				new Uri(Constants.TwitterGetUserUrl), 
				//new Dictionary<string, string>() 
				//{ 
				//	{"include_entities", "true"}, 
				//	{"include_email", "false"}
				//}, 
				null,
				account);
				
			var response = await request.GetResponseAsync().ConfigureAwait(false);
			var json = response.GetResponseText();
			var jObject = JObject.Parse(json);

			return new TwitterUser(jObject);
		}
	}
}