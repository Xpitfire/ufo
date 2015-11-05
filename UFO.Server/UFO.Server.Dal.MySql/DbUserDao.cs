using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
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
