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
        public static bool SendEmail(LogEntry logEntry, List<string> To, List<string> attachments)
        {
            return SendEmail(logEntry, To, new List<string>(), new List<string>(), attachments);
        }

        public static bool SendEmail(LogEntry logEntry, List<string> To, List<string> Cc, List<string> attachments)
        {
            return SendEmail(logEntry, To, Cc, new List<string>(), attachments);
        }

        public static bool SendEmail(LogEntry logEntry, List<string> To, List<string> Cc, List<string> Bcc, List<string> attachments)
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

            // Add attachments and add them as inline.
            Attachment atm;
            string imageCid;
            List<string> imageCids = new List<string>();
            int counter = 1;
            foreach (var attachment in attachments)
            {
                atm = mailItem.Attachments.Add(attachment, NetOffice.OutlookApi.Enums.OlAttachmentType.olEmbeddeditem);
                //imageCid = System.IO.Path.GetFileName(attachment) + "@" + counter;
                //atm.PropertyAccessor.SetProperties("http://schemas.microsoft.com/mapi/proptag/0x3712001E", imageCid);

                //imageCids.Add(imageCid);
                //counter++;
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<body>");
            sb.AppendLine("Sehr geehrte Herren / Damen,");
            sb.AppendLine("\nHiermit sende ich Ihnen die Notdienstbenachrichtigung als Anhang zu.");
            //foreach (var imageIds in imageCids)
            //{
            //    sb.AppendLine(string.Format("<img src=\"cid:{0}\">", imageIds));
            //}
            sb.AppendLine("</body>");

            mailItem.HTMLBody = sb.ToString();

            // Display the send email window.
            mailItem.Display();

            // Dispose outlook handle.
            outlookApplication.Dispose();

            return true;
        }
    }
}
