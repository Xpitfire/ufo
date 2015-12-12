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
        private readonly IUserDao _userDao = DalProviderFactories.GetDaoFactory().CreateUserDao();

        public virtual List<User> GetAll(SessionToken token)
        {
            return IsUserAuthenticated(token) ? _userDao.SelectAll().ResultObject : null;
        }

        public virtual bool IsUserAuthenticated(SessionToken token)
        {
            return GetSession().GetUserFromSession(token)?.IsAdmin ?? false;
        }

        public virtual bool IsValidAdmin(SessionToken token)
        {
            return _userDao.VerifyAdminCredentials(token.User).ResultObject;
        }

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
            return GetSession().RequestSessionId(_userDao.SelectByEmail(user.EMail).ResultObject);
        }

        public abstract ISessionBll GetSession();

        public abstract void InsertArtist(Artist artist);
    }
}
