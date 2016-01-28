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
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UFO.Commander.Handler;
using UFO.Commander.Helper;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;
using GalaSoft.MvvmLight.Messaging;
using UFO.Commander.Messages;

namespace UFO.Commander.ViewModel
{
    [ViewExceptionHandler("Login Exception")]
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAdminAccessBll _authAccessBll = BllAccessHandler.AdminAccessBll;

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

        public object IsPasswordWrong { get; set; }
        
        public async Task<bool> RequestSessionToken(string textBoxUserName, string password)
        {
            if (!DebugHelper.IsReleaseMode) return true;

            var user = new User
            {
                EMail = textBoxUserName,
                Password = Crypto.EncryptPassword(password)
            }.ToViewModelObject<UserViewModel>();

            BllAccessHandler.SessionToken = await _authAccessBll.RequestSessionTokenAsync(user);
            return await _authAccessBll.IsValidAdminAsync(BllAccessHandler.SessionToken);
        }
        
        public async Task<bool> Login()
        {
            if (!DebugHelper.IsReleaseMode) return true;

            return IsLoggedIn = await _authAccessBll.LoginAdminAsync(BllAccessHandler.SessionToken);
        }

        private ICommand _logoutCommand;
        public ICommand LogoutCommand
        {
            get
            {
                return _logoutCommand ?? (_logoutCommand = new RelayCommand(() =>
                {
                    if (BllAccessHandler.SessionToken == null)
                    {
                        Messenger.Default.Send(new ShowDialogMessage(this));
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
            var validSession = await RequestSessionToken(username, password);

            if (validSession)
            {
                validSession = await Login();
                if (!validSession)
                {
                    IsPasswordWrong = new object();
                    return;
                }
                
                Messenger.Default.Send(new ShowContentMessage(Locator.TabControlViewModel));
                Messenger.Default.Send(new HideDialogMessage(this));
            }
            else
            {
                IsPasswordWrong = new object();
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
            => _cancelCommand ?? (_cancelCommand = new RelayCommand(() => Application.Current.Shutdown()));

        public override string ToString()
        {
            return "UFO Login";
        }
    }
}
