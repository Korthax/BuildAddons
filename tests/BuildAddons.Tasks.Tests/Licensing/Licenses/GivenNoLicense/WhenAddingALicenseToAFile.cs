using BuildAddons.Tasks.Licensing.Licenses;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenNoLicense
{
    [TestFixture]
    public class WhenAddingALicenseToAFile
    {
        [Test]
        public void ThenTheFileIsUnchanged()
        {
            string[] file =
            {
                "// License text",
                "using BuildAddons.Tasks.License.Licenses;"
            };

            var subject = UnknownLicense.From(file);
            var result = subject.AddTo(new[] { "using NUnit.Framework;" });

            Assert.That(result, Is.EqualTo(new[] { "using NUnit.Framework;" }));
        }
    }
}