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
	public class PilotVM: BaseVM
	{
        private readonly PilotService service;

        public PilotVM()
        {
            service = new PilotService();
            Pilots = new ObservableCollection<Pilot>();
            ListInit();
        }
        public Pilot SelectedPilot { get; set; }

        public ObservableCollection<Pilot> Pilots { get; private set; }

        public async void ListInit()
        {
            var collection = await service.GetPilotsAsync();
            foreach (var item in collection)
            {
                Pilots.Add(item);

            }
        }

        public async Task AddNew(Pilot pilot)
        {
            if (pilot is Pilot)
                await service.CreatePilotAsync(pilot);
        }

        public async Task Update(Pilot pilot)
        {
            if (pilot is Pilot)
                await service.UpdatePilotAsync(pilot);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeletePilotAsync(id);
        }   
    }
}
