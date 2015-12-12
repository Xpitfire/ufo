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
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Impl
{
    public class AdminAccessBll : AAdminAccessBll
    {
        public override List<User> GetAllUser(SessionToken token)
        {
            return IsUserAuthenticated(token) ? UserDao.SelectAll().ResultObject : null;
        }
        
        public override bool IsUserAuthenticated(SessionToken token)
        {
            return GetSession().GetUserFromSession(token)?.IsAdmin ?? false;
        }

        public override bool IsValidAdmin(SessionToken token)
        {
            return UserDao.VerifyAdminCredentials(token.User).ResultObject;
        }

        public override ISessionBll GetSession()
        {
            return SessionHandler.Instance;
        }
        
        public override void ModifyArtist(SessionToken token, Artist artist)
        {
            throw new NotImplementedException();
        }

        public override void RemoveArtist(SessionToken token, Artist artist)
        {
            throw new NotImplementedException();
        }

        public override void ModifyVenue(SessionToken token, Venue venue)
        {
            throw new NotImplementedException();
        }

        public override void RemoveVenue(SessionToken token, Venue venue)
        {
            throw new NotImplementedException();
        }

        public override void ModifyPerformance(SessionToken token, Performance performance)
        {
            throw new NotImplementedException();
        }

    }
}
