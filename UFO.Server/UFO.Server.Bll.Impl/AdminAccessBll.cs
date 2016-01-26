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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Transactions;
using PostSharp.Patterns.Diagnostics;
using UFO.Server.Bll.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Impl
{
    public class AdminAccessBll : AAdminAccessBll
    {
        [LogException]
        public override List<User> GetUsers(SessionToken token, PagingData page)
        {
            return EvaluateSessionPagingResult(token, page, () => UserDao.Select(page).ResultObject);
        }

        [LogException]
        public override List<User> SearchUsersPerKeyword(SessionToken token, string keyword)
        {
            return EvaluateSessionPagingResult(token, () => UserDao.SelectByKeyword(keyword)).ResultObject;
        }

        [LogException]
        public override List<string> GetUserAutoCompletion(SessionToken token, string keyword)
        {
            if (!IsUserAuthenticated(token))
                return new List<string>();
            Func<List<string>> func = () =>
            {
                var set = new HashSet<string>();
                if (keyword != null && keyword.Length >= 2)
                {
                    SearchUsersPerKeyword(token, keyword)?.ForEach(u =>
                    {
                        if (Regex.IsMatch(u.FirstName, keyword, RegexOptions.IgnoreCase))
                            set.Add(u.FirstName);
                        if (Regex.IsMatch(u.LastName, keyword, RegexOptions.IgnoreCase))
                            set.Add(u.LastName);
                        if (u.Artist != null && Regex.IsMatch(u.Artist.Name, keyword, RegexOptions.IgnoreCase))
                            set.Add(u.Artist.Name);
                    });
                }
                return set.ToList();
            };
            return EvaluateSessionPagingResult(token, func);
        }

        [LogException]
        public override bool SendNotification(SessionToken token, Notification notification)
        {
            if (!IsUserAuthenticated(token) || !IsNotificationValid(notification))
                return false;

            try
            {
                using (var mailMessage = new MailMessage(notification.Sender, notification.Recipient)
                {
                    Subject = notification.Subject,
                    Body = notification.Body,
                    IsBodyHtml = true
                })
                using (var smtpClient = new SmtpClient(EmailNotificationServer, EmailNotificationPort)
                {
                    Credentials = new NetworkCredential(EmailNotificationUsername, EmailNotificationPassword),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    EnableSsl = true
                })
                {
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        [LogException]
        public override bool ModifyArtistRange(SessionToken token, List<Artist> artists)
        {
            if (!IsUserAuthenticated(token) || artists == null || artists.Count <= 0)
                return false;

            bool result;
            using (var scope = new TransactionScope())
            {
                result = artists.Aggregate(true, (current, artist) => current & ModifyArtist(token, artist));
                scope.Complete();
            }
            return result;
        }

        [LogException]
        public override bool RemovePerformance(SessionToken token, Performance performance)
        {
            if (!IsUserAuthenticated(token) || !IsPerformanceValid(performance))
                return false;

            var result = PerformanceDao.SelectById(performance.DateTime, performance.Artist.ArtistId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = PerformanceDao.Delete(performance);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool DelayPerformance(SessionToken token, Performance oldPerformance, Performance newPerformance)
        {
            if (!IsUserAuthenticated(token) 
                || !IsPerformanceValid(oldPerformance) 
                || !IsPerformanceValid(newPerformance) 
                || Equals(oldPerformance, newPerformance))
            {
                return false;
            }

            Performance checkResult = null;
            PerformanceDao.SelectById(oldPerformance.DateTime,
                oldPerformance.Artist.ArtistId)
                .OnSuccess(response => checkResult = response.ResultObject);

            if (checkResult == null)
                return false;

            var insertStatus = DaoStatus.Failed;
            using (var scope = new TransactionScope())
            {
                var deleteStatus = PerformanceDao.Delete(oldPerformance).ResponseStatus;
                if (deleteStatus == DaoStatus.Successful)
                    insertStatus = PerformanceDao.Insert(newPerformance).ResponseStatus;
                if (insertStatus == DaoStatus.Successful)
                    scope.Complete();
            }
            return insertStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool ModifyLocationRange(SessionToken token, List<Location> locations)
        {
            if (!IsUserAuthenticated(token) || locations == null || locations.Count <= 0)
                return false;

            bool result;
            using (var scope = new TransactionScope())
            {
                result = locations.Aggregate(true, (current, location) => current & ModifyLocation(token, location));
                scope.Complete();
            }
            return result;
        }

        [LogException]
        public override bool ModifyLocation(SessionToken token, Location location)
        {
            if (!IsUserAuthenticated(token) || !IsLocationValid(location))
                return false;

            var result = LocationDao.SelectById(location.LocationId);
            result = result.ResponseStatus == DaoStatus.Successful
                ? LocationDao.Update(location)
                : LocationDao.Insert(location);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool RemoveLocation(SessionToken token, Location location)
        {
            if (!IsUserAuthenticated(token) || !IsLocationValid(location))
                return false;

            var result = LocationDao.SelectById(location.LocationId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = LocationDao.Delete(location);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool IsUserAuthenticated(SessionToken token)
        {
            return token != null && (GetSession().GetUserFromSession(token)?.IsAdmin ?? false);
        }

        [LogException]
        public override bool IsValidAdmin(SessionToken token)
        {
            return token != null && UserDao.VerifyAdminCredentials(token.User).ResultObject;
        }

        [LogException]
        public override ISessionBll GetSession()
        {
            return SessionHandler.Instance;
        }

        [LogException]
        public override bool ModifyArtist(SessionToken token, Artist artist)
        {
            if (!IsUserAuthenticated(token) || !IsArtistValid(artist))
                return false;
            
            var result = ArtistDao.SelectById(artist.ArtistId);
            result = result.ResponseStatus == DaoStatus.Successful 
                ? ArtistDao.Update(artist) 
                : ArtistDao.Insert(artist);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool RemoveArtist(SessionToken token, Artist artist)
        {
            if (!IsUserAuthenticated(token) || !IsArtistValid(artist))
                return false;

            var result = ArtistDao.SelectById(artist.ArtistId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = ArtistDao.Delete(artist);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool ModifyVenueRange(SessionToken token, List<Venue> venues)
        {
            if (!IsUserAuthenticated(token) || venues == null || venues.Count <= 0)
                return false;

            bool result;
            using (var scope = new TransactionScope())
            {
                result = venues.Aggregate(true, (current, venue) => current & ModifyVenue(token, venue));
                scope.Complete();
            }
            return result;
        }

        [LogException]
        public override bool ModifyVenue(SessionToken token, Venue venue)
        {
            if (!IsUserAuthenticated(token) || !IsVenueValid(venue))
                return false;

            var result = VenueDao.SelectById(venue.VenueId);
            result = result.ResponseStatus == DaoStatus.Successful
                ? VenueDao.Update(venue)
                : VenueDao.Insert(venue);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool RemoveVenue(SessionToken token, Venue venue)
        {
            if (!IsUserAuthenticated(token) || !IsVenueValid(venue))
                return false;

            var result = VenueDao.SelectById(venue.VenueId);
            if (result.ResponseStatus == DaoStatus.Successful)
                result = VenueDao.Delete(venue);

            return result.ResponseStatus == DaoStatus.Successful;
        }

        [LogException]
        public override bool ModifyPerformanceRange(SessionToken token, List<Performance> performances)
        {
            if (!IsUserAuthenticated(token) || performances == null || performances.Count <= 0)
                return false;
            bool result;
            using (var scope = new TransactionScope())
            {
                result = performances.Aggregate(true, (current, performance) => current & ModifyPerformance(token, performance));
                scope.Complete();
            }
            return result;
        }

        [LogException]
        public override bool ModifyPerformance(SessionToken token, Performance performance)
        {
            if (!IsUserAuthenticated(token) || !IsPerformanceValid(performance))
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
