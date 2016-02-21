using System;
using System.IO;
using BuildAddons.Tasks.Helpers.Files;
using BuildAddons.Tasks.Licensing.Licenses;
using BuildAddons.Tasks.Licensing.Source;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace BuildAddons.Tasks
{
    public class LicenseTask : Task
    {
        [Required]
        public string SourceDirectory { get; set; }

        [Required]
        public string LicenseFilePath { get; set; }

        private readonly SourceFileFactory _sourceFileFactory;
        private readonly LicenseFactory _licenseFactory;

        public LicenseTask()
        {
            _licenseFactory = new LicenseFactory(new FileReader());
            _sourceFileFactory = new SourceFileFactory(new FileReader(), new FileWriter(), _licenseFactory);
        }

        public override bool Execute()
        {
            try
            {
                var license = _licenseFactory.For(new FileInfo(LicenseFilePath));
                foreach (var fileInfo in FileFinder.Find(SourceDirectory, new FileFinderOptions { Includes = new[] { ".cs" }, Excludes = new[] { @"\bin", @"\obj" } }))
                {
                    _sourceFileFactory.From(fileInfo)
                        .Add(license)
                        .WriteAllLines();
                }
            }
            catch (Exception exception)
            {
                Log.LogErrorFromException(exception);
                return false;
            }

            return true;
        }
    }
}