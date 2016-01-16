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
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace UFO.Server.Domain
{
    [Serializable]
    [DataContract(Name = nameof(Performance))]
    public class Performance : DomainObject
    {
        [DataMember(Name = nameof(DateTime))]
        public virtual DateTime DateTime { get; set; }

        [DataMember(Name = nameof(Artist))]
        public virtual Artist Artist { get; set; }

        [DataMember(Name = nameof(Venue))]
        public virtual Venue Venue { get; set; }

        public override string ToString()
        {
            return $"DateTime: {DateTime.ToString(Constants.CommonDateFormatFull)}, Artist: ({Artist}), Venue: ({Venue})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var performance = obj as Performance;
            return performance != null
                && DateTime == performance.DateTime
                && Equals(Artist, performance.Artist)
                && Equals(Venue, performance.Venue);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = DateTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (Artist?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Venue?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
