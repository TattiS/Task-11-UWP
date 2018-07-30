using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AirportUWPApp.Models;
using Newtonsoft.Json;

namespace AirportUWPApp.Services
{
	public class FlightService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Flights";
		private string currentPath = String.Empty;
		public FlightService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Flight> GetFlightAsync(int id)
		{
			Flight flight = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				flight = await result.Content.ReadAsAsync<Flight>().ConfigureAwait(false);
			}

			return flight;
		}

		public async Task<IEnumerable<Flight>> GetFlightsAsync()
		{
			IEnumerable<Flight> flights = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				//flights = await result.Content.ReadAsAsync<IEnumerable<Flight>>().ConfigureAwait(false);
                var objectstr = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
                flights = JsonConvert.DeserializeObject<IEnumerable<Flight>>(objectstr);
            }

			return flights;
		}

		public async Task<HttpStatusCode> CreateFlightAsync(Flight flight)
		{
			var result = await httpclient.PostAsJsonAsync(path, flight).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Flight> UpdateFlightAsync(Flight flight)
		{
			string currentPath = path + "/" + flight.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, flight).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			flight = await result.Content.ReadAsAsync<Flight>();
			return flight;
		}

		public async Task<HttpStatusCode> DeleteFlightAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}

}
