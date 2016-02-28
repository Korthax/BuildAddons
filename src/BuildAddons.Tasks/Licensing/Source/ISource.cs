using BuildAddons.Tasks.Licensing.Licenses;

namespace BuildAddons.Tasks.Licensing.Source
{
    public interface ISource
    {
        ISource Add(ILicense license);
        void WriteAllLines();
    }
}