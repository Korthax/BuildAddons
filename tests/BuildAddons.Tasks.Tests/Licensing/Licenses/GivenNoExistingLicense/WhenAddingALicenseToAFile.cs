using BuildAddons.Tasks.Licensing.Licenses;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenNoExistingLicense
{
    [TestFixture]
    public class WhenAddingALicenseToAFile
    {
        [Test]
        public void ThenTheFileIsUnchanged()
        {
            var subject = new NoLicense();
            var result = subject.AddTo(new[] { "using NUnit.Framework;" });

            Assert.That(result, Is.EqualTo(new[] { "using NUnit.Framework;" }));
        }
    }
}