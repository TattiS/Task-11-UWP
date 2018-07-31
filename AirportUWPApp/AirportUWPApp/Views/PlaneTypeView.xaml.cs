using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AirportUWPApp.Models;
using AirportUWPApp.Services;
using AirportUWPApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AirportUWPApp.Views
{
	/// <summary>
	/// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
	/// </summary>
	public sealed partial class PlaneTypeView : Page
	{
		
		//private PlaneType selectedItem;
		public PlaneTypeView()
		{
			this.InitializeComponent();
			ViewModel = new PlaneTypeVM();
            ListContainer.ItemsSource = ViewModel.Types;
            this.Loaded += OnLoaded;

        }
		public PlaneTypeVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.Type = ListContainer.SelectedItem as PlaneType;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.Type = e.ClickedItem as PlaneType;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int s,a;
            Int32.TryParse(TSeats.Text, out s);
            Int32.TryParse(TAirLift.Text, out a);
            PlaneType newItem = new PlaneType() { Id = ViewModel.Type.Id, Model = TModel.Text, Seats=s, AirLift = a };
            await ViewModel.Update(newItem);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int s, a;
            Int32.TryParse(TSeats.Text, out s);
            Int32.TryParse(TAirLift.Text, out a);
            PlaneType newItem = new PlaneType() { Id = ViewModel.Type.Id, Model = TModel.Text, Seats = s, AirLift = a };
            await ViewModel.AddNew(newItem);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.Type.Id);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }

    }
}
