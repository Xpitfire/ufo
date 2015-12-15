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
using System.Runtime.Serialization;

namespace UFO.Server.Domain
{
    [Serializable]
    [DataContract(Name = nameof(Location))]
    public class Location : DomainObject
    {
        [DataMember(Name = nameof(LocationId))]
        public virtual int LocationId { get; set; } = Constants.InvalidIdValue;

        [DataMember(Name = nameof(Longitude))]
        public virtual decimal Longitude { get; set; } = Constants.InvalidGeoLocation;

        [DataMember(Name = nameof(Latitude))]
        public virtual decimal Latitude { get; set; } = Constants.InvalidGeoLocation;

        [DataMember(Name = nameof(Name))]
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return $"LocationId: {LocationId}, LocationName: {Name}, Longitude: {Longitude}, Latitude: {Latitude}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var location = obj as Location;
            return location != null
                && LocationId == location.LocationId
                && Name == location.Name
                && Longitude == location.Longitude
                && Latitude == location.Latitude;
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = LocationId;
                hashCode = (hashCode * 397) ^ Longitude.GetHashCode();
                hashCode = (hashCode * 397) ^ Latitude.GetHashCode();
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
