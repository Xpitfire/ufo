using System.Collections.Generic;
using System.Linq;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class DummyUserDeo : IUserDao
    {
        public DaoResponse<User> UpdateUserCredentials(User user)
        {
            throw new System.NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            return DummyDataCollection.Users.ToList();
        }
        
        public IList<User> GetUsers<T>(T criteria, Filter<User, T> filter)
        {
            return filter(DummyDataCollection.Users, criteria).ToList();
        }
    }
}
