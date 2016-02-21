using System.Collections.Generic;

namespace BuildAddons.Tasks.Licensing.Licenses
{
    public class UnknownLicense : ILicense
    {
        private readonly List<string> _license;

        public static UnknownLicense From(string[] file)
        { 
            var license = new List<string>();
            foreach(var line in file)
            {
                license.Add(line);
                if(!line.StartsWith("//"))
                    break;
            }

            return new UnknownLicense(license);
        }

        private UnknownLicense(List<string> license)
        {
            _license = license;
        }

        public static bool ContainedWithin(string[] allLines)
        {
            return allLines != null && allLines.Length > 0 && allLines[0].StartsWith("//");
        }

        public string[] AddTo(string[] file)
        {
            return file;
        }

        public string[] RemoveFrom(string[] file)
        {
            var result = new string[file.Length - _license.Count];
            for (var i = 0; i < result.Length; i++)
                result[i] = file[i + _license.Count];
            return result;
        }
    }
}