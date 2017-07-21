using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Interfaces
{
    public interface IServiceLog
    {
        IEnumerable<LogEntry> GetEntries();
        void ParseLogs(string path);
        void AddLogEntry(LogEntry entry);
    }
}
