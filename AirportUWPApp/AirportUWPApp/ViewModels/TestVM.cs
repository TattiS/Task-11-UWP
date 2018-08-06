using AirportUWPApp.Models;
using AirportUWPApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUWPApp.ViewModels
{
    public class TestVM:BaseVM
    {
        private readonly CrewService service;
        public TestVM()
        {
            service = new CrewService();
            CurrentCrew = new NotifyTaskCompletion<Crew>(service.GetCrewAsync(3));
           
        }

        public string MyProperty => DateTime.Now.ToString();

        public NotifyTaskCompletion<Crew> CurrentCrew { get; private set; }
    }
}
