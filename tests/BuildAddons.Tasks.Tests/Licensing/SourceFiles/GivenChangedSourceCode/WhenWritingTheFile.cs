using BuildAddons.Tasks.Licensing.Source;
using Moq;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.SourceFiles.GivenChangedSourceCode
{
    [TestFixture]
    public class WhenWritingTheFile
    {
        private Mock<ISourceFileWriter> _fileWriter;
        private string[] _file;

        [SetUp]
        public void SetUp()
        {
            _file = new[] { "Console.WriteLine()" };
            _fileWriter = new Mock<ISourceFileWriter>();
            var subject = new ChangedSource(_file, null, _fileWriter.Object);
            subject.WriteAllLines();
        }

        [Test]
        public void ThenSourceCodeIsWrittenOut()
        {
            _fileWriter.Verify(x => x.WriteAllLines(_file), Times.Once);
        }
    }
}