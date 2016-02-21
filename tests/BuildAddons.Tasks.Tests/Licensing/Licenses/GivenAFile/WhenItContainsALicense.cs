using BuildAddons.Tasks.Helpers.Files;
using BuildAddons.Tasks.Licensing.Licenses;
using Moq;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenAFile
{
    [TestFixture]
    public class WhenItContainsALicense
    {
        [Test]
        public void ThenTheCorrectNoLicenseIsCreated()
        {
            string[] file =
            {
                "// ******************** Last Updated:  *********************",
                "using BuildAddons.Tasks.License.Licenses;"
            };

            var subject = new LicenseFactory(new Mock<IFileReader>().Object);
            var result = subject.For(file);
            Assert.That(result, Is.TypeOf<License>());
        }
    }
}