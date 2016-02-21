using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuildAddons.Tasks.Helpers.Files
{
    public static class FileFinder
    {
        public static List<FileInfo> Find(string rootDirectory, FileFinderOptions options)
        {
            var result = new List<FileInfo>();
            var directory = new DirectoryInfo(rootDirectory);
            Scan(directory, options, result);
            return result;
        }

        private static void Scan(DirectoryInfo sourceDirectory, FileFinderOptions options, ICollection<FileInfo> result)
        {
            if(!sourceDirectory.Exists)
                throw new Exception(string.Format("Source directory does not exist or could not be found: {0}", sourceDirectory));

            var fileInfos = new List<FileInfo>();
            foreach (var fileInfo in sourceDirectory.GetFiles())
            {
                var file = fileInfo;
                if (options.Excludes.Any(pattern => Matches(pattern, file.FullName)))
                    continue;

                fileInfos.Add(fileInfo);
            }

            var directoryInfos = sourceDirectory.GetDirectories();
            if ((!fileInfos.Any() && !directoryInfos.Any()) || options.Excludes.Any(pattern => Matches(pattern, sourceDirectory.FullName)))
                return;

            foreach (var subDirectory in directoryInfos)
                Scan(subDirectory, options, result);

            foreach (var file in fileInfos)
            {
                try
                {
                    var fileName = file.FullName;

                    if (options.Excludes.Any(pattern => Matches(pattern, fileName)))
                        continue;

                    if (options.Includes.Any(pattern => Matches(pattern, fileName)))
                        result.Add(file);
                }
                catch (Exception exception)
                {
                    throw new Exception(string.Format("{0} failed to scan: {1}", file.FullName, exception.Message));
                }
            }
        }

        private static bool Matches(string pattern, string text)
        {
            return text.EndsWith(pattern, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
