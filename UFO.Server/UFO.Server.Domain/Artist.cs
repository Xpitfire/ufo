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
    [DataContract(Name = nameof(Artist))]
    public class Artist : DomainObject
    {
        [DataMember(Name = nameof(ArtistId))]
        public virtual int ArtistId { get; set; } = Constants.InvalidIdValue;

        [DataMember(Name = nameof(Name))]
        public virtual string Name { get; set; }

        [RegularExpression(Constants.EMailRegex)]
        [DataMember(Name = nameof(EMail))]
        public virtual string EMail { get; set; }

        [DataMember(Name = nameof(Category))]
        public virtual Category Category { get; set; }

        [DataMember(Name = nameof(Country))]
        public virtual Country Country { get; set; }

        [DataMember(Name = nameof(Picture))]
        public virtual BlobData Picture { get; set; }

        [DataMember(Name = nameof(PromoVideo))]
        public virtual string PromoVideo { get; set; }

        public override string ToString()
        {
            return $"ArtistId: {ArtistId}, ArtistName: {Name}, ArtistEMail: {EMail}";
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var artist = obj as Artist;
            return artist != null 
                && ArtistId == artist.ArtistId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ArtistId;
                hashCode = (hashCode * 397) ^ (Name?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (EMail?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Category?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Country?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Picture?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (PromoVideo?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
        
    }
}
