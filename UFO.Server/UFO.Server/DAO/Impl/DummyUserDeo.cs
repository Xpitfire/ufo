using System.Collections.Generic;
using System.Linq;
using FH.SEv.UFO.Server.Dao;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

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
            throw new System.NotImplementedException();
        }
        
        public IList<User> GetUsers(Filter<User, string> filter)
        {
            var queryResult = new List<User>
            {
                new User
                {
                    ArtistId = 1,
                    EMail = "hallo@mail.com",
                    FistName = "Marius",
                    LastName = "Dinu",
                    PasswordHash = "012345",
                    IsAdmin = false,
                    IsArtist = true
                },
                new User
                {
                    ArtistId = 2,
                    EMail = "test@gmx.com",
                    FistName = "Max",
                    LastName = "Huber",
                    PasswordHash = "67890",
                    IsAdmin = true,
                    IsArtist = false
                }
            };
            return filter(queryResult, "Huber").ToList();
        }
    }
}
