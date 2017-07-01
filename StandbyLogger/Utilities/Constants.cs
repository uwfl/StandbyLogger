using System.Reflection;
using System.IO;

namespace StandbyLogger.Utilities
{
    public static class Constants
    {
        public static string APP_ROOT_DIR = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static string PATH_SETTINGS = Path.Combine(APP_ROOT_DIR, @"Files\Settings.xml");
        public static string PATH_LOGDIRECTORY = Path.Combine(APP_ROOT_DIR, @"Files\Logs\");
    }
}
