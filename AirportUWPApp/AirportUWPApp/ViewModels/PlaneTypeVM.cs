using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportUWPApp.Models;
using AirportUWPApp.Services;

namespace AirportUWPApp.ViewModels
{
	public class PlaneTypeVM:BaseVM
	{
		private readonly PlaneTypeService service;
		
		public PlaneTypeVM()
		{
			service = new PlaneTypeService();
			Types = new ObservableCollection<PlaneType>();
			Type = new PlaneType();
			ListInit();
		}

		public ObservableCollection<PlaneType> Types {get; set;}
		public PlaneType Type { get; set; }

		public async void ListInit()
		{
			var collection = await service.GetPlaneTypesAsync();
			foreach (var item in collection)
			{
				Types.Add(item);
			}
		}

		public async Task Set()
		{
			PlaneType t = new PlaneType {Id=2, Model = "ASDFGHLKJLK", Seats=55, AirLift=1212121};
			await service.DeletePlaneTypeAsync(4);
		}
	}
}
