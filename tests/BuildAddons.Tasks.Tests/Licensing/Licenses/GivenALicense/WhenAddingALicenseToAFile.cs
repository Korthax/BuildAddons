using BuildAddons.Tasks.Licensing.Licenses;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenALicense
{
    [TestFixture]
    public class WhenAddingALicenseToAFile
    {
        [Test]
        public void ThenTheLicenseIsAddedBeforeTheSourceCode()
        {
            string[] file =
            {
                "// ******************** Last Updated: 2016/02/21 14:38:00.00 *********************",
                "// License text",
                "// *********************************************************************************",
                "",
                "using BuildAddons.Tasks.License.Licenses;"
            };

            var subject = License.From(file);
            var result = subject.AddTo(new[] { "using NUnit.Framework;" });

            Assert.That(result, Is.EqualTo(
                new[]
                {
                    "// ******************** Last Updated: 2016/02/21 14:38:00.00 *********************",
                    "// License text",
                    "// *********************************************************************************",
                    "",
                    "using NUnit.Framework;"
                })
            );
        }
    }
}