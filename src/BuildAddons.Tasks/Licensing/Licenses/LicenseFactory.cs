using System.IO;
using BuildAddons.Tasks.Helpers.Files;

namespace BuildAddons.Tasks.Licensing.Licenses
{
    public class LicenseFactory
    {
        private readonly IFileReader _fileReader;

        public LicenseFactory(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public ILicense For(string[] file)
        {
            if (License.ContainedWithin(file))
                return License.From(file);

            if (UnknownLicense.ContainedWithin(file))
                return UnknownLicense.From(file);

            return new NoLicense();
        }

        public ILicense For(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                return new NoLicense();

            var lines = _fileReader.ReadAllLines(fileInfo.FullName);
            return lines.Length == 0 ? new NoLicense() : License.From(fileInfo, lines);
        }
    }
}