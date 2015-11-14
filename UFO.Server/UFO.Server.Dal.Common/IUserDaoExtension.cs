using System.Collections.Generic;
using System.Linq;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class IUserDaoExtension
    {
        public static DaoResponse<User> GetAllAndFilterByEmail(this IUserDao userDao, string email)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.EMail == criteria);
            return DaoResponse.QuerySuccessfull(userDao.GetAllAndFilterBy(email, filter).ResultObject?.First());
        }

        public static DaoResponse<IList<User>> GetAllAndFilterByLastName(this IUserDao userDao, string name)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.LastName == criteria);
            return userDao.GetAllAndFilterBy(name, filter);
        }

        public static DaoResponse<IList<User>> GetAllAndFilterByFirstName(this IUserDao userDao, string name)
        {
            Filter<User, string> filter = (users, criteria) => users.Where(x => x.FistName == criteria);
            return userDao.GetAllAndFilterBy(name, filter);
        }

        public static DaoResponse<User> GetAllAndFilterById(this IUserDao userDao, int id)
        {
            Filter<User, int> filter = (users, criteria) => users.Where(x => x.UserId == criteria);
            return DaoResponse.QuerySuccessfull(userDao.GetAllAndFilterBy(id, filter).ResultObject?.First());
        }
    }
}
