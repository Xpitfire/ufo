﻿#region copyright
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
using System;
using System.Runtime.Serialization;

namespace UFO.Server.Domain
{
    [Serializable]
    [DataContract(Name = nameof(Country))]
    public class Country : DomainObject
    {
        [DataMember(Name = nameof(Code))]
        public virtual string Code { get; set; }

        [DataMember(Name = nameof(Name))]
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return $"CountryCode: {Code}, CountryName: {Name}";
        }

        public override bool Equals(object obj)
        {
            var country = obj as Country;
            return country != null
                && Code == country.Code;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Code?.GetHashCode() ?? 0) * 397) ^ (Name?.GetHashCode() ?? 0);
            }
        }

    }
}
