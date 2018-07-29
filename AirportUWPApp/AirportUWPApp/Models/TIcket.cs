using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.Models
{
	public class Ticket
	{
		public int Id { get; set; }
		public double Price { get; set; }
		public int FlightId { get; set; }
	}
}
