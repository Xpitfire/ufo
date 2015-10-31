using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Properties;
using FH.SEv.UFO.Server.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FH.SEv.UFO.Server.Test
{
    [TestClass]
    public class ServerTests
    {
        private const string TestConstDaoProviderName = "FH.SEv.UFO.Server.Provider.Impl.DummyDaoProviderFactory";

        [TestMethod]
        public void TestAppConfigRead()
        {
            var daoProviderName = Settings.Default.DaoProviderName;
            Assert.AreEqual(daoProviderName, TestConstDaoProviderName);
        }
        
        [TestMethod]
        public void TestDaoDummyProvider()
        {
            IDaoProviderFactory daoProviderFactory = DaoProviderFactories.GetFactory(TestConstDaoProviderName);
            Assert.IsNotNull(daoProviderFactory);
        }
        
        [TestMethod]
        [ExpectedException(typeof(SettingsPropertyNotFoundException))]
        public void TestDaoInvalidProvider()
        {
            DaoProviderFactories.GetFactory("Some.Random.InvalidProvider");
        }

        [TestMethod]
        public void TestDummyUserDaoFilter()
        {
            var daoProviderFactory = DaoProviderFactories.GetFactory(TestConstDaoProviderName);
            var userDao = daoProviderFactory.CreateUserDao();
            var result = userDao.GetUsers((collection, lastName) =>
            {
                return collection.Where(x => x.LastName == lastName);
            });
            var user = result.First();

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue("Max" == user.FistName);
        }
    }
}
