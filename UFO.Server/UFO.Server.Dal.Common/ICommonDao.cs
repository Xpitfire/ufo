using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Dal.Common
{
    public interface ICommonDao<TType>
    {
        DaoResponse<TType> Insert(TType entity);
        DaoResponse<TType> Update(TType entity);
        DaoResponse<TType> Delete(TType entity);
        DaoResponse<IList<TType>> GetAll();
        DaoResponse<IList<TType>> GetAllAndFilterBy<T>(T criteria, Filter<TType, T> filter);
    }
}
