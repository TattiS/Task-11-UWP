using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AirportUWPApp.Models;

namespace AirportUWPApp.Services
{
	public class StewardessService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Stewardesses";
		private string currentPath = String.Empty;
		public StewardessService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Stewardess> GetStewardessAsync(int id)
		{
			Stewardess stewardess = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				stewardess = await result.Content.ReadAsAsync<Stewardess>().ConfigureAwait(false);
			}

			return stewardess;
		}

		public async Task<IEnumerable<Stewardess>> GetStewardessesAsync()
		{
			IEnumerable<Stewardess> stewardesses = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				stewardesses = await result.Content.ReadAsAsync<IEnumerable<Stewardess>>().ConfigureAwait(false);
			}

			return stewardesses;
		}

		public async Task<HttpStatusCode> CreateStewardessAsync(Stewardess stewardess)
		{
			var result = await httpclient.PostAsJsonAsync(path, stewardess).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Stewardess> UpdateStewardessAsync(Stewardess stewardess)
		{
			string currentPath = path + "/" + stewardess.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, stewardess).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			stewardess = await result.Content.ReadAsAsync<Stewardess>().ConfigureAwait(false);
			return stewardess;
		}

		public async Task<HttpStatusCode> DeleteStewardessAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
