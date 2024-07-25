using Microsoft.Extensions.DependencyInjection;
using ObservableCollection.ViewModels;
using ObservableCollection.Views;
using System.Windows;

namespace ObservableCollection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Services = ConfigureServices();

            var mainWindow = new MainWindow
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                WindowState = WindowState.Normal,
                DataContext = Services.GetService<MainViewModel>()
            };
            mainWindow.Show();
        }

        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }

        public IServiceProvider Services { get; private set; }
    }
}
