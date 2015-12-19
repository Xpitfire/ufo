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
    [DataContract(Name = nameof(User))]
    public class User : DomainObject
    {
        [DataMember(Name = nameof(UserId))]
        public virtual int UserId { get; set; } = Constants.InvalidIdValue;

        [DataMember(Name = nameof(FirstName))]
        public virtual string FirstName { get; set; }

        [DataMember(Name = nameof(LastName))]
        public virtual string LastName { get; set; }

        [RegularExpression(Constants.EMailRegex)]
        [DataMember(Name = nameof(EMail))]
        public virtual string EMail { get; set; }

        [DataMember(Name = nameof(Password))]
        public virtual string Password { get; set; }

        [DataMember(Name = nameof(IsAdmin))]
        public virtual bool IsAdmin { get; set; }

        [DataMember(Name = nameof(IsArtist))]
        public virtual bool IsArtist { get; set; }

        [DataMember(Name = nameof(Artist))]
        public virtual Artist Artist { get; set; }

        public override string ToString()
        {
            return $"UserId: {UserId}, FirstName: {FirstName}, LastName: {LastName}, UserEMail: {EMail}, Artist: ({Artist})";
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var user = obj as User;
            return user != null
                && EMail == user.EMail
                && Password == user.Password;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = UserId;
                hashCode = (hashCode * 397) ^ (FirstName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (LastName?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (EMail?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Password?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ IsAdmin.GetHashCode();
                hashCode = (hashCode * 397) ^ IsArtist.GetHashCode();
                hashCode = (hashCode * 397) ^ (Artist?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

    }
}
