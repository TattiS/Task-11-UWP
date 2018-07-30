using AirportUWPApp.Models;
using AirportUWPApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AirportUWPApp.ViewModels
{
    public class PlaneTypeVM:BaseVM
	{
		private readonly PlaneTypeService service;
		
		public PlaneTypeVM()
		{
			service = new PlaneTypeService();
			Types = new ObservableCollection<PlaneType>();
			ListInit();
		}
		public PlaneType Type { get; set; }

		public ObservableCollection<PlaneType> Types { get; private set; }

		public async void ListInit()
		{
            Types.Clear();
			var collection = await service.GetPlaneTypesAsync();
			foreach (var item in collection)
			{
				Types.Add(item);
				
			}
			Type = new PlaneType() { Id = Types.Count };
			NotifyPropertyChanged(() => Type);
		}

		public async Task AddNew(PlaneType type)
		{
			if(type is PlaneType)
			await service.CreatePlaneTypeAsync(type);
		}

		public async Task Update(PlaneType type)
		{
			if(type is PlaneType)
			await service.UpdatePlaneTypeAsync(type);
		}

		public async Task Delete(int id)
		{
			if(id > 0)
			await service.DeletePlaneTypeAsync(id);
		}
	}
}
