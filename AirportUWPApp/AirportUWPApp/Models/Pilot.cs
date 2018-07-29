using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.Models
{
	public class Pilot
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }

		public DateTime BirthDate { get; set; }
		public TimeSpan Experience { get; set; }
		
	}
}
