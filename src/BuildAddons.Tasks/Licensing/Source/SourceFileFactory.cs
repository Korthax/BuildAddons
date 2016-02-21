using System.IO;
using BuildAddons.Tasks.Helpers.Files;
using BuildAddons.Tasks.Licensing.Licenses;

namespace BuildAddons.Tasks.Licensing.Source
{
    public class SourceFileFactory
    {
        private readonly LicenseFactory _licenseFactory;
        private readonly IFileReader _fileReader;
        private readonly IFileWriter _fileWriter;

        public SourceFileFactory(IFileReader fileReader, IFileWriter fileWriter, LicenseFactory licenseFactory)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
            _licenseFactory = licenseFactory;
        }

        public ISource From(FileInfo file)
        {
            var allLines = _fileReader.ReadAllLines(file.FullName);
            return new UnchangedSource(allLines, _licenseFactory.For(allLines), new SourceFileWriter(file, _fileWriter));
        }
    }
}