#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
//     Wurm Florian
#endregion

using UFO.Server.Common.Properties;

namespace UFO.Server.Common
{
    public static class FactoryProvider
    {
        /// <summary>
        /// Creates a factory object at runtime, which provides methods for object creation.
        /// This is used to create loose coupling between assemblies using technology proprietary implementations
        /// and the business logic libraries.
        /// </summary>
        /// <param name="assemblyName">Name of the assebly to be loaded.</param>
        /// <param name="namespace">Namespace where the class is embedded.</param>
        /// <param name="providerName">Class name provider which will be instantiated.</param>
        /// <returns>Provider factory.</returns>
        public static T GetFactory<T>(string assemblyName, string @namespace, string providerName)
        {
            return ProviderUtility.LoadClass<T>(assemblyName, @namespace, providerName);
        }

        public static T GetFactory<T>(AProviderSettings providerSettings) 
            => GetFactory<T>(providerSettings.ProviderAssemblyName, providerSettings.ProviderNamespace, providerSettings.ProviderClassName);
    }
}
