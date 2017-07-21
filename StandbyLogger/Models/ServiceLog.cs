using StandbyLogger.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Models
{
    public class ServiceLog : IServiceLog
    {
        public ObservableCollection<LogEntry> Entries { get; set; }

        public ServiceLog()
        {
            Entries = new ObservableCollection<LogEntry>();
            ParseLogs();
        }

        public IEnumerable<LogEntry> GetEntries()
        {
            return Entries;
        }

        public void ParseLogs()
        {
            ParseLogs(Utilities.Constants.PATH_LOGDIRECTORY);
        }

        public void ParseLogs(string path)
        {
            // Get all log files in log directory.
            var logFiles = Utilities.DirectoryUtilities.DirectorySearch(path);
            logFiles = logFiles.Where(l => System.IO.Path.GetFileName(l).StartsWith("log_")).ToList();

            // Deserialize each log file and add it to the servicelog.
            LogEntry entry;
            foreach (var logFile in logFiles)
            {
                try
                {
                    // Deseralize log file.
                    entry = Utilities.SerializingHelper.Deserialize<LogEntry>(logFile);

                    // Add to entries list.
                    Entries.Add(entry);
                }
                catch (Exception)
                {
                    Console.WriteLine(string.Format("Could not deserialize file {0}.", logFile));
                    continue;
                }
            }
        }

        public void AddLogEntry(LogEntry entry)
        {
            Entries.Add(entry);
        }
    }
}
