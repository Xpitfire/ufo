using System;
using System.Configuration;
using System.Reflection;

namespace UFO.Server
{
    sealed class ProviderUtility
    {
        public static T LoadClass<T>(string assemblyName, string nameSpace, string className)
        {
            var assembly = Assembly.Load(assemblyName);
            var type = assembly.GetType($"{nameSpace}.{className}");
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
