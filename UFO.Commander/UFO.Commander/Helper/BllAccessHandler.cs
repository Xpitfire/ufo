using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Commander.Proxy;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

namespace UFO.Commander.Helper
{
    class BllAccessHandler
    {
        private static IViewAccessBll _viewAccessBll;
        public static IViewAccessBll ViewAccessBll => _viewAccessBll ?? (_viewAccessBll = BllFactory.CreateViewAccessBll());
        private static IAdminAccessBll _adminAccessBll;
        public static IAdminAccessBll AdminAccessBll => _adminAccessBll ?? (_adminAccessBll = BllFactory.CreateAdminAccessBll());
        public static SessionToken SessionToken { get; set; }

        public static void Reconnect()
        {
            _viewAccessBll = BllFactory.CreateViewAccessBll();
            _adminAccessBll = BllFactory.CreateAdminAccessBll();
        }
    }
}
