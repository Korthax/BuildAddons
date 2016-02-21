using BuildAddons.Tasks.Licensing.Source;
using Moq;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.SourceFiles.GivenUnchangedSourceCode
{
    [TestFixture]
    public class WhenWritingTheFile
    {
        private Mock<ISourceFileWriter> _fileWriter;

        [SetUp]
        public void SetUp()
        {
            _fileWriter = new Mock<ISourceFileWriter>();
            var subject = new UnchangedSource(new [] { "Console.WriteLine()" }, null, _fileWriter.Object);
            subject.WriteAllLines();
        }

        [Test]
        public void ThenNothingIsWritten()
        {
            _fileWriter.Verify(x => x.WriteAllLines(It.IsAny<string[]>()), Times.Never);
        }
    }
}