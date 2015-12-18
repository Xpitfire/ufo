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
        public static IViewAccessBll ViewAccessBll => BllFactory.CreateViewAccessBll();
        public static IAdminAccessBll AuthAccessBll => BllFactory.CreateAdminAccessBll();
        public static SessionToken SessionToken { get; set; }
    }
}
