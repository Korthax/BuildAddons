using System.IO;

namespace BuildAddons.Tasks.Helpers.Files
{
    public interface IFileWriter
    {
        void WriteAllLines(string fullName, string[] lines);
    }

    public class FileWriter : IFileWriter
    {
        public void WriteAllLines(string fullName, string[] lines)
        {
            File.WriteAllLines(fullName, lines);
        }
    }
}