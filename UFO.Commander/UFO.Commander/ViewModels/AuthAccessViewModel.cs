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
using System.Security.Cryptography;
using System.Windows.Input;
using UFO.Services.AdminAccess;

namespace UFO.Commander.ViewModels
{
    class AuthAccessViewModel
    {
        private readonly IAdminAccessBll _authAccessBll = new AdminAccessBllClient();
        private static SessionToken _sessionToken;

        public bool RequestLogin(string textBoxUserName, string password)
        {
            var user = new User
            {
                EMail = textBoxUserName
            };
            using (var md5 = MD5.Create())
            {
                user.Password = Crypto.GetMd5Hash(md5, password);
            }
            _sessionToken = _authAccessBll.RequestSessionToken(user);
            return _authAccessBll.IsValidAdmin(_sessionToken);
        }

        public void Login()
        {
            _authAccessBll.LoginAdmin(_sessionToken);
        }

        private ICommand _checkLoginCommand;
        public ICommand CheckLoginCommand
        {
            get
            {
                return _checkLoginCommand ?? (_checkLoginCommand = new RelayCommand(obj =>
                {
                    if (!_authAccessBll.IsUserAuthenticated(_sessionToken))
                    {
                        Console.WriteLine("Failed");
                    }
                }));
            }
        }
    }
}
