using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels.LogCreationView
{
    public class ManageLogEntryFailureDataViewModel : BaseViewModel
    {
        public LogCreationViewModel LogCreationVM { get; set; }

        public override bool IsValid
        {
            get { return (!string.IsNullOrWhiteSpace(FailureType) && FailureTime != null && !string.IsNullOrWhiteSpace(ActionsTaken)); }
        }

        private string _failureType;
        public string FailureType
        {
            get { return _failureType; }
            set { _failureType = value; NotifyPropertyChanged(); }
        }

        private DateTime _failureTime;
        public DateTime FailureTime
        {
            get { return _failureTime; }
            set { _failureTime = value; NotifyPropertyChanged(); }
        }

        private string _actionsTaken;
        public string ActionsTaken
        {
            get { return _actionsTaken; }
            set { _actionsTaken = value; NotifyPropertyChanged(); }
        }

        private bool _failureResolved;
        public bool FailureResolved
        {
            get { return _failureResolved; }
            set { _failureResolved = value; NotifyPropertyChanged(); }
        }

        private bool _serviceCompanyInvolved;
        public bool ServiceCompanyInvolved
        {
            get { return _serviceCompanyInvolved; }
            set { _serviceCompanyInvolved = value; NotifyPropertyChanged(); }
        }

        public ManageLogEntryFailureDataViewModel(LogCreationViewModel logCreationVM)
        {
            LogCreationVM = logCreationVM;
            FailureTime = DateTime.Now;
        }

        public void Reset()
        {
            FailureType = string.Empty;
            FailureTime = DateTime.Now;
            ActionsTaken = string.Empty;
            FailureResolved = false;
            ServiceCompanyInvolved = false;
        }
    }
}
