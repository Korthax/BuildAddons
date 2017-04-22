using System.Collections.Generic;
using System.Linq;
using BuildAddons.Tasks.Helpers.Files;

namespace BuildAddons.Tasks.Licensing.Licenses
{
    public class License : ILicense
    {
        private const string Footer = "// *********************************************************************************";
        private const string HeaderStart = "// ******************** Last Updated: ";
        private const string HeaderEnd = " *********************";
        private const string Comment = "// ";

        private readonly List<string> _license;
        private readonly string _header;

        public static ILicense NewFrom(IFileInfo fileInfo, string[] license)
        {
            var completeLicense = new List<string> { $"{HeaderStart}{fileInfo.LastWriteTimeUtc:yyyy/MM/dd HH:mm:ss.ff}{HeaderEnd}" };
            completeLicense.AddRange(license.Select(x => $"{Comment}{x}"));
            completeLicense.Add(Footer);

            return new License(completeLicense[0], completeLicense);
        }

        public static License ExistingFrom(string[] file)
        { 
            var license = new List<string>();
            foreach(var line in file)
            {
                license.Add(line);
                if(line == Footer)
                    break;
            }

            return new License(file[0], license);
        }

        private License(string header, List<string> license)
        {
            _header = header;
            _license = license;
        }

        public static bool ContainedWithin(string[] allLines)
        {
            return allLines != null && allLines.Length > 0 && allLines[0].StartsWith(HeaderStart) && allLines[0].EndsWith(HeaderEnd);
        }

        public string[] AddTo(string[] file)
        {
            var result = new string[file.Length + _license.Count + 1];
            for (var i = 0; i < _license.Count; i++)
                result[i] = _license[i];
            
            result[_license.Count] = "";

            for (var i = 0; i < file.Length; i++)
                result[i + _license.Count + 1] = file[i];

            return result;
        }

        public string[] RemoveFrom(string[] file)
        {
            if(file[0] != _header)
                return file;

            var result = new List<string>();
            for (var i = _license.Count; i < file.Length; i++)
                result.Add(file[i]);

            return result.SkipWhile(string.IsNullOrWhiteSpace).ToArray();
        }
    }
}