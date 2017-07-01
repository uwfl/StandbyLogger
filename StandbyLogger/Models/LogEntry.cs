using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class LogEntry
    {
        public Informer Informer { get; set; }
        [XmlAttribute]
        public DateTime TimeOfOccurrence { get; set; }
        public List<LogEntryActor> Actors { get; set; }
        public Failure OccurredFailure { get; set; }

        public LogEntry()
        { }

        public LogEntry(Informer informer, DateTime timeOfOccurence, Failure occuredFailure)
        {
            Informer = informer;
            TimeOfOccurrence = timeOfOccurence;

            Actors = new List<LogEntryActor>();

            OccurredFailure = occuredFailure;
        }

        public LogEntry(Informer informer, DateTime timeOfOccurence, List<LogEntryActor> actors, Failure occuredFailure)
            : this(informer, timeOfOccurence, occuredFailure)
        {
            Actors.AddRange(actors);
        }
    }
}
