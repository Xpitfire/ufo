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
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PostSharp.Patterns.Model;
using UFO.Commander.Handler;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Messages;
using UFO.Commander.Views;
using UFO.Commander.Views.Dialogs;

namespace UFO.Commander.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAdminAccessBll _authAccessBll = BllFactory.CreateAdminAccessBll();
        private static SessionToken _sessionToken;
        public SessionToken CurrentSessionToken => _sessionToken;

        public event EventHandler LogoutEvent;

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                _isLoggedIn = value;
                if (!value)
                {
                    LogoutEvent?.Invoke(this, null);
                }
            }
        }

        public string Username { get; set; }
        public string Password { get; set; }
        
        public bool RequestSessionToken(string textBoxUserName, string password)
        {
#if !DEBUG
            return true;
#endif

            var user = new User
            {
                EMail = textBoxUserName,
                Password = Crypto.EncryptPassword(password)
            }.ToViewModelObject<UserViewModel>();

            _sessionToken = _authAccessBll.RequestSessionToken(user);
            return _authAccessBll.IsValidAdmin(_sessionToken);
        }

        [ViewExceptionHandler("Login Exception")]
        public bool Login()
        {
#if !DEBUG
            return true;
#endif
            return IsLoggedIn = _authAccessBll.LoginAdmin(_sessionToken);
        }

        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand(() =>
                {
                    if (_sessionToken == null)
                    {
                        Messenger.Default.Send(new ShowDialogMessage<CustomLoginDialog>(this));
                    }
                }));
            }
        }
        
        private ICommand _loginCommand;
        public ICommand LoginCommand => _loginCommand ?? (_loginCommand = new RelayCommand(LoginCommandExecute));

        private async void LoginCommandExecute()
        {
            var username = Username;
            var password = Password;
            var validSession = await Task.Run(() => RequestSessionToken(username, password));

            if (validSession)
            {
                validSession = await Task.Run(() => Login());
                if (!validSession) return;
                
                Messenger.Default.Send(new ShowContentMessage<TabContentView>(ViewModelLocator.TabControlViewModel));
                Messenger.Default.Send(new HideDialogMessage<CustomLoginDialog>(this));
            }
        }
    }
}
