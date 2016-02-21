namespace BuildAddons.Tasks.Licensing.Licenses
{
    public interface ILicense
    {
        string[] AddTo(string[] file);
        string[] RemoveFrom(string[] file);
    }
}