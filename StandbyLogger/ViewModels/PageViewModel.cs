using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class PageViewModel : BaseViewModel
    {
        public HomeViewModel HomeVM { get; set; }
        public LogCreationViewModel LogCreationVM { get; set; }
        public ServiceLogViewModel ServiceLogVM { get; set; }
        public ChartsViewModel ChartsVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        public RelayCommand GoToLogCreationView { get; set; }
        public RelayCommand GoToServiceLogView { get; set; }
        public RelayCommand GoToChartsView { get; set; }
        public RelayCommand GoToSettingsView { get; set; }

        private BaseViewModel _currentView;
        public BaseViewModel CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; NotifyPropertyChanged(); }
        }

        public PageViewModel(HomeViewModel homeVM, LogCreationViewModel logCreationVM, ServiceLogViewModel serviceLogVM, ChartsViewModel chartsVM, SettingsViewModel settingsVM)
        {
            // Set ViewModels.
            HomeVM = homeVM;
            LogCreationVM = logCreationVM;
            ServiceLogVM = serviceLogVM;
            ChartsVM = chartsVM;
            SettingsVM = settingsVM;

            // Define commands.
            GoToLogCreationView = new RelayCommand(c => ShowLogCreationView(), c => IsValid == true);
            GoToServiceLogView = new RelayCommand(c => ShowServiceLogView(), c => IsValid == true);
            GoToChartsView = new RelayCommand(c => ShowChartsView(), c => IsValid == true);
            GoToSettingsView = new RelayCommand(c => ShowSettingsView(), c => IsValid == true);

            // Set start view.
            CurrentView = HomeVM;
        }

        public void ShowLogCreationView()
        {
            CurrentView = LogCreationVM;
        }

        public void ShowServiceLogView()
        {
            CurrentView = ServiceLogVM;
        }

        public void ShowChartsView()
        {
            CurrentView = ChartsVM;
        }

        public void ShowSettingsView()
        {
            CurrentView = SettingsVM;
        }
    }
}
