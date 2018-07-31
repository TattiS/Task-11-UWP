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
	public sealed partial class StewardessView : Page
	{
		public StewardessView()
		{
			this.InitializeComponent();
            ViewModel = new StewardessVM();
            ListContainer.ItemsSource = ViewModel.Stewardesses;
            this.Loaded += OnLoaded;
		}

        public StewardessVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.SelectedStewardess = ListContainer.SelectedItem as Stewardess;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedStewardess = e.ClickedItem as Stewardess;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int i;
            int.TryParse(SCrewId.Text, out i);
            Stewardess stew = new Stewardess() {Id=ViewModel.SelectedStewardess.Id, Name = SName.Text, Surname = SSurname.Text, BirthDate = SBirthDate.Date.Date, CrewId = i };
            await ViewModel.Update(stew);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int i;
            int.TryParse(SCrewId.Text, out i);
            Stewardess stew = new Stewardess() { Name = SName.Text, Surname = SSurname.Text, BirthDate = SBirthDate.Date.Date, CrewId = i };
            await ViewModel.AddNew(stew);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.SelectedStewardess.Id);
            ViewModel.ListInit();
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
    }
}
