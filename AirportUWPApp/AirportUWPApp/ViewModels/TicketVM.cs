using AirportUWPApp.Models;
using AirportUWPApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AirportUWPApp.ViewModels
{
    public class TicketVM:BaseVM
	{
        private readonly TicketService service;

        public TicketVM()
        {
            service = new TicketService();
            Tickets = new ObservableCollection<Ticket>();
            ListInit();
        }
        public Ticket SelectedTicket { get; set; }

        public ObservableCollection<Ticket> Tickets { get; private set; }

        public async void ListInit()
        {
            Tickets.Clear();
            var collection = await service.GetTicketsAsync();
            foreach (var item in collection)
            {
                Tickets.Add(item);

            }
           
        }

        public async Task AddNew(Ticket ticket)
        {
            if (ticket is Ticket)
                await service.CreateTicketAsync(ticket);
        }

        public async Task Update(Ticket ticket)
        {
            if (ticket is Ticket)
                await service.UpdateTicketAsync(ticket);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeleteTicketAsync(id);
        }
    }
}
