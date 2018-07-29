using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.Models
{
	public class Departure
	{
		public int Id { get; set; }
		public int FlightId { get; set; }
		public DateTime DepartureDate { get; set; }
		public Crew CrewItem { get; set; }
		public Plane PlaneItem { get; set; }
	}
}
