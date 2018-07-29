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
	public class TicketService
	{
		private HttpClient httpclient = new HttpClient();
		private string path = "api/Tickets";
		private string currentPath = String.Empty;
		public TicketService()
		{
			httpclient.BaseAddress = new Uri("http://localhost:62452/");
			httpclient.DefaultRequestHeaders.Accept.Clear();
			httpclient.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<Ticket> GetTicketAsync(int id)
		{
			Ticket ticket = null;
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.GetAsync(currentPath);
			if (result.IsSuccessStatusCode)
			{
				ticket = await result.Content.ReadAsAsync<Ticket>().ConfigureAwait(false);
			}

			return ticket;
		}

		public async Task<IEnumerable<Ticket>> GetTicketsAsync()
		{
			IEnumerable<Ticket> tickets = null;
			var result = await httpclient.GetAsync(path);
			if (result.IsSuccessStatusCode)
			{
				tickets = await result.Content.ReadAsAsync<IEnumerable<Ticket>>().ConfigureAwait(false);
			}

			return tickets;
		}

		public async Task<HttpStatusCode> CreateTicketAsync(Ticket ticket)
		{
			var result = await httpclient.PostAsJsonAsync(path, ticket).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();
			return result.StatusCode;
		}

		public async Task<Ticket> UpdateTicketAsync(Ticket ticket)
		{
			string currentPath = path + "/" + ticket.Id.ToString();
			var result = await httpclient.PutAsJsonAsync(
				currentPath, ticket).ConfigureAwait(false);
			result.EnsureSuccessStatusCode();

			ticket = await result.Content.ReadAsAsync<Ticket>();
			return ticket;
		}

		public async Task<HttpStatusCode> DeleteTicketAsync(int id)
		{
			string currentPath = path + "/" + id.ToString();
			var result = await httpclient.DeleteAsync(
				currentPath).ConfigureAwait(false);
			return result.StatusCode;
		}
	}
}
