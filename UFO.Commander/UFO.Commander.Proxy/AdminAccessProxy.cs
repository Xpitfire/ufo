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
    public class AdminAccessProxy : IAdminAccessBll
    {
        private static readonly WS.AdminAccessWs AdminAccessWs = new WS.AdminAccessWsClient();
        
        public List<BLL.User> GetUsers(BLL.SessionToken token, BLL.PagingData page)
        {
            var result = AdminAccessWs.GetUsers(
                token.ToWebSeriveObject<WS.SessionToken>(), 
                page.ToWebSeriveObject<WS.PagingData>());
            return ProxyHelper.ToListOf<WS.User, BLL.User>(result);
        }
        
        public BLL.PagingData RequestUserPagingData(BLL.SessionToken token)
        {
            return AdminAccessWs.RequestUserPagingData(
                token.ToWebSeriveObject<WS.SessionToken>()).ToDomainObject<BLL.PagingData>();
        }

        public List<BLL.User> SearchUsersPerKeyword(BLL.SessionToken token, string keyword)
        {
            var result = AdminAccessWs.SearchUsersPerKeyword(
                token.ToWebSeriveObject<WS.SessionToken>(), 
                keyword);
            return ProxyHelper.ToListOf<WS.User, BLL.User>(result);
        }

        public bool ModifyArtistRange(BLL.SessionToken token, List<BLL.Artist> artists)
        {
            var artistsWs = ProxyHelper.ToArrayOf<BLL.Artist, WS.Artist>(artists);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyArtistRange(tokenWs, artistsWs);
        }

        public bool IsUserAuthenticated(BLL.SessionToken token)
        {
            return AdminAccessWs.IsUserAuthenticated(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public bool IsValidAdmin(BLL.SessionToken token)
        {
            return AdminAccessWs.IsValidAdmin(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public bool LoginAdmin(BLL.SessionToken token)
        {
            return AdminAccessWs.LoginAdmin(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public void LogoutAdmin(BLL.SessionToken token)
        {
            AdminAccessWs.LogoutAdmin(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public BLL.SessionToken RequestSessionToken(BLL.User user)
        {
            var result = AdminAccessWs.RequestSessionToken(user.ToWebSeriveObject<WS.User>());
            return result.ToDomainObject<BLL.SessionToken>();
        }

        public bool ModifyArtist(BLL.SessionToken token, BLL.Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyArtist(tokenWs, artistWs);
        }

        public bool RemoveArtist(BLL.SessionToken token, BLL.Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.RemoveArtist(tokenWs, artistWs);
        }

        public bool ModifyVenueRange(BLL.SessionToken token, List<BLL.Venue> venues)
        {
            var venuesWs = ProxyHelper.ToArrayOf<BLL.Venue, WS.Venue>(venues);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyVenueRange(tokenWs, venuesWs);
        }

        public bool ModifyVenue(BLL.SessionToken token, BLL.Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyVenue(tokenWs, venueWs);
        }

        public bool RemoveVenue(BLL.SessionToken token, BLL.Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.RemoveVenue(tokenWs, venueWs);
        }

        public bool ModifyPerformanceRange(BLL.SessionToken token, List<BLL.Performance> performances)
        {
            var performancesWs = ProxyHelper.ToArrayOf<BLL.Performance, WS.Performance>(performances);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyPerformanceRange(tokenWs, performancesWs);
        }

        public bool ModifyPerformance(BLL.SessionToken token, BLL.Performance performance)
        {
            var performanceWs = performance.ToWebSeriveObject<WS.Performance>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyPerformance(tokenWs, performanceWs);
        }

        public bool RemovePerformance(BLL.SessionToken token, BLL.Performance performance)
        {
            var performanceWs = performance.ToWebSeriveObject<WS.Performance>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.RemovePerformance(tokenWs, performanceWs);
        }

        public bool ModifyLocationRange(BLL.SessionToken token, List<BLL.Location> locations)
        {
            var locationsWs = ProxyHelper.ToArrayOf<BLL.Location, WS.Location>(locations);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyLocationRange(tokenWs, locationsWs);
        }

        public bool ModifyLocation(BLL.SessionToken token, BLL.Location location)
        {
            var locationWs = location.ToWebSeriveObject<WS.Location>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.ModifyLocation(tokenWs, locationWs);
        }

        public bool RemoveLocation(BLL.SessionToken token, BLL.Location location)
        {
            var locationWs = location.ToWebSeriveObject<WS.Location>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return AdminAccessWs.RemoveLocation(tokenWs, locationWs);
        }
        
    }
}
