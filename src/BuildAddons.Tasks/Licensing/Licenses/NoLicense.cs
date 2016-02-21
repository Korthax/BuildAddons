namespace BuildAddons.Tasks.Licensing.Licenses
{
    public class NoLicense : ILicense
    {
        public string[] AddTo(string[] file)
        {
            return file;
        }

        public string[] RemoveFrom(string[] file)
        {
            return file;
        }
    }
}