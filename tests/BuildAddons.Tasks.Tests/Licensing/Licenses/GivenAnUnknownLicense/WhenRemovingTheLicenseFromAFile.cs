using BuildAddons.Tasks.Licensing.Licenses;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenAnUnknownLicense
{
    [TestFixture]
    public class WhenRemovingTheLicenseFromAFile
    {
        [Test]
        public void ThenTheLicenseIsRemovedFromTheSourceCode()
        {
            string[] file =
            {
                "// License text",
                "",
                "using BuildAddons.Tasks.License.Licenses;"
            };

            var subject = UnknownLicense.From(file);
            var result = subject.RemoveFrom(file);

            Assert.That(result, Is.EqualTo(new[] { "using BuildAddons.Tasks.License.Licenses;" }));
        }
    }
}