using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class FailureTemplateViewModel : BaseViewModel
    {
        public string Type { get; private set; }
        public string FailureType
        {
            get { return Type; }
            set { Type = value; NotifyPropertyChanged(); }
        }

        public FailureTemplateViewModel(Failure failure)
        {
            this.FailureType = failure.Type;
        }

        public FailureTemplateViewModel(string type)
        {
            FailureType = type;
        }
    }
}
