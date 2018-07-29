using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using AirportUWPApp.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace AirportUWPApp
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private void GoToPilots_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToDepartures_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToTickets_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToFlights_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToTypes_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToPlanes_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToCrews_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void GoToStewardesses_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
	}
}
