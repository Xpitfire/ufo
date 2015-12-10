using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public class SessionHandler
    {
        public static SessionHandler Instance => new SessionHandler();

        private readonly Dictionary<User, IAuthAccessBll> _sessionDirectory = new Dictionary<User, IAuthAccessBll>();

        private SessionHandler()
        {
        }

        public void CreateUserSession(User user, IAuthAccessBll authAccessBll)
        {
            lock (_sessionDirectory)
            {
                RemoveUserSession(user);
                _sessionDirectory[user] = authAccessBll;
            }
        }

        public void RemoveUserSession(User user)
        {
            lock (_sessionDirectory)
            {
                if (_sessionDirectory.ContainsKey(user))
                {
                    _sessionDirectory[user].LogoutAdmin();
                    _sessionDirectory.Remove(user);
                }
            }
        }

    }
}
