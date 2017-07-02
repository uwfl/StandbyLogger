using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels.LogCreationView
{
    public class ManageLogEntryActorsViewModel : BaseViewModel
    {
        public LogCreationViewModel LogCreationVM { get; set; }

        public override bool IsValid
        {
            get { return LogEntryActors.Count > 0; }
        }

        private Employee _actor;
        public Employee Actor
        {
            get { return _actor; }
            set { _actor = value; NotifyPropertyChanged(); }
        }

        private DateTime _from;
        public DateTime From
        {
            get { return _from; }
            set { _from = value; NotifyPropertyChanged(); }
        }

        private DateTime _to;
        public DateTime To
        {
            get { return _to; }
            set { _to = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<LogEntryActorViewModel> _logEntryActors;
        public ObservableCollection<LogEntryActorViewModel> LogEntryActors
        {
            get { return _logEntryActors; }
            set { _logEntryActors = value; NotifyPropertyChanged(); }
        }

        private LogEntryActorViewModel _selectedLogEntryActor;
        public LogEntryActorViewModel SelectedLogEntryActor
        {
            get { return _selectedLogEntryActor; }
            set
            {
                _selectedLogEntryActor = value;

                if(value != null)
                {
                    Actor = value.Actor;
                    From = value.From;
                    To = value.To; 
                }
            }
        }

        public RelayCommand AddLogEntryActorCommand { get; set; }
        public RelayCommand UpdateLogEntryActorCommand { get; set; }
        public RelayCommand RemoveLogEntryActorCommand { get; set; }

        public ManageLogEntryActorsViewModel(LogCreationViewModel logCreationVM)
        {
            LogCreationVM = logCreationVM;
            LogEntryActors = new ObservableCollection<LogEntryActorViewModel>();

            AddLogEntryActorCommand = new RelayCommand(c => AddLogEntryActor(), c => CanAddLogEntryActor());
            UpdateLogEntryActorCommand = new RelayCommand(c => UpdateLogEntryActor(), c => SelectedLogEntryActor != null);
            RemoveLogEntryActorCommand = new RelayCommand(c => RemoveLogEntryActor(), c => SelectedLogEntryActor != null);
            NotifyPropertyChanged("IsValid");
        }

        public void Reset()
        {
            LogEntryActors.Clear();
            NotifyPropertyChanged("IsValid");
        }

        private bool CanAddLogEntryActor()
        {
            if (Actor == null)
                return false;

            if (From == null)
                return false;

            if (To == null)
                return false;

            return true;
        }

        private void AddLogEntryActor()
        {
            var logEntryActor = new LogEntryActorViewModel(Actor, From, To);
            LogEntryActors.Add(logEntryActor);
            NotifyPropertyChanged("IsValid");
        }

        private void UpdateLogEntryActor()
        {
            SelectedLogEntryActor.Actor = Actor;
            SelectedLogEntryActor.From = From;
            SelectedLogEntryActor.To = To;
        }

        private void RemoveLogEntryActor()
        {
            LogEntryActors.Remove(SelectedLogEntryActor);
            NotifyPropertyChanged("IsValid");
        }
    }
}
