using Microsoft.Practices.Unity;
using StandbyLogger.Interfaces;
using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class ServiceLogViewModel : BaseViewModel
    {
        public IServiceLog ServiceLog { get; set; }

        public ServiceLogViewModel(IServiceLog serviceLog)
        {
            ServiceLog = serviceLog;
        }
    }
}
