using System.IO;
using BuildAddons.Tasks.Helpers.Files;

namespace BuildAddons.Tasks.Licensing.Source
{
    public interface ISourceFileWriter
    {
        void WriteAllLines(string[] lines);
    }

    public class SourceFileWriter : ISourceFileWriter
    {
        private readonly IFileWriter _fileWriter;
        private readonly FileInfo _file;

        public SourceFileWriter(FileInfo file, IFileWriter fileWriter)
        {
            _file = file;
            _fileWriter = fileWriter;
        }

        public void WriteAllLines(string[] lines)
        {
            _fileWriter.WriteAllLines(_file.FullName, lines);
        }
    }
}