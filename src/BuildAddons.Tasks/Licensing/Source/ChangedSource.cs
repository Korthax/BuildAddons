using BuildAddons.Tasks.Licensing.Licenses;

namespace BuildAddons.Tasks.Licensing.Source
{
    public class ChangedSource : ISource
    {
        private readonly ISourceFileWriter _fileWriter;
        private readonly ILicense _fileLicense;
        private readonly string[] _file;

        public ChangedSource(string[] file, ILicense fileLicense, ISourceFileWriter fileWriter)
        {
            _file = file;
            _fileLicense = fileLicense;
            _fileWriter = fileWriter;
        }

        public ISource Add(ILicense license)
        {
            var cleanedFiled = _fileLicense.RemoveFrom(_file);
            return new ChangedSource(license.AddTo(cleanedFiled), license, _fileWriter);
        }

        public void WriteAllLines()
        {
            _fileWriter.WriteAllLines(_file);
        }
    }
}