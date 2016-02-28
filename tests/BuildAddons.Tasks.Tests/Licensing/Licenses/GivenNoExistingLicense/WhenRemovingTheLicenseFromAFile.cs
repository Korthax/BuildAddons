using BuildAddons.Tasks.Licensing.Licenses;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenNoExistingLicense
{
    [TestFixture]
    public class WhenRemovingTheLicenseFromAFile
    {
        [Test]
        public void ThenTheLicenseIsRemovedFromTheSourceCode()
        {
            string[] file =
            {
                "using BuildAddons.Tasks.License.Licenses;"
            };

            var subject = new NoLicense();
            var result = subject.RemoveFrom(file);

            Assert.That(result, Is.EqualTo(new[] { "using BuildAddons.Tasks.License.Licenses;" }));
        }
    }
}