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
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;
using UFO.Server.Properties;

namespace UFO.Server.Test
{
    [TestClass]
    public class ServerTests
    {
        // Artist, User, Venue, Category, Country, Performance => GettAlFilterby, SelectAll, Insert, Update, Delete

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
            var dao = daoProviderFactory.CreateUserDao();
            var result = dao.SelectByEmail("marius.dinu@mail.com");
            var user = result.ResultObject;

            Assert.IsNotNull(result.ResultObject);
            Assert.IsTrue("Marius" == user?.FirstName && "Dinu" == user.LastName);
        }

        #endregion

        #region Dummy Data Tests
        
        [TestMethod]
        public void TestAllGeneratedUsers()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateUserDao();
            var users = dao.SelectAll();
            Assert.IsTrue(users.ResultObject?.Count > 100);
        }

        /// <summary>
        /// The country DAO has no implementation. This test checks if the DaoExceptionHandler attribute
        /// handles the exception properly.
        /// </summary>
        [TestMethod]
        public void TestDaoExceptionHandler()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDummyDaoAssembly,
                TestDummyDaoNameSpace,
                TestDummyDaoClassName).CreateCountryDao();
            dao.SelectAll()
                .OnSuccess(() => Assert.Fail("Response should have failed due to test of Exception handling."));
        }

        #endregion


        #region Database Data Access Test

        // User Tests

        [TestMethod]
        public void TestAllUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();
            DaoResponse<IList<User>> response = dao.SelectAll();
            Assert.IsTrue(response.ResultObject?.Count > 10);
        }
        /// <summary>
        /// User.Insert Method is not implemented!
        /// </summary>
        [TestMethod]
        public void TestInsertUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            using (var scope = new TransactionScope())
            {
                var user = new User
                {
                    FirstName = "Horst",
                    LastName = "Futtinghartsberger",
                    EMail = "horst@futti.com",
                    Password = "horsti123",
                    IsAdmin = false,
                    IsArtist = false,
                    Artist = null
                };

                dao.Insert(user)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByEmail("marius.dinu@mymail.com");
                Assert.IsNotNull(getRsp);
                var user = getRsp.ResultObject;
                user.FirstName = "Test";

                dao.Update(user)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteUserDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateUserDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectById(6);
                Assert.IsNotNull(getRsp);
                var user = getRsp.ResultObject;
                
                dao.Delete(user)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Category Tests

        [TestMethod]
        public void TestAllCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory().CreateCategoryDao();
            var categories = dao.SelectAll().ResultObject;
            Assert.IsNotNull(categories);
            Assert.IsTrue(categories.Any());
        }

        [TestMethod]
        public void TestInsertCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();
            using (var scope = new TransactionScope())
            {
                var category = new Category
                {
                    CategoryId = "KT",
                    Name = "Klassik Tanz"
                };
                dao.Insert(category)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));
                
                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectById("OT");
                Assert.IsNotNull(getRsp);
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Delete(category)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateCategoryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("Tanz");
                Assert.IsNotNull(getRsp);
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Update(category)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Country Tests

        [TestMethod]
        public void TestAllCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory().CreateCountryDao();
            var countries = dao.SelectAll().ResultObject;
            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Any());
        }

        [TestMethod]
        public void TestInsertCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();
            using (var scope = new TransactionScope())
            {
                var country = new Country
                {
                    Code="PD",
                    Name ="Pandora"
                };
                dao.Insert(country)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByCode("AT");
                Assert.IsNotNull(getRsp);
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Delete(category)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateCountryDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCountryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("Oman");
                Assert.IsNotNull(getRsp);
                var category = getRsp.ResultObject;
                category.Name = "Test";

                dao.Update(category)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }




        // Artist Tests

        [TestMethod]
        public void TestAllArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
            var artists = dao.SelectAll().ResultObject;
            Assert.IsNotNull(artists);
            Assert.IsTrue(artists.Any());
        }

        [TestMethod]
        public void TestDeleteArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("AC/DC");
                Assert.IsNotNull(getRsp);
                var artist = getRsp.ResultObject;
                artist.Name = "Test";

                dao.Delete(artist)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("AC/DC");
                Assert.IsNotNull(getRsp);
                var artist = getRsp.ResultObject;
                artist.Name = "Test";

                dao.Update(artist)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestInsertArtistDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateArtistDao();

            using (var scope = new TransactionScope())
            {
                var artist = new Artist
                {
                    Name = "The Cohle",
                    Category = new Category { CategoryId = "M" },
                    Country = new Country { Code = "US" },
                    EMail = "test@chole.com",
                    Picture = BlobData.CreateBlobData("/images/prev/blobs.png")
                };

                dao.Insert(artist)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Venue Tests
        [TestMethod]
        public void TestAllVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory().CreateVenueDao();
            var venues = dao.SelectAll().ResultObject;
            Assert.IsNotNull(venues);
            Assert.IsTrue(venues.Any());
        }

        [TestMethod]
        public void TestInsertVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();
            using (var scope = new TransactionScope())
            {
                var venue = new Venue
                {
                    VenueId = "A7", Name = "Tiki Tiki"
                };
                dao.Insert(venue)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeleteVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateVenueDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectById("A1");
                Assert.IsNotNull(getRsp);
                var venue = getRsp.ResultObject;
                venue.Name = "Test";

                dao.Delete(venue)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdateVenueDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreateCategoryDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByName("Landhaus");
                Assert.IsNotNull(getRsp);
                var venue = getRsp.ResultObject;
                venue.Name = "Test";

                dao.Update(venue)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        // Performance Tests
        [TestMethod]
        public void TestAllPerformancesDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
            var performances = dao.SelectAll().ResultObject;
            Assert.IsNotNull(performances);
            Assert.IsTrue(performances.Any());
        }

        [TestMethod]
        public void TestInsertPerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();
            using (var scope = new TransactionScope())
            {
                var performance = new Performance
                {
                    DateTime = new DateTime(2016, 7, 18)
                };

                dao.Insert(performance)
                    .OnFailure(response => Assert.Fail($"Insert does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestDeletePerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByDateTime(new DateTime(2015, 11, 13));
                Assert.IsNotNull(getRsp);
                var performance = getRsp.ResultObject;
                performance.DateTime = new DateTime(2015,11,14);

                dao.Delete(performance)
                    .OnFailure(response => Assert.Fail($"Delete does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        [TestMethod]
        public void TestUpdatePerformanceDbAccess()
        {
            var dao = DalProviderFactories.GetDaoFactory(
                TestDbDaoAssemblyName,
                TestDbDaoNameSpace,
                TestDbDaoClassName).CreatePerformanceDao();

            using (var scope = new TransactionScope())
            {
                var getRsp = dao.SelectByDateTime(new DateTime(2015, 11, 13));
                Assert.IsNotNull(getRsp);
                var performance = getRsp.ResultObject;
                performance.DateTime = new DateTime(2015,11,14);

                dao.Update(performance)
                    .OnFailure(response => Assert.Fail($"Update does not work! {response.Exception}"));

                // do not commit changes; only for testing
                //scope.Complete();
            }
        }

        #endregion
    }
}
