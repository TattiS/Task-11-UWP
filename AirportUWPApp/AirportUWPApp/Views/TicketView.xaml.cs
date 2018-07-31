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
	public sealed partial class TicketView : Page
	{
        
		public TicketView()
		{
			this.InitializeComponent();
            ViewModel = new TicketVM();
            ListContainer.ItemsSource = ViewModel.Tickets;
            this.Loaded += OnLoaded;
        }

        public TicketVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.SelectedTicket = ListContainer.SelectedItem as Ticket;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedTicket = e.ClickedItem as Ticket;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int i;
            double p;
            int.TryParse(TFlight.Text, out i);
            double.TryParse(TPrice.Text, out p);
            Ticket newItem = new Ticket() { Id = ViewModel.SelectedTicket.Id, Price = p, FlightId = i };
            await ViewModel.Update(newItem);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i;
            double p;
            int.TryParse(TFlight.Text, out i);
            double.TryParse(TPrice.Text, out p);
            Ticket newItem = new Ticket() { Id = ViewModel.SelectedTicket.Id, Price = p, FlightId = i };
            await ViewModel.AddNew(newItem);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.SelectedTicket.Id);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }
    }
}
