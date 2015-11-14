using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class IArtistDaoExtension
    {
        public static DaoResponse<Artist> GetAllAndFilterById(this IArtistDao userDao, int id)
        {
            Filter<Artist, int> filter = (users, criteria) => users.Where(x => x.ArtistId == criteria);
            return DaoResponse.QuerySuccessfull(userDao.GetAllAndFilterBy(id, filter).ResultObject?.First());
        }
    }
}
