using StandbyLogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace StandbyLogger.ViewModels.LogCreationView
{
    public class NotifyLogEntryViewModel : BaseViewModel
    {
        public LogEntry LogEntry { get; private set; }
        public RelayCommand SendLogEntryAsMailCommand { get; set; }

        public NotifyLogEntryViewModel()
        {
            SendLogEntryAsMailCommand = new RelayCommand(c => SendLogEntryAsMail(c), c => true);
        }

        public void SetLogEntry(LogEntry logEntry)
        {
            LogEntry = logEntry;
        }

        private void SendLogEntryAsMail(object sender)
        {
            // Get the image.
            UserControls.LogEntry entryVisual = sender as UserControls.LogEntry;
            string filename = Path.Combine(Utilities.Constants.PATH_FILEDIRECTORY, "tmpLogEntry.bmp");

            // Save the image.
            SaveImage(entryVisual, (int)entryVisual.ActualWidth, (int)entryVisual.ActualHeight, filename);

            // Create the email.
            Utilities.OutlookHandler.SendEmail(LogEntry, new List<string>(), new List<string>() { filename });
        }

        public void SaveImage(Visual visual, int width, int height, string filePath)
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
            bitmap.Render(visual);

            PngBitmapEncoder image = new PngBitmapEncoder();
            image.Frames.Add(BitmapFrame.Create(bitmap));
            using (Stream fs = File.Create(filePath))
            {
                image.Save(fs);
            }
        }
    }
}
