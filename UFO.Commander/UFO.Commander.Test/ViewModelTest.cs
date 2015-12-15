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
        private static readonly AuthAccessViewModel AuthAccessViewModel = new AuthAccessViewModel();

        static ViewModelTest()
        {
            AuthAccessViewModel.RequestSessionToken("marius.dinu@mymail.com", "password");
            AuthAccessViewModel.Login();
        }

        [TestMethod]
        public void UserCollectionViewModelTest()
        {
            var userCollection = new UserCollectionViewModel(AuthAccessViewModel.CurrentSessionToken);
            Assert.IsTrue(userCollection.UserCollection.Any());
        }
    }
}
