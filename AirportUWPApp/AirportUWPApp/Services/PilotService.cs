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
	public class PilotService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Pilots";
		private string currentPath = String.Empty;
		public PilotService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Pilot> GetPilotAsync(int id)
		{
			Pilot pilot = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				pilot = await result.Content.ReadAsAsync<Pilot>().ConfigureAwait(false);
			}

			return pilot;
		}

		public async Task<IEnumerable<Pilot>> GetPilotsAsync()
		{
			IEnumerable<Pilot> pilots = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				pilots = await result.Content.ReadAsAsync<IEnumerable<Pilot>>().ConfigureAwait(false);
			}

			return pilots;
		}

		public async Task<HttpStatusCode> CreatePilotAsync(Pilot pilot)
		{
			var result = await httpclient.PostAsJsonAsync(path, pilot).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Pilot> UpdatePilotAsync(Pilot pilot)
		{
			string currentPath = path + "/" + pilot.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, pilot).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			pilot = await result.Content.ReadAsAsync<Pilot>();
			return pilot;
		}

		public async Task<HttpStatusCode> DeletePilotAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
