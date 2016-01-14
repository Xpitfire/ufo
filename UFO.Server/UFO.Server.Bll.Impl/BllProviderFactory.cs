using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Bll.Common;

namespace UFO.Server.Bll.Impl
{
    class BllProviderFactory : IBllProviderFactory
    {
        public AAdminAccessBll CreateAAdminAccessBll() => new AdminAccessBll();

        public AViewAccessBll CreateAViewAccessBll() => new ViewAccessBll();
    }
}
