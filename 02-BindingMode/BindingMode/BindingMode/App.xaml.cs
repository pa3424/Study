using BindingMode.ViewModels;
using BindingMode.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BindingMode
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
