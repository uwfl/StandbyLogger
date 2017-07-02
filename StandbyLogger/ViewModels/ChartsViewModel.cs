using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;

namespace StandbyLogger.ViewModels
{
    public class ChartsViewModel : BaseViewModel
    {
        public ServiceLog ServiceLog { get; private set; }

        public ChartsViewModel()
        {

        }

        public void SetDataSource(ServiceLog serviceLog)
        {
            ServiceLog = serviceLog;
        }
    }
}
