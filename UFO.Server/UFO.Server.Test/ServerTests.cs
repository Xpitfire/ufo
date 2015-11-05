using System.Configuration;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server;
using UFO.Server.Dal.Common;
using UFO.Server.Dal.Dummy;
using UFO.Server.Domain;
using UFO.Server.Properties;

namespace FH.SEv.UFO.Server.Test
{
    [TestClass]
    public class ServerTests
    {
        private const string TestDummyDaoAssembly = "UFO.Server.Dal.Dummy";
        private const string TestDummyDaoNameSpace = "UFO.Server.Dal.Dummy";
        private const string TestDummyDaoClassName = "DummyDaoProviderFactory";

        private const string TestDbDaoAssemblyName = "UFO.Server.Dal.MySql";
        private const string TestDbDaoNameSpace = "UFO.Server.Dal.MySql";
        private const string TestDbDaoClassName = "DbDaoProviderFactory";

        #region App Config Tests

        [TestMethod]
        public void TestAppConfigRead()
        {
            // TODO: add config file
            var daoProviderName = Settings.Default.DaoProviderClassName;
            Assert.AreEqual(daoProviderName, TestDummyDaoClassName);
        }

        #endregion

        #region DAO Tests

        [TestMethod]
        public void TestDaoDummyProvider()
        {
            IDaoProviderFactory daoProviderFactory = DaoProviderFactories.GetFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName);
            Assert.IsNotNull(daoProviderFactory);
        }
        
        [TestMethod]
        [ExpectedException(typeof(SettingsPropertyNotFoundException))]
        public void TestDaoInvalidProvider()
        {
            // TODO: Check if correct exception
            DaoProviderFactories.GetFactory("Some.Random.InvalidProvider");
        }

        [TestMethod]
        public void TestDummyUserDaoFilter()
        {
            var daoProviderFactory = DaoProviderFactories.GetFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName);
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
            var userDao = DaoProviderFactories.GetFactory(Settings.Default.DaoProviderClassName).CreateUserDao();
            var users = userDao.GetAllUsers();
            Assert.IsTrue(users.Count > 100);
        }

        #endregion

        #region Database Data Access Test

        [TestMethod]
        public void TestAllUserDbAccess()
        {
            var userDao = DaoProviderFactories.GetFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();
            var users = userDao.GetAllUsers();
            Assert.IsTrue(users.Count > 10);
        }

        #endregion
    }
}
