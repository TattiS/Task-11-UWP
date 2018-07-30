using AirportUWPApp.Models;
using AirportUWPApp.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AirportUWPApp.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class DepartureView : Page
    {
        public DepartureView()
        {
            this.InitializeComponent();
            ViewModel = new DepartureVM();
            ListContainer.ItemsSource = ViewModel.Departures;
            this.Loaded += OnLoaded;
        }
        public DepartureVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.SelectedDeparture = ListContainer.SelectedItem as Departure;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedDeparture = e.ClickedItem as Departure;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(FlightId.Text, out int i);
            Int32.TryParse(CrewId.Text, out int ic);
            Int32.TryParse(PlaneId.Text, out int p);
            Departure newItem = new Departure()
            {
                Id = ViewModel.SelectedDeparture.Id,
                DepartureDate = DepDate.Date.Date,
                FlightId = i,
                CrewItem = new
                Crew
                { Id = ic },
                PlaneItem = new Plane { Id = p }
            };
            await ViewModel.Update(newItem);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(FlightId.Text, out int i);
            Int32.TryParse(CrewId.Text, out int ic);
            Int32.TryParse(PlaneId.Text, out int p);
            Departure newItem = new Departure()
            {
                Id = ViewModel.SelectedDeparture.Id,
                DepartureDate = DepDate.Date.Date,
                FlightId = i,
                CrewItem = new
                Crew
                { Id = ic },
                PlaneItem = new Plane { Id = p }
            };
            await ViewModel.AddNew(newItem);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.SelectedDeparture.Id);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }
    }
}
