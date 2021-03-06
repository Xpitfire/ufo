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
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UFO.Server.Bll.Common.Helper;
using UFO.Server.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public abstract class AAdminAccessBll : IAdminAccessBll, IValidationAccessBll
    {
        private static IUserDao _userDao;
        protected static IUserDao UserDao = _userDao ?? (_userDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateUserDao());
        private static IPerformanceDao _performanceDao;
        protected static IPerformanceDao PerformanceDao = _performanceDao ?? (_performanceDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreatePerformanceDao());
        private static IArtistDao _artistDao;
        protected static IArtistDao ArtistDao = _artistDao ?? (_artistDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateArtistDao());
        private static ICategoryDao _categoryDao;
        protected static ICategoryDao CategoryDao = _categoryDao ?? (_categoryDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateCategoryDao());
        private static ICountryDao _countryDao;
        protected static ICountryDao CountryDao = _countryDao ?? (_countryDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateCountryDao());
        private static ILocationDao _locationDao;
        protected static ILocationDao LocationDao = _locationDao ?? (_locationDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateLocationDao());
        private static IVenueDao _venueDao;
        protected static IVenueDao VenueDao = _venueDao ?? (_venueDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateVenueDao());

        protected string EmailNotificationServer { get; } = Properties.Settings.Default.EmailNotificationServer;
        protected int EmailNotificationPort { get; } = Properties.Settings.Default.EmailNotificationPort;
        protected string EmailNotificationUsername { get; } = Properties.Settings.Default.EmailNotificationUsername;
        protected string EmailNotificationPassword { get; } = Properties.Settings.Default.EmailNotificationPassword;

        public abstract List<User> GetUsers(SessionToken token, PagingData page);
        public abstract List<User> SearchUsersPerKeyword(SessionToken token, string keyword);
        public abstract List<string> GetUserAutoCompletion(SessionToken token, string keyword);
        public abstract bool SendNotification(SessionToken token, Notification notification);
        public abstract bool ModifyArtistRange(SessionToken token, List<Artist> artists);
        public abstract bool ModifyArtist(SessionToken token, Artist artist);
        public abstract bool RemoveArtist(SessionToken token, Artist artist);
        public abstract bool ModifyVenueRange(SessionToken token, List<Venue> venues);
        public abstract bool ModifyVenue(SessionToken token, Venue venue);
        public abstract bool RemoveVenue(SessionToken token, Venue venue);
        public abstract bool ModifyPerformanceRange(SessionToken token, List<Performance> performances);
        public abstract bool ModifyPerformance(SessionToken token, Performance performance);
        public abstract bool RemovePerformance(SessionToken token, Performance performance);
        public abstract bool DelayPerformance(SessionToken token, Performance oldPerformance, Performance newPerformance);
        public abstract bool ModifyLocationRange(SessionToken token, List<Location> locations);
        public abstract bool ModifyLocation(SessionToken token, Location location);
        public abstract bool RemoveLocation(SessionToken token, Location location);
        public abstract bool IsUserAuthenticated(SessionToken token);
        public abstract bool IsValidAdmin(SessionToken token);
        public abstract ISessionBll GetSession();

        public virtual bool LoginAdmin(SessionToken token)
        {
            if (!IsValidAdmin(token))
                return false;
            LogoutAdmin(token);
            GetSession().RegisterUserSession(token, this);
            return true;
        }
        
        public virtual void LogoutAdmin(SessionToken token)
        {
            GetSession().DeleteUserSession(token);
        }
        
        public virtual SessionToken RequestSessionToken(User user)
        {
            SessionToken token = null;
            UserDao.SelectByEmail(user.EMail)
                .OnSuccess(u => token = (u.Password == user.Password) ? GetSession().RequestSessionId(u) : null);
            return token;
        }

        public virtual TResult EvaluateSessionPagingResult<TResult>(SessionToken token, PagingData page, Func<TResult> function)
        {
            if (!IsUserAuthenticated(token) || !PagingHelper.IsPageValid(page))
                return default(TResult);

            return PagingHelper.EvaluatePagingResult(page, function);
        }

        public virtual TResult EvaluateSessionPagingResult<TResult>(SessionToken token, Func<TResult> function)
        {
            if (!IsUserAuthenticated(token))
                return default(TResult);

            return function();
        }

        public virtual PagingData RequestUserPagingData(SessionToken token)
        {
            return IsUserAuthenticated(token) ? PagingHelper.RequestPagingData(UserDao) : null;
        }

        public bool IsDateTimeFormatValid(DateTime dateTime)
        {
            return true;
        }

        public bool IsPerformanceDateTimeDelayValid(Performance old, Performance @new)
        {
            var valid = false;
            if (old != null && @new != null 
                && old.Artist?.Equals(@new.Artist) != null)
            {
                valid = Math.Abs((old.DateTime.Hour - @new.DateTime.Hour)) >= 1;
                valid &= IsDateTimeFormatValid(old.DateTime);
                valid &= IsDateTimeFormatValid(@new.DateTime);
            }
            return valid;
        }

        public bool IsUserAutoCompletionValid(string keyword)
        {
            return keyword != null && keyword.Length > 2;
        }

        public bool IsArtistValid(Artist artist)
        {
            return artist?.Category != null
                   && artist.Name != null
                   && artist.EMail != null
                   && Regex.IsMatch(artist.EMail, Constants.EMailRegex);
        }

        public bool IsUserValid(User user)
        {
            return user != null
                   && user.UserId > 0
                   && user.Password != null
                   && user.Password.Length >= 20
                   && user.EMail != null
                   && Regex.IsMatch(user.EMail, Constants.EMailRegex);
        }

        public bool IsVenueValid(Venue venue)
        {
            return !string.IsNullOrEmpty(venue?.VenueId)
                   && venue.VenueId.Length <= 3
                   && venue.Location != null;
        }

        public bool IsLocationValid(Location location)
        {
            return location?.Name != null;
        }

        public bool IsPerformanceValid(Performance performance)
        {
            return performance != null
                   && IsDateTimeFormatValid(performance.DateTime)
                   && IsArtistValid(performance.Artist)
                   && IsVenueValid(performance.Venue);
        }

        public bool IsNotificationValid(Notification notification)
        {
            return !string.IsNullOrEmpty(notification?.Sender)
                   && !string.IsNullOrEmpty(notification.Recipient)
                   && !string.IsNullOrEmpty(notification.Subject)
                   && !string.IsNullOrEmpty(notification.Body);
        }
    }
}
