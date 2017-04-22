using System;
using System.IO;

namespace BuildAddons.Tasks.Helpers.Files
{
    public interface IFileInfo
    {
        DateTimeOffset LastWriteTimeUtc { get; }
    }

    public class FileInfoContainer : IFileInfo
    {
        public DateTimeOffset LastWriteTimeUtc => _fileInfo.LastWriteTimeUtc;
        private readonly FileInfo _fileInfo;

        public FileInfoContainer(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
    }
}