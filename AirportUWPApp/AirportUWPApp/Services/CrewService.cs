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
	public class CrewService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Crews";
		private string currentPath = String.Empty;
		public CrewService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Crew> GetCrewAsync(int id)
		{
			Crew crew = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				crew = await result.Content.ReadAsAsync<Crew>().ConfigureAwait(false);
			}

			return crew;
		}

		public async Task<IEnumerable<Crew>> GetCrewsAsync()
		{
			IEnumerable<Crew> crews = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				crews = await result.Content.ReadAsAsync<IEnumerable<Crew>>().ConfigureAwait(false);
			}

			return crews;
		}

		public async Task<HttpStatusCode> CreateCrewAsync(Crew crew)
		{
			var result = await httpclient.PostAsJsonAsync(path, crew).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Crew> UpdateCrewAsync(Crew crew)
		{
			string currentPath = path + "/" + crew.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, crew).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			crew = await result.Content.ReadAsAsync<Crew>();
			return crew;
		}

		public async Task<HttpStatusCode> DeleteCrewAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
