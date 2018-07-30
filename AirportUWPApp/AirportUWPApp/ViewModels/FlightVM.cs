using AirportUWPApp.Models;
using AirportUWPApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AirportUWPApp.ViewModels
{
    public class FlightVM: BaseVM
	{
        private readonly FlightService service;

        public FlightVM()
        {
            service = new FlightService();
            Flights = new ObservableCollection<Flight>();
            ListInit();
        }
        public Flight SelectedFlight { get; set; }

        public ObservableCollection<Flight> Flights { get; private set; }

        public async void ListInit()
        {
            Flights.Clear();
            var collection = await service.GetFlightsAsync();
            foreach (var item in collection)
            {
                Flights.Add(item);

            }
            
        }

        public async Task AddNew(Flight flight)
        {
            if (flight is Flight)
                await service.CreateFlightAsync(flight);
        }

        public async Task Update(Flight flight)
        {
            if (flight is Flight)
                await service.UpdateFlightAsync(flight);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeleteFlightAsync(id);
        }
    }
}
