using System;
using BuildAddons.Tasks.Helpers.Files;
using BuildAddons.Tasks.Licensing.Licenses;
using Moq;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenANewLicense
{
    [TestFixture]
    public class WhenAddingALicenseToAFile
    {
        [Test]
        public void ThenTheLicenseIsAddedBeforeTheSourceCode()
        {
            string[] file =
            {
                "License text",
            };

            var fileInfo = new Mock<IFileInfo>();
            fileInfo.Setup(x => x.LastWriteTimeUtc).Returns(new DateTimeOffset(new DateTime(2016, 02, 21, 14, 38, 00)));

            var subject = License.NewFrom(fileInfo.Object, file);
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