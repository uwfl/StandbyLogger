using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class MainViewModel : PageViewModel
    {
        public MainViewModel(HomeViewModel homeVM, LogCreationViewModel logCreationVM, ServiceLogViewModel serviceLogVM, ChartsViewModel chartsVM, SettingsViewModel settingsVM)
            : base(homeVM, logCreationVM, serviceLogVM, chartsVM, settingsVM)
        {
        }
    }
}
