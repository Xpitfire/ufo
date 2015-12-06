using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Dal.Common
{
    public static class ICommonDaoExtension
    {
        public static IEnumerable<IEnumerable<TType>> SelectWhere<TType>(this ICommonDao<TType> commonDao, Expression<Func<TType, bool>> filterExpression)
        {
            Expression<Filter<TType, TType>> innerExpression = (values, criteria) => yield return commonDao.SelectAll().ResultObject.Select(type => commonDao.SelectAll().ResultObject.Where(value => filterExpression.Compile()(type)));
            //return commonDao.SelectWhere(innerExpression, default(TType));
        }

        //public static DaoResponse<IList<TType>> SelectWhere<TType>(this ICommonDao<TType> commonDao, Expression<Func<IList<TType>, bool>> filterExpression)
        //{
        //    Expression<Filter<TType, TType>> innerExpression =
        //        (values, criteria) => values.Where(value => filterExpression.Compile()(commonDao.SelectAll().ResultObject));
        //    return commonDao.SelectWhere(innerExpression, default(TType));
        //}
    }
}
