using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class LogEntryActorViewModel : BaseViewModel
    {
        public RelayCommand FlagToRemoveCommand { get; set; }
        public List<Employee> Actors { get; set; }
        public event EventHandler FlaggedForRemoval;

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

        public LogEntryActorViewModel(List<Employee> actors, DateTime from, DateTime to)
        {
            Actors = actors;
            From = from;
            To = to;

            FlagToRemoveCommand = new RelayCommand(c => FlagForRemoval(), c => true);
        }

        public void FlagForRemoval()
        {
            OnFlagForRemoval(EventArgs.Empty);
        }

        protected virtual void OnFlagForRemoval(EventArgs e)
        {
            if (FlaggedForRemoval != null)
            {
                FlaggedForRemoval(this, e);
            }
        }

        public LogEntryActor ToLogEntryActor()
        {
            return new LogEntryActor(Actor, From, To);
        }
    }
}
