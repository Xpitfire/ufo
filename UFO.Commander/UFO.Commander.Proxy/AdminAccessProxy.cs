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
using UFO.Server.Bll.Common;
using VM = UFO.Commander.Domain;
using BLL = UFO.Server.Domain;
using WS = UFO.Services.AdminAccess;

namespace UFO.Commander.Proxy
{
    class AdminAccessProxy : IAdminAccessBll
    {
        private readonly WS.AdminAccessWs _adminAccessWs = new WS.AdminAccessWsClient();

        public List<BLL.User> GetAllUser(BLL.SessionToken token)
        {
            var result = _adminAccessWs.GetAllUser(token.ToWebSeriveObject<WS.SessionToken>());
            return ProxyHelper.ToListOf<WS.User, BLL.User>(result);
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

        public void ModifyArtist(BLL.SessionToken token, BLL.Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            _adminAccessWs.ModifyArtist(tokenWs, artistWs);
        }

        public void RemoveArtist(BLL.SessionToken token, BLL.Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            _adminAccessWs.RemoveArtist(tokenWs, artistWs);
        }

        public void ModifyVenue(BLL.SessionToken token, BLL.Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            _adminAccessWs.ModifyVenue(tokenWs, venueWs);
        }

        public void RemoveVenue(BLL.SessionToken token, BLL.Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            _adminAccessWs.RemoveVenue(tokenWs, venueWs);
        }

        public void ModifyPerformance(BLL.SessionToken token, BLL.Performance performance)
        {
            var performanceWs = performance.ToWebSeriveObject<WS.Performance>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            _adminAccessWs.ModifyPerformance(tokenWs, performanceWs);
        }
    }
}
