using System.Collections.Generic;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    internal class CategoryDao : ICategoryDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public CategoryDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        public DaoResponse<Category> GetById(string id)
        {
            Category country = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?CategoryId", new QueryParameter {ParameterValue = id}}
            };
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectCountryById, parameter))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    country = new Category
                    {
                        CategoryId = (string)dataReader["CategoryId"],
                        Name = (string)dataReader["Name"]
                    };
                }
            }
            return DaoResponse.QuerySuccessfull(country);
        }

        public DaoResponse<IList<Category>> GetAll()
        {
            var categories = new List<Category>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand<MySqlDbType>(connection, SqlQueries.SelectAllCategories))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    var category = new Category()
                    {
                        CategoryId = (string)dataReader["CategoryId"],
                        Name = (string)dataReader["Name"]
                    };
                    categories.Add(category);
                }
            }
            return DaoResponse.QuerySuccessfull<IList<Category>>(categories);
        }

        public DaoResponse<IList<Category>> GetAllAndFilterBy<T>(T criteria, Filter<Category, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Category>>(
                new List<Category>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}