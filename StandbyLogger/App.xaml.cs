using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StandbyLogger.ViewModels;

namespace StandbyLogger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();

            container.RegisterType<MainWindow>();
            container.RegisterType<ViewModels.MainViewModel>();
            container.RegisterType<ViewModels.HomeViewModel>();
            container.RegisterType<ViewModels.LogCreationViewModel>();
            container.RegisterType<ViewModels.SettingsViewModel>();
            container.RegisterType<ViewModels.ChartsViewModel>();

            var mainWindow = container.Resolve<MainWindow>(); // Creating Main window
            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();
        }
    }
}
