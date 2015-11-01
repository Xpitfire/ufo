using System.Collections.Generic;
using System.Linq;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Dao.Impl;
using FH.SEv.UFO.Server.Model.Entities;
using FH.SEv.UFO.Server.Model.Helper;

namespace FH.SEv.UFO.Server.DAO.Impl
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
