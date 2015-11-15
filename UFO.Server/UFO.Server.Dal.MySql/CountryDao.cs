using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.MySql
{
    internal class CountryDao : ICountryDao
    {
        private readonly ADbCommProvider _dbCommProvider;

        public CountryDao(ADbCommProvider dbCommProvider)
        {
            this._dbCommProvider = dbCommProvider;
        }

        private Country CreateCountryObject(IDataReader dataReader)
        {
            var country = new Country
            {
                Code = _dbCommProvider.CastDbObject<string>(dataReader, "Code"),
                Name = _dbCommProvider.CastDbObject<string>(dataReader, "Name")
            };
            return country;
        }

        public DaoResponse<Country> GetByCode(string code)
        {
            Country country = null;
            var parameter = new Dictionary<string, QueryParameter>
            {
                {"?Code", new QueryParameter {ParameterValue = code}}
            };
            using (var connection =     _dbCommProvider.CreateDbConnection())
            using (var command =        _dbCommProvider.CreateDbCommand(connection, SqlQueries.SelectCountryById, parameter))
            using (var dataReader =     _dbCommProvider.ExecuteReader(command))
            {
                if (dataReader.Read())
                {
                    country = CreateCountryObject(dataReader);
                }
            }
            return DaoResponse.QuerySuccessfull(country);
        }

        public DaoResponse<IList<Country>> GetAll()
        {
            var countries = new List<Country>();
            using (var connection = _dbCommProvider.CreateDbConnection())
            using (var command = _dbCommProvider.CreateDbCommand<MySqlDbType>(connection, SqlQueries.SelectAllCountries))
            using (var dataReader = _dbCommProvider.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    countries.Add(CreateCountryObject(dataReader));
                }
            }
            return DaoResponse.QuerySuccessfull<IList<Country>>(countries);
        }

        public DaoResponse<IList<Country>> GetAllAndFilterBy<T>(T criteria, Filter<Country, T> filter)
        {
            return DaoResponse.QuerySuccessfull<IList<Country>>(
                new List<Country>(filter.Invoke(GetAll().ResultObject, criteria)));
        }
    }
}