using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Provider.Impl;

namespace FH.SEv.UFO.Server.Provider
{
    public sealed class DaoProviderFactories
    {
        public static IDaoProviderFactory GetFactory(string providerName)
        {
            return ProviderUtility.LoadClass<IDaoProviderFactory>(providerName);
        }
    }
}
