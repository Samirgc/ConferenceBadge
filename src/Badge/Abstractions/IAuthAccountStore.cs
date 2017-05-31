using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Auth;

namespace Badge
{
	public interface IAuthAccountStore
	{
		Task Store(Account account);
		Task<List<Account>> GetAll();
		Task<Account> GetFirst();
		bool HasAccount();
		Task Delete();
	}
}