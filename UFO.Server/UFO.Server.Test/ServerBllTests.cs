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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
using UFO.Server.Domain;

namespace UFO.Server.Test
{
    [TestClass]
    public class ServerBllTests
    {
        [TestMethod]
        public void TestArtistBllGetAll()
        {
            var viewAccessBll = new ViewAccessBll();
            var list = viewAccessBll.GetAllArtist();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }
        
        [TestMethod]
        public void TestAdminAuthentication()
        {
            var authAccessBll = new AuthAccessBll();
            var user = new User
            {
                EMail = "marius.dinu@mymail.com",
                Password = "password"
            };
            var token = authAccessBll.RequestSessionToken(user);

            Assert.IsFalse(authAccessBll.IsUserAuthenticated(token));
            authAccessBll.LoginAdmin(token);
            Assert.IsTrue(authAccessBll.IsUserAuthenticated(token));
            authAccessBll.LogoutAdmin(token);
            Assert.IsFalse(authAccessBll.IsUserAuthenticated(token));
        }
    }
}
