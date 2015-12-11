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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using UFO.Commander.Views.UserControls;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
using UFO.Server.Domain;

namespace UFO.Commander.ViewModels
{
    class AuthAccessViewModel
    {
        private readonly IAuthAccessBll _authAccessBll = new AuthAccessBll();

        public bool IsValidLogin(string textBoxUserName, string password)
        {
            var user = new User
            {
                EMail = textBoxUserName, Password = password
            };
            _authAccessBll.EncryptUserCredentials(user);
            return _authAccessBll.IsValidAdmin(user);
        }
    }
}
