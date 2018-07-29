using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.Models
{
	public class Plane
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public PlaneType TypeOfPlane { get; set; }
		public DateTime ReleaseDate { get; set; }
		public TimeSpan OperationLife { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
