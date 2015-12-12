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
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DomainObjectDomain = UFO.Server.Domain.DomainObject;
using DomainObjectAdminWs = UFO.Services.AdminAccess.DomainObject;
using DomainObjectViewWs = UFO.Services.ViewAccess.DomainObject;

namespace UFO.Commander.Proxy
{
    public static class ProxyExtensions
    {
        public static TTarget ToWebSeriveObject<TTarget>(this DomainObjectDomain domainObject)
        {
            return ProxyHelper.ToObjectOf<DomainObjectDomain, TTarget>(domainObject);
        }

        public static TTarget ToDomainObject<TTarget>(this DomainObjectAdminWs domainObject)
        {
            return ProxyHelper.ToObjectOf<DomainObjectAdminWs, TTarget>(domainObject);
        }

        public static TTarget ToDomainObject<TTarget>(this DomainObjectViewWs domainObject)
        {
            return ProxyHelper.ToObjectOf<DomainObjectViewWs, TTarget>(domainObject);
        }
    }

    public static class ProxyHelper
    {
        public static TTarget ToObjectOf<TSource, TTarget>(TSource source)
        {
            var targetType = typeof(TTarget);
            var targetProps = targetType.GetProperties();
            var obj = Activator.CreateInstance(targetType);

            foreach (var prop in targetProps)
            {
                var value = source
                    .GetType()
                    .GetProperty(prop.Name)?
                    .GetValue(source);

                if (value is DomainObjectDomain 
                    || value is DomainObjectAdminWs 
                    || value is DomainObjectViewWs)
                {
                    var methodType = typeof(ProxyHelper);
                    var method = methodType
                        .GetMethod(nameof(ToObjectOf), BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                        .MakeGenericMethod(value.GetType(), prop.PropertyType);
                    value = method.Invoke(null, new [] {value});
                }

                prop.SetValue(obj, value);
            }

            return (TTarget)obj;
        }

        public static TTarget[] ToArrayOf<TSource, TTarget>(TSource[] sourceArray)
        {
            if (sourceArray == null)
                return null;
            if (sourceArray.Length == 0)
                return new TTarget[0];

            var targetArray = new TTarget[sourceArray.Length];
            for (var i = 0; i < sourceArray.Length; i++)
            {
                targetArray[i] = ToObjectOf<TSource, TTarget>(sourceArray[i]);
            }

            return targetArray;
        }

        public static List<TTarget> ToListOf<TSource, TTarget>(List<TSource> sourceList)
        {
            var targetList = new List<TTarget>();
            sourceList.ForEach(elem => targetList.Add(ToObjectOf<TSource, TTarget>(elem)));
            return targetList;
        }

        public static TTarget[] ToArrayOf<TSource, TTarget>(List<TSource> sourceList)
        {
            return ToArrayOf<TSource, TTarget>(sourceList.ToArray());
        }

        public static List<TTarget> ToListOf<TSource, TTarget>(TSource[] sourceList)
        {
            return ToListOf<TSource, TTarget>(sourceList.ToList());
        }
        
    }
}
