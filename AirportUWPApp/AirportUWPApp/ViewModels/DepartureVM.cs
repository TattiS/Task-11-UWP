using AirportUWPApp.Models;
using AirportUWPApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AirportUWPApp.ViewModels
{
    public class DepartureVM: BaseVM
	{
        private readonly DepartureService service;
        public DepartureVM()
        {
            service = new DepartureService();
            Departures = new ObservableCollection<Departure>();
            SelectedDeparture = new Departure();
            ListInit();

        }
        public ObservableCollection<Departure> Departures { get; private set; }
        public Departure SelectedDeparture { get; set; }

        public async void ListInit()
        {
            Departures.Clear();
            var collection = await service.GetDeparturesAsync();
            foreach (var item in collection)
            {
                Departures.Add(item);

            }
        }

        public async Task AddNew(Departure departure)
        {
            if (departure is Departure)
                await service.CreateDepartureAsync(departure);
        }

        public async Task Update(Departure departure)
        {
            if (departure is Departure)
                await service.UpdateDepartureAsync(departure);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeleteDepartureAsync(id);
        }
    }
}
