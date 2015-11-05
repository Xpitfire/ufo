using FH.SEv.UFO.Server.Properties;

namespace FH.SEv.UFO.Server.Provider
{
    public sealed class DaoProviderFactories
    {
        public static IDaoProviderFactory GetFactory(string providerName = null)
        {
            return ProviderUtility.LoadClass<IDaoProviderFactory>(providerName ?? Settings.Default.DaoProviderName);
        }
    }
}
