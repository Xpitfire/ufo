using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public interface ISessionBll
    {
        SessionToken RequestSessionId(User resultObject);
        void DeleteUserSession(SessionToken token);
        void RegisterUserSession(SessionToken token, IAuthAccessBll aAdminAccessBll);
        User GetUserFromSession(SessionToken token);
    }
}
