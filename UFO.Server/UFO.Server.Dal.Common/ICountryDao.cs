using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface ICountryDao
    {
        DaoResponse<Country> GetByCode(string code);
        
        DaoResponse<IList<Country>> GetAll();

        DaoResponse<IList<Country>> GetAllAndFilterBy<T>(T criteria, Filter<Country, T> filter);
    }
}
