using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;

namespace UFO.Server.Test
{
    [TestClass]
    public class ServerBllTests
    {
        [TestMethod]
        public void TestArtistBllGetAll()
        {
            var artistAccessBll = new ArtistAccess();
            var list = artistAccessBll.GetAll();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count > 0);
        }
    }
}
