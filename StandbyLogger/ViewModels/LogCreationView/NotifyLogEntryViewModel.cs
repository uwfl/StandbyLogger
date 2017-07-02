using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.ViewModels.LogCreationView
{
    public class NotifyLogEntryViewModel : BaseViewModel
    {
        public LogEntry LogEntry { get; private set; }
        public RelayCommand SendLogEntryAsMailCommand { get; set; }

        public NotifyLogEntryViewModel()
        {
            SendLogEntryAsMailCommand = new RelayCommand(c => SendLogEntryAsMail(), c => true);
        }

        public void SetLogEntry(LogEntry logEntry)
        {
            LogEntry = logEntry;
        }
                
        private void SendLogEntryAsMail()
        {
            Utilities.OutlookHandler.SendEmail(LogEntry, new List<string>() { "martin.distler@gmail.com" });
        }
    }
}
