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
        /// <summary>
        /// Select a value from the DAL implementation with a runtime specified lambda expression and a selective filter criteria.
        /// </summary>
        /// <typeparam name="T">Type of the where clause criteria.</typeparam>
        /// <typeparam name="TType">Type of the return value.</typeparam>
        /// <param name="criteria">Where clause criteria.</param>
        /// <param name="dao">Extended object type.</param>
        /// <param name="filterExpression">Expression of the lambda filter used to map the where clause.</param>
        /// <returns>Response object with the collected types.</returns>
        public static DaoResponse<IList<TType>> SelectWhere<TType, T>(this ICommonDao<TType> dao, Expression<Filter<TType, T>> filterExpression, T criteria = default(T))
        {
            return DaoResponse.QuerySuccessful<IList<TType>>(
                new List<TType>(filterExpression.Compile()(dao.SelectAll().ResultObject, criteria)));
        }

        /// <summary>
        /// Select a value from the DAL implementation with a runtime specified lambda expression.
        /// </summary>
        /// <typeparam name="TType">Type of the return value.</typeparam>
        /// <param name="dao">Extended object type.</param>
        /// <param name="filterExpression">Expression of the lambda filter used to map the where clause.</param>
        /// <returns>Response object with the collected types.</returns>
        public static DaoResponse<IList<TType>> SelectWhere<TType>(this ICommonDao<TType> dao, Expression<Filter<TType>> filterExpression)
        {
            return DaoResponse.QuerySuccessful<IList<TType>>(
                new List<TType>(filterExpression.Compile()(dao.SelectAll().ResultObject)));
        }
    }
}
