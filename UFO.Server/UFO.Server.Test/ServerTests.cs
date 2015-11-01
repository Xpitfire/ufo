using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using FH.SEv.UFO.Server.Dao.Impl;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;
using FH.SEv.UFO.Server.Properties;
using FH.SEv.UFO.Server.Provider;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FH.SEv.UFO.Server.Test
{
    [TestClass]
    public class ServerTests
    {
        private const string TestConstDummyDaoProviderName = "FH.SEv.UFO.Server.Provider.Impl.DummyDaoProviderFactory";
        private const string TestConstDbDaoProviderName = "FH.SEv.UFO.Server.Provider.Impl.DbDaoProviderFactory";

        #region App Config Tests

        [TestMethod]
        public void TestAppConfigRead()
        {
            var daoProviderName = Settings.Default.DaoProviderName;
            Assert.AreEqual(daoProviderName, TestConstDummyDaoProviderName);
        }

        #endregion

        #region DAO Tests

        [TestMethod]
        public void TestDaoDummyProvider()
        {
            IDaoProviderFactory daoProviderFactory = DaoProviderFactories.GetFactory(TestConstDummyDaoProviderName);
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
            var daoProviderFactory = DaoProviderFactories.GetFactory(TestConstDummyDaoProviderName);
            var userDao = daoProviderFactory.CreateUserDao();
            Filter<User, string> filter = (collection, criteria) => collection.Where(x => x.EMail == criteria);
            var result = userDao.GetUsers("marius.dinu@mail.com", filter);
            var user = result.First();

            Assert.IsTrue(result.Count == 1);
            Assert.IsTrue("Marius" == user.FistName && "Dinu" == user.LastName);
        }

        #endregion

        #region Dummy Data Tests

        [TestMethod]
        public void TestUserGenerator()
        {
            var user = DummyDataGenerator.GenerateUser();
            Assert.IsTrue(user.ArtistId != Artist.InvalidArtistId);
            Assert.IsTrue(user.EMail.Contains("@"));
            Assert.IsNotNull(user.FistName);
            Assert.IsNotNull(user.LastName);
            Assert.IsNotNull(user.PasswordHash);
        }

        [TestMethod]
        public void TestAllGeneratedUsers()
        {
            var userDao = DaoProviderFactories.GetFactory(Settings.Default.DaoProviderName).CreateUserDao();
            var users = userDao.GetAllUsers();
            Assert.IsTrue(users.Count > 100);
        }

        #endregion

        #region Database Data Access Test

        [TestMethod]
        public void TestAllUserDbAccess()
        {
            var userDao = DaoProviderFactories.GetFactory(TestConstDbDaoProviderName).CreateUserDao();
            var users = userDao.GetAllUsers();
            Assert.IsTrue(users.Count > 10);
        }

        #endregion
    }
}
