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
//     Wurm Florian
#endregion
using System;
using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;
using UFO.Server.Properties;

namespace UFO.Server.Test
{
    [TestClass]
    public class ServerTests
    {
        private const string TestDummyDaoAssembly = "UFO.Server.Dal.Dummy";
        private const string TestDummyDaoNameSpace = "UFO.Server.Dal.Dummy";
        private const string TestDummyDaoClassName = "DaoProviderFactory";

        private const string TestDbDaoAssemblyName = "UFO.Server.Dal.MySql";
        private const string TestDbDaoNameSpace = "UFO.Server.Dal.MySql";
        private const string TestDbDaoClassName = "DaoProviderFactory";

        #region App Config Tests

        [TestMethod]
        public void TestAppConfigRead()
        {
            var daoProviderName = Settings.Default.DaoProviderClassName;
            Assert.AreEqual(daoProviderName, TestDummyDaoClassName);
        }

        #endregion

        #region DAO Tests

        [TestMethod]
        public void TestDaoDefaultProvider()
        {
            IDaoProviderFactory daoProviderFactory = DalProviderFactories.GetDaoFactory();
            Assert.IsNotNull(daoProviderFactory);
        }
        
        [TestMethod]
        public void TestDaoInvalidProvider()
        {
            try
            {
                DalProviderFactories.GetDaoFactory("Some.Random.InvalidProvider");
                Assert.Fail("Expected exceptions did not occur!");
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is SettingsPropertyNotFoundException || exception is SettingsPropertyWrongTypeException);
            }
        }

        [TestMethod]
        public void TestDummyUserDaoFilter()
        {
            var daoProviderFactory = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName);
            var userDao = daoProviderFactory.CreateUserDao();
            Filter<User, string> filter = (collection, criteria) => collection.Where(x => x.EMail == criteria);
            var result = userDao.GetUsers("marius.dinu@mail.com", filter);
            var user = result.ResultObject?.First();

            Assert.IsTrue(result.ResultObject?.Count == 1);
            Assert.IsTrue("Marius" == user?.FistName && "Dinu" == user.LastName);
        }

        #endregion

        #region Dummy Data Tests
        
        [TestMethod]
        public void TestAllGeneratedUsers()
        {
            var userDao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateUserDao();
            var users = userDao.GetAllUsers();
            Assert.IsTrue(users.ResultObject?.Count > 100);
        }

        #endregion

        #region Database Data Access Test

        [TestMethod]
        public void TestAllUserDbAccess()
        {
            var userDao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();
            var users = userDao.GetAllUsers();
            Assert.IsTrue(users.ResultObject?.Count > 10);
        }

        #endregion
    }
}
