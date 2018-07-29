using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.Models
{
	public class Flight
	{
		public int Id { get; set; }
		public string DeparturePoint { get; set; }
		public DateTime DepartureTime { get; set; }
		public string Destination { get; set; }
		public DateTime ArrivalTime { get; set; }
		public List<Ticket> Tickets { get; set; }
	}
}
