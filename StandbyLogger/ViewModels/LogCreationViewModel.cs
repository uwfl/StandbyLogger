using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class LogCreationViewModel : BaseViewModel
    {
        private Informer _informer;
        public Informer Informer
        {
            get { return _informer; }
            set { _informer = value; NotifyPropertyChanged(); }
        }

        private DateTime _timeOfOccurrence;
        public DateTime TimeOfOccurrence
        {
            get { return _timeOfOccurrence; }
            set { _timeOfOccurrence = value; NotifyPropertyChanged(); }
        }

        private ObservableCollection<LogEntryActorViewModel> _logEntryActors;
        public ObservableCollection<LogEntryActorViewModel> LogEntryActors
        {
            get { return _logEntryActors; }
            set { _logEntryActors = value;  NotifyPropertyChanged(); }
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

        public RelayCommand SaveLogCommand { get; set; }
        public RelayCommand AddActorCommand { get; set; }

        public LogCreationViewModel()
        {
            SaveLogCommand = new RelayCommand(c => SaveLog(), c => true);
            AddActorCommand = new RelayCommand(c => AddActor(), c => true);

            LogEntryActors = new ObservableCollection<LogEntryActorViewModel>();
        }

        public void Reset()
        {
            Informer = null;
            TimeOfOccurrence = DateTime.Now;
            LogEntryActors.Clear();
            FailureType = string.Empty;
            FailureTime = DateTime.Now;
            ActionsTaken = string.Empty;
            FailureResolved = false;
            ServiceCompanyInvolved = false;            
        }

        private void AddActor()
        {
            var employeeList = new List<Employee>();
            employeeList.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));
            employeeList.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));
            employeeList.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));
            employeeList.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));
            employeeList.Add(new Employee("Markus", "Voß", DateTime.Now, new Company("Familie Reckeweg")));

            var actor = new LogEntryActorViewModel(employeeList, TimeOfOccurrence, TimeOfOccurrence);
            actor.FlaggedForRemoval += Actor_FlaggedForRemoval;
            LogEntryActors.Add(actor);
        }

        private void Actor_FlaggedForRemoval(object sender, EventArgs e)
        {
            var actorToRemove = sender as LogEntryActorViewModel;
            actorToRemove.FlaggedForRemoval -= Actor_FlaggedForRemoval;
            LogEntryActors.Remove(actorToRemove);
        }

        private void SaveLog()
        {
            Failure failure = new Failure(FailureType, FailureTime, ActionsTaken, FailureResolved, ServiceCompanyInvolved);
            LogEntry entry = new LogEntry(Informer, TimeOfOccurrence, LogEntryActors.Select(a => a.ToLogEntryActor()).ToList(), failure);
        }
    }
}
