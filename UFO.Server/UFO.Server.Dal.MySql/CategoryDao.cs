﻿#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
//     Wurm Florian
#endregion
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

        private Dictionary<string, QueryParameter> CreateCategoryParameter(Category entity)
        {
            return new Dictionary<string, QueryParameter>
            {
                {"?CategoryId", new QueryParameter {ParameterValue = entity.CategoryId}},
                {"?Name", new QueryParameter {ParameterValue = entity.Name}}
            };
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

        [DaoExceptionHandler(typeof(Category))]
        public DaoResponse<Category> Insert(Category entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.InsertCategory, CreateCategoryParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessfull(entity);
            }
        }

        [DaoExceptionHandler(typeof(Category))]
        public DaoResponse<Category> Update(Category entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.UpdateCategory, CreateCategoryParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessfull(entity);
            }
        }
        
        [DaoExceptionHandler(typeof(Category))]
        public DaoResponse<Category> Delete(Category entity)
        {
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand(connection, SqlQueries.DeleteCategory, CreateCategoryParameter(entity)))
            {
                _dbCommProvider.ExecuteNonQuery(command);
                return DaoResponse.QuerySuccessfull(entity);
            }
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