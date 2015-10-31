using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IUserDao
    {
        DaoResponse<User> UpdateUserCredentials(User user);

        IList<User> GetAllUsers();

        IList<User> GetUsers(Filter<User, string> filter);
    }
}