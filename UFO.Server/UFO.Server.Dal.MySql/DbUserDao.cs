using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;
using FH.SEv.UFO.Server.Provider;

namespace FH.SEv.UFO.Server.Dao.Impl
{
    class DbUserDao : IUserDao
    {
        public DaoResponse<User> UpdateUserCredentials(User user)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAllUsers()
        {
            var users = new List<User>();
            using (DbConnection connection = DbCommProviderFactory.CreateDbConnection())
            using (IDbCommand command = DbCommProviderFactory.CreateDbCommand(connection, "SELECT * FROM user"))
            using (IDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    var user = new User
                    {
                        ArtistId = (int) dataReader["ID"],
                        FistName = (string) dataReader["FirstName"]
                    };
                    users.Add(user);
                }
            }
            return users;
        }

        public IList<User> GetUsers<T>(T criteria, Filter<User, T> filter)
        {
            throw new NotImplementedException();
        }
    }
}
