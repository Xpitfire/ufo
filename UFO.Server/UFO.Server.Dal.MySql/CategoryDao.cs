using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    class CategoryDao : ICategoryDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public CategoryDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Category CreateCategoryObject(IDataReader dataReader)
        {
            var category = new Category
            {
                CategoryId = _dbCommProvider.CastDbObject<string>(dataReader, "CategoryId"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "Name")
            };
            return category;
        }

        [DaoExceptionHandler(typeof(Category))]
        public DaoResponse<Category> GetById(string id)
        {
            Category category = null;
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
                    category = CreateCategoryObject(dataReader);
                }
            }
            return DaoResponse.QuerySuccessfull(category);
        }

        [DaoExceptionHandler(typeof(IList<Category>))]
        public DaoResponse<IList<Category>> GetAll()
        {
            var categories = new List<Category>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand<MySqlDbType>(connection, SqlQueries.SelectAllCategories))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    categories.Add(CreateCategoryObject(dataReader));
                }
            }
            return DaoResponse.QuerySuccessfull<IList<Category>>(categories);
        }

        [DaoExceptionHandler(typeof(IList<Category>))]
        public DaoResponse<IList<Category>> GetAllAndFilterBy<T>(T criteria, Filter<Category, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Category>>(
                new List<Category>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}