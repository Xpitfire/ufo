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
using System.Collections.Generic;
using System.ServiceModel;
using UFO.Server.Bll.Impl;
using UFO.Server.Domain;

namespace UFO.Server.Services
{
    [ServiceContract]
    public class AdminAccessWs : AdminAccessBll
    {
        [OperationContract]
        public override List<User> GetAllUser(SessionToken token)
        {
            return base.GetAllUser(token);
        }

        [OperationContract]
        public override bool IsUserAuthenticated(SessionToken token)
        {
            return base.IsUserAuthenticated(token);
        }

        [OperationContract]
        public override bool IsValidAdmin(SessionToken token)
        {
            return base.IsValidAdmin(token);
        }

        [OperationContract]
        public override bool LoginAdmin(SessionToken token)
        {
            return base.LoginAdmin(token);
        }

        [OperationContract]
        public override void LogoutAdmin(SessionToken token)
        {
            base.LogoutAdmin(token);
        }

        [OperationContract]
        public override SessionToken RequestSessionToken(User user)
        {
            return base.RequestSessionToken(user);
        }

        [OperationContract]
        public override void ModifyArtist(SessionToken token, Artist artist)
        {
            base.ModifyArtist(token, artist);
        }

        [OperationContract]
        public override void RemoveArtist(SessionToken token, Artist artist)
        {
            base.RemoveArtist(token, artist);
        }

        [OperationContract]
        public override void ModifyVenue(SessionToken token, Venue venue)
        {
            base.ModifyVenue(token, venue);
        }

        [OperationContract]
        public override void RemoveVenue(SessionToken token, Venue venue)
        {
            base.RemoveVenue(token, venue);
        }

        [OperationContract]
        public override void ModifyPerformance(SessionToken token, Performance performance)
        {
            base.ModifyPerformance(token, performance);
        }
    }
}
