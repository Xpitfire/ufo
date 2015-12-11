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
