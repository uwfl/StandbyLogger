using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandbyLogger.ViewModels.LogCreationView;

namespace StandbyLogger.ViewModels
{
    public class LogCreationViewModel : BaseViewModel
    {
        public Settings CurrentSettings { get; private set; }

        public ManageLogEntryInformationViewModel ManageLogEntryInformationVM { get; set; }
        public ManageLogEntryActorsViewModel ManageLogEntryActorsVM { get; set; }
        public ManageLogEntryFailureDataViewModel ManageLogEntryFailureDataVM { get; set; }
        public NotifyLogEntryViewModel NotifyLogEntryVM { get; set; }

        public RelayCommand ShowManageInformationViewCommand { get; set; }
        public RelayCommand ShowManageActorsViewCommand { get; set; }
        public RelayCommand ShowManageFailureDataCommand { get; set; }
        public RelayCommand SaveLogCommand { get; set; }

        private BaseViewModel _currentSubview;
        public BaseViewModel CurrentSubview
        {
            get { return _currentSubview; }
            set { _currentSubview = value; NotifyPropertyChanged(); }
        }

        public LogCreationViewModel()
        {
            // Create VMs.
            ManageLogEntryInformationVM = new ManageLogEntryInformationViewModel(this);
            ManageLogEntryActorsVM = new ManageLogEntryActorsViewModel(this);
            ManageLogEntryFailureDataVM = new ManageLogEntryFailureDataViewModel(this);
            NotifyLogEntryVM = new NotifyLogEntryViewModel();

            // Set default subview.
            CurrentSubview = ManageLogEntryInformationVM;

            // Create commands.
            ShowManageInformationViewCommand = new RelayCommand(c => ShowManageInformationView(), c => true);
            ShowManageActorsViewCommand = new RelayCommand(c => ShowManageActorsView(), c => ManageLogEntryInformationVM.IsValid);
            ShowManageFailureDataCommand = new RelayCommand(c => ShowManageFailureDataView(), c => ManageLogEntryActorsVM.IsValid);
            SaveLogCommand = new RelayCommand(c => SaveLog(), c => (ManageLogEntryInformationVM.IsValid && ManageLogEntryActorsVM.IsValid && ManageLogEntryFailureDataVM.IsValid) && !IsBusy);
        }

        public void Reset()
        {
            // Reset all steps.
            ManageLogEntryInformationVM.Reset();
            ManageLogEntryActorsVM.Reset();
            ManageLogEntryFailureDataVM.Reset();

            // Set first step.
            CurrentSubview = ManageLogEntryInformationVM;
        }

        public void SetSettings(Settings currentSettings)
        {
            CurrentSettings = currentSettings;
            NotifyPropertyChanged("CurrentSettings");
        }

        public void ShowManageInformationView()
        {
            CurrentSubview = ManageLogEntryInformationVM;
        }

        public void ShowManageActorsView()
        {
            CurrentSubview = ManageLogEntryActorsVM;
        }

        public void ShowManageFailureDataView()
        {
            CurrentSubview = ManageLogEntryFailureDataVM;
        }
        
        public void ShowNotifyLogEntryView(LogEntry logEntry)
        {
            NotifyLogEntryVM.SetLogEntry(logEntry);
            CurrentSubview = NotifyLogEntryVM;
        }

        private LogEntry SaveLog()
        {
            IsBusy = true;
            // Create failure object.
            var failure = new Failure(ManageLogEntryFailureDataVM.FailureType, ManageLogEntryFailureDataVM.FailureTime, ManageLogEntryFailureDataVM.ActionsTaken, 
                                        ManageLogEntryFailureDataVM.FailureResolved, ManageLogEntryFailureDataVM.ServiceCompanyInvolved);

            // Create log entry object.
            var entry = new LogEntry(ManageLogEntryInformationVM.Informer, ManageLogEntryInformationVM.TimeOfOccurrence, 
                                            ManageLogEntryActorsVM.LogEntryActors.Select(lea => lea.LogEntryActor).ToList(), failure);

            // Create filename.
            var sb = new StringBuilder();
            sb.Append("log_");
            sb.Append(entry.TimeOfOccurrence.ToShortDateString());
            sb.Append("_");
            sb.Append(entry.Informer.Name);
            sb.Append("_");
            sb.Append(failure.Resolved ? "BEHOBEN" : "OFFEN");

            string filename = System.IO.Path.Combine(Utilities.Constants.PATH_LOGDIRECTORY, sb.ToString() + ".xml");
            int counter = 0;
            while(System.IO.File.Exists(filename))
            {
                filename = System.IO.Path.Combine(Utilities.Constants.PATH_LOGDIRECTORY, sb.ToString() + "_" + ++counter + ".xml");
            }

            // Save log entry.
            Utilities.SerializingHelper.Serialize(entry, filename);
            IsBusy = false;


            // Switch to next view.
            ShowNotifyLogEntryView(entry);

            return entry;
        }
    }
}
