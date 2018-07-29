using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AirportUWPApp.Models;
using Newtonsoft.Json;

namespace AirportUWPApp.Services
{
	public class PlaneTypeService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/PlaneTypes";
		private string currentPath = String.Empty;

		public PlaneTypeService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}
		public async Task<PlaneType> GetPlaneTypeAsync(int id)
		{
			PlaneType type = null;
			string currentPath = path+ "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				type = await result.Content.ReadAsAsync<PlaneType>().ConfigureAwait(false);
			}

			return type;
		}
		public async Task<IEnumerable<PlaneType>> GetPlaneTypesAsync()
		{
			IEnumerable<PlaneType> types = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				types = await result.Content.ReadAsAsync<IEnumerable<PlaneType>>().ConfigureAwait(false);
			}

			return types;
		}
		public async Task<HttpStatusCode> CreatePlaneTypeAsync(PlaneType type)
		{
			var result = await httpclient.PostAsJsonAsync(path, type).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}
		public async Task<PlaneType> UpdatePlaneTypeAsync(PlaneType type)
		{
			string currentPath = path + "/" + type.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, type).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			type = await result.Content.ReadAsAsync<PlaneType>();
			return type;
		}
		public async Task<HttpStatusCode> DeletePlaneTypeAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
