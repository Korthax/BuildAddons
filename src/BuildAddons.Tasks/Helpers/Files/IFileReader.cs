using System.IO;

namespace BuildAddons.Tasks.Helpers.Files
{
    public interface IFileReader
    {
        string[] ReadAllLines(string fullName);
    }

    public class FileReader : IFileReader
    {
        public string[] ReadAllLines(string fullName)
        {
            return File.ReadAllLines(fullName);
        }
    }
}