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
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
using UFO.Server.Common;
using UFO.Server.Domain;

namespace UFO.Server.Services
{
    [ServiceContract]
    public class AdminAccessWs
    {
        private static AAdminAccessBll _adminAccessDelegate;
        private static readonly AAdminAccessBll AdminAccessDelegate =
            _adminAccessDelegate ?? (_adminAccessDelegate = FactoryProvider.GetFactory<IBllProviderFactory>(BllProviderSettings.Instance).CreateAAdminAccessBll());

        [OperationContract]
        public bool ModifyArtistRange(SessionToken token, List<Artist> artists)
        {
            return AdminAccessDelegate.ModifyArtistRange(token, artists);
        }

        [OperationContract]
        public bool RemovePerformance(SessionToken token, Performance performance)
        {
            return AdminAccessDelegate.RemovePerformance(token, performance);
        }

        [OperationContract]
        public bool ModifyLocationRange(SessionToken token, List<Location> locations)
        {
            return AdminAccessDelegate.ModifyLocationRange(token, locations);
        }

        [OperationContract]
        public bool ModifyLocation(SessionToken token, Location location)
        {
            return AdminAccessDelegate.ModifyLocation(token, location);
        }

        [OperationContract]
        public bool RemoveLocation(SessionToken token, Location location)
        {
            return AdminAccessDelegate.RemoveLocation(token, location);
        }

        [OperationContract]
        public bool ModifyVenueRange(SessionToken token, List<Venue> venues)
        {
            return AdminAccessDelegate.ModifyVenueRange(token, venues);
        }

        [OperationContract]
        public bool ModifyPerformanceRange(SessionToken token, List<Performance> performances)
        {
            return AdminAccessDelegate.ModifyPerformanceRange(token, performances);
        }

        [OperationContract]
        public List<User> GetUser(SessionToken token, PagingData page)
        {
            return AdminAccessDelegate.GetUser(token, page);
        }

        [OperationContract]
        public PagingData RequestUserPagingData(SessionToken token)
        {
            return AdminAccessDelegate.RequestUserPagingData(token);
        }

        [OperationContract]
        public bool IsUserAuthenticated(SessionToken token)
        {
            return AdminAccessDelegate.IsUserAuthenticated(token);
        }

        [OperationContract]
        public bool IsValidAdmin(SessionToken token)
        {
            return AdminAccessDelegate.IsValidAdmin(token);
        }

        [OperationContract]
        public bool LoginAdmin(SessionToken token)
        {
            return AdminAccessDelegate.LoginAdmin(token);
        }

        [OperationContract]
        public void LogoutAdmin(SessionToken token)
        {
            AdminAccessDelegate.LogoutAdmin(token);
        }

        [OperationContract]
        public SessionToken RequestSessionToken(User user)
        {
            return AdminAccessDelegate.RequestSessionToken(user);
        }

        [OperationContract]
        public bool ModifyArtist(SessionToken token, Artist artist)
        {
            return AdminAccessDelegate.ModifyArtist(token, artist);
        }

        [OperationContract]
        public bool RemoveArtist(SessionToken token, Artist artist)
        {
            return AdminAccessDelegate.RemoveArtist(token, artist);
        }

        [OperationContract]
        public bool ModifyVenue(SessionToken token, Venue venue)
        {
            return AdminAccessDelegate.ModifyVenue(token, venue);
        }

        [OperationContract]
        public bool RemoveVenue(SessionToken token, Venue venue)
        {
            return AdminAccessDelegate.RemoveVenue(token, venue);
        }

        [OperationContract]
        public bool ModifyPerformance(SessionToken token, Performance performance)
        {
            return AdminAccessDelegate.ModifyPerformance(token, performance);
        }
    }
}
