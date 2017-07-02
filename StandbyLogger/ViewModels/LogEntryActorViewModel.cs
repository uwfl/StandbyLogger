using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class LogEntryActorViewModel : BaseViewModel
    {
        public LogEntryActor LogEntryActor { get; private set; }
        
        public Employee Actor
        {
            get { return LogEntryActor.Actor; }
            set { LogEntryActor.Actor = value; NotifyPropertyChanged(); }
        }
        
        public DateTime From
        {
            get { return LogEntryActor.From; }
            set { LogEntryActor.From = value; NotifyPropertyChanged(); }
        }
        
        public DateTime To
        {
            get { return LogEntryActor.To; }
            set { LogEntryActor.To = value; NotifyPropertyChanged(); }
        }

        public LogEntryActorViewModel(LogEntryActor logEntryActor)
        {
            LogEntryActor = logEntryActor;
        }

        public LogEntryActorViewModel(Employee actor,DateTime from, DateTime to)
        {
            LogEntryActor = new LogEntryActor(actor, from, to);
        }
    }
}
