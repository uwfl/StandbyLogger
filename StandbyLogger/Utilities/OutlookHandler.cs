using NetOffice.OutlookApi;
using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Utilities
{
    public static class OutlookHandler
    {
        public static bool SendEmail(LogEntry logEntry, List<string> To)
        {
            return SendEmail(logEntry, To, new List<string>(), new List<string>());
        }

        public static bool SendEmail(LogEntry logEntry, List<string> To, List<string> Cc)
        {
            return SendEmail(logEntry, To, Cc, new List<string>());
        }

        public static bool SendEmail(LogEntry logEntry, List<string> To, List<string> Cc, List<string> Bcc)
        {
            // Start outlook.
            Application outlookApplication = new NetOffice.OutlookApi.Application();

            // Create new mail.
            MailItem mailItem = outlookApplication.CreateItem(NetOffice.OutlookApi.Enums.OlItemType.olMailItem) as MailItem;

            // Prepare Item and send.
            mailItem.To = string.Join(", ", To);
            mailItem.CC = string.Join(", ", Cc);
            mailItem.BCC = string.Join(", ", Bcc);

            mailItem.Subject = "Notdiensteinsatz " + logEntry.TimeOfOccurrence.ToShortDateString() + " (Störungsstatus: " + (logEntry.OccurredFailure.Resolved ? "behoben" : "OFFEN") + ")";
            mailItem.Body = "Siehe Notdiensteinsatz-Daten weiter unten.";
            mailItem.Display();

            // Dispose outlook handle.
            outlookApplication.Dispose();

            return true;
        }
    }
}
