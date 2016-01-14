using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UFO.Server.Test
{
    [TestClass]
    public class ServerWsTest
    {
        [TestMethod]
        public void WebAccessTest()
        {
            Web.WebAccessService service = new Web.WebAccessService();
            var page = service.RequestArtistPagingData();
            Assert.IsTrue(page != null && page.Size > 0);
        }
    }
}
