using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IUserDao
    {
        DaoResponse<User> UpdateUserCredentials(User user);

        IList<User> GetAllUsers();

        IList<User> GetUsers<T>(T criteria, Filter<User, T> filter);
    }
}