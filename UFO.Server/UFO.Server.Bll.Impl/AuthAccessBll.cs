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
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Contracts;
using UFO.Server.Bll.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Impl
{
    public class AuthAccessBll : IAuthAccessBll
    {
        private User _currentAuthUser;

        private User CurrentAuthUser
        {
            get { return _currentAuthUser; }
            set
            {
                if (value == null)
                {
                    SessionHandler.Instance.RemoveUserSession(_currentAuthUser);
                }
                else
                {
                    SessionHandler.Instance.CreateUserSession(value, this);
                }
                _currentAuthUser = value;
            }
        }

        private readonly IUserDao _userDao = DalProviderFactories.GetDaoFactory().CreateUserDao();

        public IList<User> GetAll()
        {
            return IsUserAuthenticated() ? _userDao.SelectAll().ResultObject : null;
        }

        public bool IsUserAuthenticated()
        {
            return CurrentAuthUser?.IsAdmin ?? false;
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

        public bool LoginAdmin(User user)
        {
            // if user is already authenticated, then kick admin from session
            if (IsValidAdmin(user) && !IsUserAuthenticated())
            {
                CurrentAuthUser = _userDao.SelectByEmail(user.EMail).ResultObject;
                return true;
            }
            return false;
        }

        public bool LoginAdmin(string email, string passwordHash)
        {
            return LoginAdmin(new User {EMail = email, Password = passwordHash});
        }

        public void LogoutAdmin()
        {
            CurrentAuthUser = null;
        }

        public void EncryptUserCredentials(User user)
        {
            using (var md5 = MD5.Create())
            {
                user.Password = Crypto.GetMd5Hash(md5, user.Password);
            }
        }
    }
}