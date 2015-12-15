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
    [DataContract(Name = nameof(BlobData))]
    public class BlobData : DomainObject
    {
        
        [DataMember(Name = nameof(Name))]
        public virtual string Name { get; set; }

        [DataMember(Name = nameof(Path))]
        public virtual string Path { get; set; }

        [DataMember(Name = nameof(DataStream))]
        public virtual byte[] DataStream { get; set; }
       
        public override string ToString()
        {
            return $"BlobDataName: {Name}, BlobDataPath: {Path}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var other = obj as BlobData;
            return other != null 
                && string.Equals(Name, other.Name) 
                && string.Equals(Path, other.Path) 
                && Equals(DataStream, other.DataStream);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (Path?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (DataStream?.GetHashCode() ?? 0);
                return hashCode;
            }
        }
    }
}
