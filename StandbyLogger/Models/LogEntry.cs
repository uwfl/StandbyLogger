using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class LogEntry
    {
        public DateTime CreationDate { get; set; }
        public Informer Informer { get; set; }
        public DateTime TimeOfOccurrence { get; set; }

        public List<LogEntryActor> Actors { get; set; }
        public Failure OccurredFailure { get; set; }

        public bool FailureResolved { get; set; }
        public bool ServiceCompanyInvolved { get; set; }

        public LogEntry(DateTime creationDate, Informer informer, DateTime timeOfOccurence, Failure occuredFailure, bool failureResolved, bool serviceCompanyInvolved)
        {
            CreationDate = creationDate;
            Informer = informer;
            TimeOfOccurrence = timeOfOccurence;

            Actors = new List<LogEntryActor>();

            OccurredFailure = occuredFailure;
            FailureResolved = failureResolved;
            ServiceCompanyInvolved = serviceCompanyInvolved;
        }

        public LogEntry(DateTime creationDate, Informer informer, DateTime timeOfOccurence, List<LogEntryActor> actors, Failure occuredFailure, bool failureResolved, bool serviceCompanyInvolved)
            : this(creationDate, informer, timeOfOccurence, occuredFailure, failureResolved, serviceCompanyInvolved)
        {
            Actors.AddRange(actors);
        }
    }
}
