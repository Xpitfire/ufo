using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
using UFO.Server.Common;

namespace UFO.Server.Web.REST
{
    public class ApiDelegate
    {
        public static AViewAccessBll ViewAccessBll()
        {
            return new ViewAccessBll();
        }

    }
}
