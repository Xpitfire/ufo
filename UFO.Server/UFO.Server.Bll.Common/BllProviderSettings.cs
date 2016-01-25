using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Common;
using UFO.Server.Common.Properties;

namespace UFO.Server.Bll.Common
{
    public sealed class BllProviderSettings : AProviderSettings
    {
        public override string ProviderAssemblyName { get; } = Settings.Default.BllProviderAssemblyName;
        public override string ProviderNamespace { get; } = Settings.Default.BllProviderNameSpace;
        public override string ProviderClassName { get; } = Settings.Default.BllProviderClassName;

        private BllProviderSettings() {}

        private static BllProviderSettings _instance;
        public static BllProviderSettings Instance => _instance ?? (_instance = new BllProviderSettings());
    }
}
