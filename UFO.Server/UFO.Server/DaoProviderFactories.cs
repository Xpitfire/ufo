using UFO.Server.Dal.Common;
using UFO.Server.Properties;

namespace UFO.Server
{
    public sealed class DaoProviderFactories
    {
        public static IDaoProviderFactory GetFactory(string assemblyName = null, string nameSpace = null, string providerName = null)
        {
            return ProviderUtility.LoadClass<IDaoProviderFactory>(
                assemblyName ?? Settings.Default.DaoProviderAssemblyName,
                nameSpace ?? Settings.Default.DaoProviderNameSpace,
                providerName ?? Settings.Default.DaoProviderClassName);
        }
    }
}
