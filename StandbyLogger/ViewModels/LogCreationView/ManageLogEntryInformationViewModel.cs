using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels.LogCreationView
{
    public class ManageLogEntryInformationViewModel : BaseViewModel
    {
        public LogCreationViewModel LogCreationVM { get; set; }

        public override bool IsValid
        {
            get { return (Informer != null) && (TimeOfOccurrence != null); }
        }

        private Informer _informer;
        public Informer Informer
        {
            get { return _informer; }
            set { _informer = value; NotifyPropertyChanged(); NotifyPropertyChanged("IsValid"); }
        }

        private DateTime _timeOfOccurrence;
        public DateTime TimeOfOccurrence
        {
            get { return _timeOfOccurrence; }
            set { _timeOfOccurrence = value; NotifyPropertyChanged(); NotifyPropertyChanged("IsValid"); }
        }

        public ManageLogEntryInformationViewModel(LogCreationViewModel logCreationVM)
        {
            LogCreationVM = logCreationVM;
            TimeOfOccurrence = DateTime.Now;
            NotifyPropertyChanged("IsValid");
        }

        public void Reset()
        {
            Informer = null;
            TimeOfOccurrence = DateTime.Now;
            NotifyPropertyChanged("IsValid");
        }
    }
}
