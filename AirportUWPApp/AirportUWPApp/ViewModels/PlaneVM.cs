using AirportUWPApp.Models;
using AirportUWPApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.ViewModels
{
	public class PlaneVM: BaseVM
	{
        private readonly PlaneService service;

        public PlaneVM()
        {
            service = new PlaneService();
            Planes = new ObservableCollection<Plane>();
            ListInit();
        }
        public Plane SelectedPlane { get; set; }

        public ObservableCollection<Plane> Planes { get; private set; }

        public async void ListInit()
        {
            var collection = await service.GetPlanesAsync();
            foreach (var item in collection)
            {
                Planes.Add(item);

            }
        }

        public async Task AddNew(Plane plane)
        {
            if (plane is Plane)
                await service.CreatePlaneAsync(plane);
        }

        public async Task Update(Plane plane)
        {
            if (plane is Plane)
                await service.UpdatePlaneAsync(plane);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeletePlaneAsync(id);
        }
    }
}
