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
	public class PlaneService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Planes";
		private string currentPath = String.Empty;
		public PlaneService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Plane> GetPlaneAsync(int id)
		{
			Plane plane = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				plane = await result.Content.ReadAsAsync<Plane>().ConfigureAwait(false);
			}

			return plane;
		}

		public async Task<IEnumerable<Plane>> GetPlanesAsync()
		{
			IEnumerable<Plane> planes = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				planes = await result.Content.ReadAsAsync<IEnumerable<Plane>>().ConfigureAwait(false);
			}

			return planes;
		}

		public async Task<HttpStatusCode> CreatePlaneAsync(Plane plane)
		{
			var result = await httpclient.PostAsJsonAsync(path, plane).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Plane> UpdatePlaneAsync(Plane plane)
		{
			string currentPath = path + "/" + plane.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, plane).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			plane = await result.Content.ReadAsAsync<Plane>();
			return plane;
		}

		public async Task<HttpStatusCode> DeletePlaneAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
