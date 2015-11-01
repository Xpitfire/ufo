using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FH.SEv.UFO.Server.Provider
{
    sealed class ProviderUtility
    {
        public static T LoadClass<T>(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType(className);
            if (type != null)
            {
                var obj = Activator.CreateInstance(type);
                if (obj is T)
                    return (T) obj;
            }
            throw new SettingsPropertyNotFoundException($"Unsupported class load! Expected type: {typeof(T).Name}");
        }
    }
}
