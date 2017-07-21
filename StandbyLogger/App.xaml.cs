using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StandbyLogger.ViewModels;
using System.Windows.Markup;
using System.Globalization;
using System.Threading;
using StandbyLogger.Models;
using StandbyLogger.Interfaces;

namespace StandbyLogger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Create required directories.
            System.IO.Directory.CreateDirectory(Utilities.Constants.PATH_LOGDIRECTORY);

            // Set up IoC container.
            base.OnStartup(e);
            IUnityContainer container = new UnityContainer();
            IServiceLog serviceLog = new ServiceLog();

            container.RegisterInstance(typeof(IServiceLog), serviceLog);
            container.RegisterType<MainWindow>();
            container.RegisterType<ViewModels.MainViewModel>();
            container.RegisterType<ViewModels.ServiceLogViewModel>();
            container.RegisterType<ViewModels.LogCreationViewModel>();
            container.RegisterType<ViewModels.SettingsViewModel>();
            container.RegisterType<ViewModels.ChartsViewModel>();

            var mainWindow = container.Resolve<MainWindow>(); // Creating Main window
            Application.Current.MainWindow = mainWindow;
            Application.Current.MainWindow.Show();

            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(Thread.CurrentThread.CurrentCulture.Name)));
        }
    }
}
