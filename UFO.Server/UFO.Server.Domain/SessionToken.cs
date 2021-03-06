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
#endregion

using System;
using System.Runtime.Serialization;

namespace UFO.Server.Domain
{
    [Serializable]
    [DataContract(Name = nameof(SessionToken))]
    public class SessionToken : DomainObject
    {
        [DataMember(Name = nameof(SessionId))]
        public virtual char[] SessionId { get; set; }

        [DataMember(Name = nameof(User))]
        public virtual User User { get; set; }

        public override string ToString()
        {
            return new string(SessionId);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            var token = obj as SessionToken;
            return token != null && User != null
                && ToString().Equals(token.ToString())
                && User.Equals(token.User);
        }

        public override int GetHashCode()
        {
            return User?.GetHashCode() ?? 0;
        }
    }
}
