using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Commander.Proxy;
using UFO.Commander.ViewModel;
using UFO.Commander.ViewModel.Entities;
using UFO.Server.Bll.Common;

namespace UFO.Commander.Test
{
    [TestClass]
    public class ViewModelTest
    {
        private static readonly IAdminAccessBll AdminAccessBll = BllFactory.CreateAdminAccessBll();
        private static readonly LoginViewModel AuthAccessViewModel = new LoginViewModel();
        private static readonly string EMail = "marius.dinu@mymail.com";
        private static readonly string Password = "password";
        
        [TestMethod]
        public void UserCollectionPageFirstViewModelTest()
        {
            var response = AuthAccessViewModel.RequestSessionToken(EMail, Password);
            Assert.IsTrue(response);
            response = AuthAccessViewModel.Login();
            Assert.IsTrue(response);
            var userCollection = new UserCollectionViewModel(AuthAccessViewModel.CurrentSessionToken);
            userCollection.RequestPagingDataInit();
            userCollection.GetNextPage();
            Assert.IsTrue(userCollection.UserViewModels.Count == userCollection.Page.Request);
        }

        [TestMethod]
        public void UserCollectionPageLastViewModelTest()
        {
            var response = AuthAccessViewModel.RequestSessionToken(EMail, Password);
            Assert.IsTrue(response);
            response = AuthAccessViewModel.Login();
            Assert.IsTrue(response);
            var userCollection = new UserCollectionViewModel(AuthAccessViewModel.CurrentSessionToken);
            userCollection.RequestPagingDataInit();
            userCollection.Page.Offset = 9951;
            userCollection.GetNextPage();
            Assert.IsTrue(userCollection.UserViewModels.Count == userCollection.Page.Request);
            userCollection.UserViewModels.Clear();
            userCollection.GetNextPage();
            Assert.IsTrue(userCollection.UserViewModels.Count == 0);
        }

        [TestMethod]
        public void UserCollectionPageRequestViewModelTest()
        {
            var response = AuthAccessViewModel.RequestSessionToken(EMail, Password);
            Assert.IsTrue(response);
            response = AuthAccessViewModel.Login();
            Assert.IsTrue(response);
            var userCollection = new UserCollectionViewModel(AuthAccessViewModel.CurrentSessionToken);
            userCollection.RequestPagingDataInit();
            Assert.IsTrue(userCollection.Page.Size > 0);
            Assert.IsTrue(userCollection.Page.Remaining > 0);
            Assert.IsTrue(userCollection.Page.Size == userCollection.Page.Remaining);
        }
    }
}
