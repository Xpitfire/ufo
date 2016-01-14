using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Common
{
    public abstract class AProviderSettings
    {
        public abstract string ProviderAssemblyName { get; }
        public abstract string ProviderNamespace { get; }
        public abstract string ProviderClassName { get; }
    }
}
