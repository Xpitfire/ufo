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
        public override List<User> GetUser(SessionToken token, PagingData page)
        {
            return base.GetUser(token, page);
        }

        [OperationContract]
        public override PagingData RequestUserPagingData(SessionToken token)
        {
            return base.RequestUserPagingData(token);
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
        public override bool ModifyArtist(SessionToken token, Artist artist)
        {
            return base.ModifyArtist(token, artist);
        }

        [OperationContract]
        public override bool RemoveArtist(SessionToken token, Artist artist)
        {
            return base.RemoveArtist(token, artist);
        }

        [OperationContract]
        public override bool ModifyVenue(SessionToken token, Venue venue)
        {
            return base.ModifyVenue(token, venue);
        }

        [OperationContract]
        public override bool RemoveVenue(SessionToken token, Venue venue)
        {
            return base.RemoveVenue(token, venue);
        }

        [OperationContract]
        public override bool ModifyPerformance(SessionToken token, Performance performance)
        {
            return base.ModifyPerformance(token, performance);
        }
    }
}
