using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.Models
{
	public class Crew
	{
		public int Id { get; set; }
		public int PilotId { get; set; }
		public List<Stewardess> Stewardesses { get; set; }
	}
}
