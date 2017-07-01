using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class ServiceLog
    {
        public List<LogEntry> Entries { get; set; }

        public ServiceLog()
        {
            Entries = new List<LogEntry>();
        }
    }
}
