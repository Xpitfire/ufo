using UFO.Server.Common;
using UFO.Server.Common.Properties;

namespace UFO.Server.Dal.Common
{
    public class DaoProviderSettings : AProviderSettings
    {
        public override string ProviderAssemblyName { get; } = Settings.Default.DaoProviderAssemblyName;
        public override string ProviderNamespace { get; } = Settings.Default.DaoProviderNameSpace;
        public override string ProviderClassName { get; } = Settings.Default.DaoProviderClassName;
        
        private DaoProviderSettings() {}

        private static DaoProviderSettings _instance;
        public static DaoProviderSettings Instance => _instance ?? (_instance = new DaoProviderSettings());
    }
}
