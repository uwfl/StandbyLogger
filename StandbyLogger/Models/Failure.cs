using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StandbyLogger.Models
{
    public class Failure
    {
        [XmlAttribute]
        public string Type { get; set; }
        [XmlAttribute]
        public DateTime TimeOfOccurrence { get; set; }
        public string ActionsTaken { get; set; }
        public bool Resolved { get; set; }
        public bool ServiceCompanyInvolved { get; set; }

        public Failure()
        { }

        public Failure(string type, DateTime timeOfOccurrence, string actionsTaken, bool resolved, bool serviceCompanyInvolved)
        {
            Type = type;
            TimeOfOccurrence = timeOfOccurrence;
            ActionsTaken = actionsTaken;
            Resolved = resolved;
            ServiceCompanyInvolved = serviceCompanyInvolved;
        }
    }
}
