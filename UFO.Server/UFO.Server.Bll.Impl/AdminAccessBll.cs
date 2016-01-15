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
using System.Linq;
using System.Transactions;
using UFO.Server.Bll.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Impl
{
    public class AdminAccessBll : AAdminAccessBll
    {
        public override List<User> GetUser(SessionToken token, PagingData page)
        {
            return EvaluateSessionPagingResult(token, page, () => UserDao.Select(page).ResultObject);
        }

        public override bool ModifyArtistRange(SessionToken token, List<Artist> artists)
        {
            bool result;
            using (var scope = new TransactionScope())
            {
                result = artists.Aggregate(true, (current, artist) => current & ModifyArtist(token, artist));
                scope.Complete();
            }
            return result;
        }

        public override bool RemovePerformance(SessionToken token, Performance performance)
        {
            if (!IsUserAuthenticated(token) || performance == null)
                return false;

            var result = PerformanceDao.SelectById(performance.DateTime, performance.Artist.ArtistId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = PerformanceDao.Delete(performance);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        public override bool ModifyLocationRange(SessionToken token, List<Location> locations)
        {
            bool result;
            using (var scope = new TransactionScope())
            {
                result = locations.Aggregate(true, (current, location) => current & ModifyLocation(token, location));
                scope.Complete();
            }
            return result;
        }

        public override bool ModifyLocation(SessionToken token, Location location)
        {
            if (!IsUserAuthenticated(token) || location == null)
                return false;

            var result = LocationDao.SelectById(location.LocationId);
            result = result.ResponseStatus == DaoStatus.Successful
                ? LocationDao.Update(location)
                : LocationDao.Insert(location);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        public override bool RemoveLocation(SessionToken token, Location location)
        {
            if (!IsUserAuthenticated(token) || location == null)
                return false;

            var result = LocationDao.SelectById(location.LocationId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = LocationDao.Delete(location);

            return result.ResponseStatus == DaoStatus.Successful;
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
        
        public override bool ModifyArtist(SessionToken token, Artist artist)
        {
            if (!IsUserAuthenticated(token) || artist == null)
                return false;

            var result = ArtistDao.SelectById(artist.ArtistId);
            result = result.ResponseStatus == DaoStatus.Successful 
                ? ArtistDao.Update(artist) 
                : ArtistDao.Insert(artist);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        public override bool RemoveArtist(SessionToken token, Artist artist)
        {
            if (!IsUserAuthenticated(token) || artist == null)
                return false;

            var result = ArtistDao.SelectById(artist.ArtistId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = ArtistDao.Delete(artist);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        public override bool ModifyVenueRange(SessionToken token, List<Venue> venues)
        {
            bool result;
            using (var scope = new TransactionScope())
            {
                result = venues.Aggregate(true, (current, venue) => current & ModifyVenue(token, venue));
                scope.Complete();
            }
            return result;
        }

        public override bool ModifyVenue(SessionToken token, Venue venue)
        {
            if (!IsUserAuthenticated(token) || venue == null)
                return false;

            var result = VenueDao.SelectById(venue.VenueId);
            result = result.ResponseStatus == DaoStatus.Successful
                ? VenueDao.Update(venue)
                : VenueDao.Insert(venue);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        public override bool RemoveVenue(SessionToken token, Venue venue)
        {
            if (!IsUserAuthenticated(token) || venue == null)
                return false;

            var result = VenueDao.SelectById(venue.VenueId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = VenueDao.Delete(venue);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        public override bool ModifyPerformanceRange(SessionToken token, List<Performance> performances)
        {
            bool result;
            using (var scope = new TransactionScope())
            {
                result = performances.Aggregate(true, (current, performance) => current & ModifyPerformance(token, performance));
                scope.Complete();
            }
            return result;
        }

        public override bool ModifyPerformance(SessionToken token, Performance performance)
        {
            if (!IsUserAuthenticated(token) || performance?.Artist == null)
                return false;

            var result = PerformanceDao.SelectById(performance.DateTime, performance.Artist.ArtistId);
            if (result.ResponseStatus == DaoStatus.Successful)
            {
                if (IsPerformanceDateTimeDelayValid(result.ResultObject, performance))
                    result = PerformanceDao.Update(performance); 
                else
                    result.ResponseStatus = DaoStatus.Failed;
            }
            else
            {
                if (IsDateTimeFormatValid(performance.DateTime))
                    result = PerformanceDao.Insert(performance);
                else
                    result.ResponseStatus = DaoStatus.Failed;
            }
            return result.ResponseStatus == DaoStatus.Successful;
        }
        
    }
}
