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
		
		private PlaneType selectedItem;
		public PlaneTypeView()
		{
			this.InitializeComponent();
			ViewModel = new PlaneTypeVM();
			MasterListView.DataContext = ViewModel.Types;
			
		}
		public PlaneTypeVM ViewModel { get; set; }
		

		private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (MasterListView.SelectedItems.Count == 1)
			{
				selectedItem = MasterListView.SelectedItem as PlaneType;

				EnableContentTransitions();
			}
			else
			{
				DetailContentPresenter.Visibility = Visibility.Collapsed;
				FormContainer.Visibility = Visibility.Collapsed;
			}

		}
		private void OnItemClick(object sender, ItemClickEventArgs e)
		{
			
			selectedItem = e.ClickedItem as PlaneType;
			EnableContentTransitions();
			
		}

		private void EnableContentTransitions()
		{
			DetailContentPresenter.ContentTransitions.Clear();
			DetailContentPresenter.ContentTransitions.Add(new EntranceThemeTransition());
		}

		private void AddItem(object sender, RoutedEventArgs e)
		{

			
			EnableContentTransitions();

		}

		private void UpdateItem(object sender, RoutedEventArgs e)
		{


			EnableContentTransitions();

		}

		private async void DeleteItem(object sender, RoutedEventArgs e)
		{
			int id = -1;
			var item = MasterListView.SelectedItem as PlaneType;
			 int.TryParse(item?.Id.ToString(), out id);
			await ViewModel.Delete(id);
			EnableContentTransitions();

		}

		private void CancelSelection(object sender, RoutedEventArgs e)
		{


			EnableContentTransitions();

		}
	}
}
