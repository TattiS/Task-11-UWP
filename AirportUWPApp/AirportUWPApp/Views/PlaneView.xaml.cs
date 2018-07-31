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
	public sealed partial class PlaneView : Page
	{
		public PlaneView()
		{
			this.InitializeComponent();
            ViewModel = new PlaneVM();
            ListContainer.ItemsSource = ViewModel.Planes;
            this.Loaded += OnLoaded;
        }
        public PlaneVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.SelectedPlane = ListContainer.SelectedItem as Plane;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedPlane = e.ClickedItem as Plane;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int i,at,st;
            TimeSpan ol;
            TimeSpan.TryParse(POperationLife.Text,out ol);
            Int32.TryParse(PTypeId.Text, out i);
            Int32.TryParse(PTypeLift.Text, out at);
            Int32.TryParse(PTypeSeats.Text, out st);
            Plane newItem = new Plane() { Id = ViewModel.SelectedPlane.Id, Name = PName.Text, ReleaseDate = PReleaseDate.Date.Date, OperationLife = ol, TypeOfPlane = new PlaneType { Id = i, AirLift = at, Seats = st, Model = PTypeModel.Text } };
            await ViewModel.Update(newItem);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i, at, st;
            TimeSpan ol;
            TimeSpan.TryParse(POperationLife.Text, out ol);
            Int32.TryParse(PTypeId.Text, out i);
            Int32.TryParse(PTypeLift.Text, out at);
            Int32.TryParse(PTypeSeats.Text, out st);
            Plane newItem = new Plane() { Name = PName.Text, ReleaseDate = PReleaseDate.Date.Date, OperationLife = ol, TypeOfPlane = new PlaneType { Id = i, AirLift = at, Seats = st, Model = PTypeModel.Text } };
            await ViewModel.AddNew(newItem);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.SelectedPlane.Id);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
    }
}
