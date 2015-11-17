using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface ICategoryDao
    {
        DaoResponse<Category> GetById(string id);
        
        DaoResponse<IList<Category>> GetAll();
        
        DaoResponse<IList<Category>> GetAllAndFilterBy<T>(T criteria, Filter<Category, T> filter);
    }
}
