using BuildAddons.Tasks.Licensing.Licenses;
using BuildAddons.Tasks.Licensing.Source;
using Moq;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.SourceFiles.GivenChangedSourceCode
{
    [TestFixture]
    public class WhenAddingALicense
    {
        private Mock<ILicense> _existingLicense;
        private Mock<ILicense> _newLicense;
        private ISource _result;
        private string[] _file;

        [SetUp]
        public void SetUp()
        {
            _file = new [] { "Console.WriteLine()" };
            
            _existingLicense = new Mock<ILicense>();
            _existingLicense.Setup(x => x.RemoveFrom(_file)).Returns(_file);

            _newLicense = new Mock<ILicense>();
            _newLicense.Setup(x => x.AddTo(_file)).Returns(_file);
            
            var subject = new ChangedSource(_file, _existingLicense.Object, null);
            _result = subject.Add(_newLicense.Object);
        }

        [Test]
        public void ThenTheSourceCodeIsStillChanged()
        {
            Assert.That(_result, Is.TypeOf<ChangedSource>());
        }

        [Test]
        public void ThenTheExistingLicenseIsRemovedFromTheSource()
        {
            _existingLicense.Verify(x => x.RemoveFrom(_file), Times.Once);
        }

        [Test]
        public void ThenTheNewLicenseIsAddedToTheSource()
        {
            _newLicense.Verify(x => x.AddTo(_file), Times.Once);
        }
    }
}