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
using BLL = UFO.Server.Domain;
using WS = UFO.Services.AdminAccess;

namespace UFO.Commander.Proxy
{
    class AdminAccessProxy : IAdminAccessBll
    {
        private readonly WS.AdminAccessWs _adminAccessWs = new WS.AdminAccessWsClient();
        
        public List<BLL.User> GetUser(BLL.SessionToken token, BLL.PagingData page)
        {
            var result = _adminAccessWs.GetUser(
                token.ToWebSeriveObject<WS.SessionToken>(), 
                page.ToWebSeriveObject<WS.PagingData>());
            return ProxyHelper.ToListOf<WS.User, BLL.User>(result);
        }

        public BLL.PagingData RequestUserPagingData(BLL.SessionToken token)
        {
            return _adminAccessWs.RequestUserPagingData(
                token.ToWebSeriveObject<WS.SessionToken>()).ToDomainObject<BLL.PagingData>();
        }

        public bool IsUserAuthenticated(BLL.SessionToken token)
        {
            return _adminAccessWs.IsUserAuthenticated(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public bool IsValidAdmin(BLL.SessionToken token)
        {
            return _adminAccessWs.IsValidAdmin(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public bool LoginAdmin(BLL.SessionToken token)
        {
            return _adminAccessWs.LoginAdmin(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public void LogoutAdmin(BLL.SessionToken token)
        {
            _adminAccessWs.LogoutAdmin(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public BLL.SessionToken RequestSessionToken(BLL.User user)
        {
            var result = _adminAccessWs.RequestSessionToken(user.ToWebSeriveObject<WS.User>());
            return result.ToDomainObject<BLL.SessionToken>();
        }

        public bool ModifyArtist(BLL.SessionToken token, BLL.Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return _adminAccessWs.ModifyArtist(tokenWs, artistWs);
        }

        public bool RemoveArtist(BLL.SessionToken token, BLL.Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return _adminAccessWs.RemoveArtist(tokenWs, artistWs);
        }

        public bool ModifyVenue(BLL.SessionToken token, BLL.Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return _adminAccessWs.ModifyVenue(tokenWs, venueWs);
        }

        public bool RemoveVenue(BLL.SessionToken token, BLL.Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return _adminAccessWs.RemoveVenue(tokenWs, venueWs);
        }

        public bool ModifyPerformance(BLL.SessionToken token, BLL.Performance performance)
        {
            var performanceWs = performance.ToWebSeriveObject<WS.Performance>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return _adminAccessWs.ModifyPerformance(tokenWs, performanceWs);
        }
        
    }
}
