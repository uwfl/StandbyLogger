using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandbyLogger.Utilities
{
    public static class DirectoryUtilities
    {
        public static List<string> DirectorySearch(string directory)
        {
            var results = new List<string>();
            DirectorySearch(directory, new List<string>(), results);

            return results;
        }

        public static List<string> DirectorySearch(string directory, List<string> ignoredDirectories)
        {
            var results = new List<string>();
            DirectorySearch(directory, ignoredDirectories, results);

            return results;
        }

        private static List<string> DirectorySearch(string directory, List<string> ignoredDirectories, List<string> results)
        {
            if (ignoredDirectories.Any(d => directory.EndsWith(d)))
                return results;

            try
            {
                foreach (string subDirectory in Directory.GetDirectories(directory))
                {
                    DirectorySearch(subDirectory, ignoredDirectories, results);
                }

                foreach (string f in Directory.GetFiles(directory))
                {
                    results.Add(f);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while searching files in directory. See inner exception", ex);
            }

            return results;
        }
    }
}
