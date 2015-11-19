using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class CategoryDao : ICategoryDao
    {
        public DaoResponse<Category> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Category> Insert(Category entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Category> Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Category> Delete(Category entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<IList<Category>> GetAll()
        {
            throw new NotImplementedException();
        }
        
        public DaoResponse<IList<Category>> GetAllAndFilterBy<T>(T criteria, Filter<Category, T> filter)
        {
            throw new NotImplementedException();
        }
    }
}
