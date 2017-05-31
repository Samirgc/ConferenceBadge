using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Badge
{
	public class AdafruitApi
	{
		public AdafruitApi()
		{
			Client = new HttpClient();
			Client.DefaultRequestHeaders.Add("X-AIO-Key", Constants.Secrets.AIOApiKey);
			Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
		}
		
		public HttpClient Client { get; set; }
		
		public async Task SendData(string data)
		{
			try
			{
				var payload = new Dictionary<string, string> { { "value", data } };
				var serializedPayload = JsonConvert.SerializeObject(payload);
				var request = new HttpRequestMessage()
				{
					Method = HttpMethod.Post,
					RequestUri = new Uri($"https://io.adafruit.com/api/v2/{Constants.Secrets.AIOUsername}/feeds/{Constants.Secrets.AIOFeedKey}/data"),
					Content = new StringContent(serializedPayload, Encoding.UTF8, "application/json")
				};				

				Debug.WriteLine($"HttpClient [RequestUri={request.RequestUri}, Content={serializedPayload}]");
				var response = await Client.PostAsync(request.RequestUri, request.Content);
				if(response.IsSuccessStatusCode)
				{
					Debug.WriteLine("API success!");
				}
				else
				{
					throw new ApplicationException($"API request was unsuccessful: [{response.StatusCode.ToString()}]");
				}
			}
			catch(Exception ex)
			{
				Debug.WriteLine($"Something went wrong: {ex}");
			}
		}
	}
}