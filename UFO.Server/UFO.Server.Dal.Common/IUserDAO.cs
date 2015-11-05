using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface IUserDao
    {
        DaoResponse<User> UpdateUserCredentials(User user);

        IList<User> GetAllUsers();

        IList<User> GetUsers<T>(T criteria, Filter<User, T> filter);
    }
}