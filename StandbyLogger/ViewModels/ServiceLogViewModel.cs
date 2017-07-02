using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels
{
    public class ServiceLogViewModel : BaseViewModel
    {
        public ServiceLog ServiceLog { get; private set; }

        public ServiceLogViewModel()
        {
            ServiceLog = new ServiceLog();
            ParseLogs();
        }
        
        public void AddLogEntry(LogEntry entry)
        {
            ServiceLog.Entries.Add(entry);
        }

        public void ParseLogs()
        {

            // Get all log files in log directory.
            var logFiles = Utilities.DirectoryUtilities.DirectorySearch(Utilities.Constants.PATH_LOGDIRECTORY);
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
                    AddLogEntry(entry);
                }
                catch (Exception)
                {
                    Console.WriteLine(string.Format("Could not deserialize file {0}.", logFile));
                    continue;
                }
            }
        }
    }
}
