using AirportUWPApp.Models;
using AirportUWPApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AirportUWPApp.Views
{
	/// <summary>
	/// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
	/// </summary>
	public sealed partial class FlightView : Page
	{
		public FlightView()
		{
			this.InitializeComponent();
            ViewModel = new FlightVM();
            ListContainer.ItemsSource = ViewModel.Flights;
            this.Loaded += OnLoaded;
        }
        public FlightVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.SelectedFlight = ListContainer.SelectedItem as Flight;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedFlight = e.ClickedItem as Flight;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            double p;
            int i;
            Int32.TryParse(TId.Text, out i);
            Double.TryParse(TPrice.Text, out p);
            
            Flight newItem = new Flight() { Id = ViewModel.SelectedFlight.Id, DeparturePoint=DepPoint.Text, DepartureTime = DepTime.Date.DateTime, Destination=Destination.Text, ArrivalTime=ArrTime.Date.DateTime, Tickets = new List<Ticket>() { new Ticket {Id = i, Price = p, FlightId = ViewModel.SelectedFlight.Id } } };
            await ViewModel.Update(newItem);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double p;

            Double.TryParse(TPrice.Text, out p);

            Flight newItem = new Flight() { Id = ViewModel.SelectedFlight.Id, DeparturePoint = DepPoint.Text, DepartureTime = DepTime.Date.DateTime, Destination = Destination.Text, ArrivalTime = ArrTime.Date.DateTime, Tickets = new List<Ticket>() { new Ticket { Price = p, FlightId = ViewModel.SelectedFlight.Id } } };
            await ViewModel.AddNew(newItem);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.SelectedFlight.Id);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }
    }
}
