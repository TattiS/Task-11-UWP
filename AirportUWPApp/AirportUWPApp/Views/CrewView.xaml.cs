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
    public sealed partial class CrewView : Page
    {
        public CrewView()
        {
            this.InitializeComponent();
            ViewModel = new CrewVM();
            ListContainer.ItemsSource = ViewModel.Crews;
            this.Loaded += OnLoaded;
        }
        public CrewVM ViewModel { get; set; }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
        }
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListContainer.SelectedItems.Count == 1)
            {
                ViewModel.SelectedCrew = ListContainer.SelectedItem as Crew;
            }
            DetailContainer.Visibility = Visibility.Visible;
            FormContainer.Visibility = Visibility.Visible;
        }
        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedCrew = e.ClickedItem as Crew;
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int p;
            Int32.TryParse(PilotId.Text, out p);
            Crew newItem = new Crew() { Id = ViewModel.SelectedCrew.Id, PilotId = p, Stewardesses = new List<Stewardess> { new Stewardess { Name = SName.Text, Surname = SSurname.Text, BirthDate = SBirthDate.Date.Date, CrewId = ViewModel.SelectedCrew.Id } } };
            await ViewModel.Update(newItem);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int p;
            Int32.TryParse(PilotId.Text, out p);
            Crew newItem = new Crew() { PilotId = p, Stewardesses = new List<Stewardess> { new Stewardess { Name = SName.Text, Surname = SSurname.Text, BirthDate = SBirthDate.Date.Date, CrewId = ViewModel.SelectedCrew.Id } } };
            await ViewModel.AddNew(newItem);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await ViewModel.Delete(ViewModel.SelectedCrew.Id);
            DetailContainer.Visibility = Visibility.Collapsed;
            FormContainer.Visibility = Visibility.Collapsed;
            ViewModel.ListInit();
        }
    }
}
