using AirportUWPApp.Models;
using AirportUWPApp.Services;
using AirportUWPApp.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AirportUWPApp.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        private readonly CrewService service;
        public TestPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += CurrentWindow_SizeChanged;
            service = new CrewService();
           // TestViewModel = new TestVM();
            MyProperty = new NotifyTaskCompletion<Crew>(service.GetCrewAsync(1));
            TxtBox.DataContext = MyProperty.Result;

        }
        public NotifyTaskCompletion<Crew> MyProperty { get; private set; }

       // public TestVM TestViewModel { get; set; }
        private void CurrentWindow_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            if (e.Size.Width > 640)
            {
               VisualStateManager.GoToState(this, "WideState", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "DefaultState", false);
            }
                
        }
    }
}
