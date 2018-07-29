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
	public class StewardessVM: BaseVM
	{
        private readonly StewardessService service;

        public StewardessVM()
        {
            service = new StewardessService();
            Stewardesses = new ObservableCollection<Stewardess>();
            ListInit();
        }
        public Stewardess SelectedStewardess { get; set; }

        public ObservableCollection<Stewardess> Stewardesses { get; private set; }

        public async void ListInit()
        {
            var collection = await service.GetStewardessesAsync();
            foreach (var item in collection)
            {
                Stewardesses.Add(item);

            }
        }

        public async Task AddNew(Stewardess stewardess)
        {
            if (stewardess is Stewardess)
                await service.CreateStewardessAsync(stewardess);
        }

        public async Task Update(Stewardess stewardess)
        {
            if (stewardess is Stewardess)
                await service.UpdateStewardessAsync(stewardess);
        }

        public async Task Delete(int id)
        {
            if (id > 0)
                await service.DeleteStewardessAsync(id);
        }
    }
}
