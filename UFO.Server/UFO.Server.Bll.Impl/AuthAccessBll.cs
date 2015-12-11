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
using System.Linq;
using System.Security.Cryptography;
using UFO.Server.Bll.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Impl
{
    public class AuthAccessBll : IAuthAccessBll
    {
        private readonly IUserDao _userDao = DalProviderFactories.GetDaoFactory().CreateUserDao();

        public IList<User> GetAll(string sessionId)
        {
            return IsUserAuthenticated(sessionId) ? _userDao.SelectAll().ResultObject : null;
        }

        public bool IsUserAuthenticated(string sessionId)
        {
            return SessionHandler.Instance.GetUserFromSession(sessionId)?.IsAdmin ?? false;
        }

        public bool IsValidAdmin(User user)
        {
            return _userDao
                .SelectWhere(users => users.Where(
                    u => u.EMail != null
                    && u.Password != null 
                    && u.EMail.Equals(user.EMail) 
                    && u.Password.Equals(user.Password)))
                .ResultObject?
                .FirstOrDefault()?
                .IsAdmin ?? false;
        }

        public bool LoginAdmin(string sessionId, User user)
        {
            if (IsValidAdmin(user))
            {
                LogoutAdmin(user);
                SessionHandler.Instance.SetUserSession(sessionId, _userDao.SelectByEmail(user.EMail).ResultObject, this);
                return true;
            }
            return false;
        }

        public bool LoginAdmin(string sessionId, string email, string passwordHash)
        {
            var user = new User
            {
                EMail = email,
                Password = passwordHash
            };
            EncryptUserCredentials(ref user);
            return LoginAdmin(sessionId, user);
        }

        public void LogoutAdmin(string sessionId)
        {
            SessionHandler.Instance.RemoveUserSession(
                SessionHandler.Instance.GetUserFromSession(sessionId));
        }

        private void LogoutAdmin(User user)
        {
            SessionHandler.Instance.RemoveUserSession(user);
        }

        public void EncryptUserCredentials(ref User user)
        {
            using (var md5 = MD5.Create())
            {
                user.Password = Crypto.GetMd5Hash(md5, user.Password);
            }
        }

        public string RequestSessionId(User user)
        {
            return IsValidAdmin(user) ? SessionHandler.Instance.GenerateSessionId(user) : null;
        }
    }
}
