using System;
using BuildAddons.Tasks.Helpers.Files;
using BuildAddons.Tasks.Licensing.Licenses;
using Moq;
using NUnit.Framework;

namespace BuildAddons.Tasks.Tests.Licensing.Licenses.GivenANewLicense
{
    [TestFixture]
    public class WhenRemovingTheLicenseFromAFile
    {
        [Test]
        public void ThenTheLicenseIsRemovedFromTheSourceCode()
        {
            string[] license =
            {
                "License text",
            };

            var file = new[]
            {
                "// ******************** Last Updated: 2016/02/21 14:38:00.00 *********************",
                "// License text",
                "// *********************************************************************************",
                "",
                "using NUnit.Framework;"
            };

            var fileInfo = new Mock<IFileInfo>();
            fileInfo.Setup(x => x.LastWriteTimeUtc).Returns(new DateTimeOffset(new DateTime(2016, 02, 21, 14, 38, 00)));

            var subject = License.NewFrom(fileInfo.Object, license);
            var result = subject.RemoveFrom(file);

            Assert.That(result, Is.EqualTo(new[] { "using NUnit.Framework;" }));
        }
    }
}