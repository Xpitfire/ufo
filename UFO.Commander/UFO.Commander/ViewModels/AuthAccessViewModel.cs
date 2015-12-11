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
using System.Windows.Input;
using UFO.Server;

namespace UFO.Commander.ViewModels
{
    class AuthAccessViewModel
    {
        private readonly AuthAccessBllClient _authAccessBll = new AuthAccessBllClient();
        private static string _appSessionId;

        public bool IsValidLogin(string textBoxUserName, string password)
        {
            var user = new User
            {
                EMailk__BackingField = textBoxUserName,
                Passwordk__BackingField = password
            };
            _authAccessBll.EncryptUserCredentials(ref user);
            if (!_authAccessBll.IsValidAdmin(user))
                return false;
            _appSessionId = _authAccessBll.RequestSessionId(user);
            return true;
        }

        public void LoginAdmin(string textBoxUserName, string password)
        {
            _authAccessBll.LoginAdminByMailAndPassword(_appSessionId, textBoxUserName, password);
        }

        private ICommand _checkLoginCommand;
        public ICommand CheckLoginCommand
        {
            get
            {
                return _checkLoginCommand ?? (_checkLoginCommand = new RelayCommand(obj =>
                {
                    if (!_authAccessBll.IsUserAuthenticated(_appSessionId))
                    {
                        throw new Exception("Lost server connection session!");
                    }
                }));
            }
        }
    }
}
