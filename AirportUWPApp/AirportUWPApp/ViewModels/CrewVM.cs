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
	public class CrewVM: BaseVM
	{
		private readonly CrewService service;

		public CrewVM()
		{
			service = new CrewService();
            Crews = new ObservableCollection<Crew>();
            SelectedCrew = new Crew();
            ListInit();
		}
        public ObservableCollection<Crew> Crews { get; private set; }
        public Crew SelectedCrew { get; set; }

        public async void ListInit()
        {
            var collection = await service.GetCrewsAsync();
            foreach (var item in collection)
            {
                Crews.Add(item);

            }
        }

        public async Task AddNew(Crew crew)
        {
            if (crew is Crew)
                await service.CreateCrewAsync(crew);
        }

        public async Task Update(Crew crew)
        {
            if (crew is Crew)
                await service.UpdateCrewAsync(crew);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeleteCrewAsync(id);
        }
    }
}
