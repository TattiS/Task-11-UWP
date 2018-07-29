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
	public class DepartureService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Departures";
		private string currentPath = String.Empty;
		public DepartureService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Departure> GetDepartureAsync(int id)
		{
			Departure departure = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				departure = await result.Content.ReadAsAsync<Departure>().ConfigureAwait(false);
			}

			return departure;
		}

		public async Task<IEnumerable<Departure>> GetDeparturesAsync()
		{
			IEnumerable<Departure> departures = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				departures = await result.Content.ReadAsAsync<IEnumerable<Departure>>().ConfigureAwait(false);
			}

			return departures;
		}

		public async Task<HttpStatusCode> CreateDepartureAsync(Departure departure)
		{
			var result = await httpclient.PostAsJsonAsync(path, departure).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Departure> UpdateDepartureAsync(Departure departure)
		{
			string currentPath = path + "/" + departure.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, departure).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			departure = await result.Content.ReadAsAsync<Departure>();
			return departure;
		}

		public async Task<HttpStatusCode> DeleteDepartureAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
