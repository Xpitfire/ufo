using System.Collections.Generic;
using System.Linq;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class UserDaoExtension
    {
        public static DaoResponse<User> GetByEmail(this IUserDao userDao, string email)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.EMail == criteria);
            return DaoResponse.QuerySuccessfull(userDao.Get(email, filter).ResultObject.First());
        }

        public static DaoResponse<IList<User>> GetByLastName(this IUserDao userDao, string name)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.LastName == criteria);
            return userDao.Get(name, filter);
        }

        public static DaoResponse<IList<User>> GetByFirstName(this IUserDao userDao, string name)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.FistName == criteria);
            return userDao.Get(name, filter);
        }

        public static DaoResponse<User> GetById(this IUserDao userDao, int id)
        {
            Filter<User, int> filter = (users, criteria) => users.Where(x => x.UserId == criteria);
            return DaoResponse.QuerySuccessfull(userDao.Get(id, filter).ResultObject.First());
        }
    }
}
