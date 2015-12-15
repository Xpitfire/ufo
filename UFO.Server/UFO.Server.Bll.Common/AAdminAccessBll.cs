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
using UFO.Server.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public abstract class AAdminAccessBll : IAdminAccessBll
    {
        protected IUserDao UserDao = DalProviderFactories.GetDaoFactory().CreateUserDao();
        protected IPerformanceDao PerformanceDao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
        protected IArtistDao ArtistDao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
        protected ICategoryDao CategoryDao = DalProviderFactories.GetDaoFactory().CreateCategoryDao();
        protected ICountryDao CountryDao = DalProviderFactories.GetDaoFactory().CreateCountryDao();
        protected ILocationDao LocationDao = DalProviderFactories.GetDaoFactory().CreateLocationDao();
        protected IVenueDao VenueDao = DalProviderFactories.GetDaoFactory().CreateVenueDao();

        public abstract List<User> GetAllUser(SessionToken token);
        public abstract bool ModifyArtist(SessionToken token, Artist artist);
        public abstract bool RemoveArtist(SessionToken token, Artist artist);
        public abstract bool ModifyVenue(SessionToken token, Venue venue);
        public abstract bool RemoveVenue(SessionToken token, Venue venue);
        public abstract bool ModifyPerformance(SessionToken token, Performance performance);
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
            return GetSession().RequestSessionId(UserDao.SelectByEmail(user.EMail).ResultObject);
        }

    }
}
