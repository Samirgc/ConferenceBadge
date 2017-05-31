using System.Threading.Tasks;
using Badge.Droid;
using Xamarin.Auth;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

[assembly: Dependency(typeof(AuthAccountStoreImplementation))]

namespace Badge.Droid
{
	public class AuthAccountStoreImplementation : IAuthAccountStore
	{
		const string TWITTER_KEY = "Twitter";
		
		public Task Store(Account account)
		{
			return AccountStore.Create(Forms.Context).SaveAsync(account, TWITTER_KEY);
		}
		
		public Task<List<Account>> GetAll()
		{
			return AccountStore.Create(Forms.Context).FindAccountsForServiceAsync(TWITTER_KEY);
		}
		
		public async Task<Account> GetFirst()
		{
			var accounts = await AccountStore.Create(Forms.Context).FindAccountsForServiceAsync(TWITTER_KEY);
			return accounts.FirstOrDefault();
		}
		
		public bool HasAccount()
		{
			var accounts = AccountStore.Create(Forms.Context).FindAccountsForService(TWITTER_KEY);
			return accounts != null && accounts.Any();
		}
		
		public async Task Delete()
		{
			var accounts = await GetAll();

			foreach (var account in accounts)
			{
				await AccountStore.Create(Forms.Context).DeleteAsync(account, TWITTER_KEY);
			}
		}
	}
}