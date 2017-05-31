using System.Dynamic;

namespace Badge
{
	public partial class Constants
	{
		public static dynamic Secrets = new ExpandoObject();
		
		static Constants()
		{
			Secrets.ExampleApiKey = "abcd12-34567-890-zyxwv";
		}
	}
}