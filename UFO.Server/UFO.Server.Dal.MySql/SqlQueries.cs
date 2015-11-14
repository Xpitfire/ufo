using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Dal.MySql
{
    public static class SqlQueries
    {
        public const string SelectAllUser = @"SELECT *
                                                FROM userview";

        public const string UpdateUser = @"UPDATE user 
                                              SET FirstName=?FirstName, LastName=?LastName, Password=?Password, IsAdmin=?IsAdmin, IsArtist=?IsArtist, ArtistId=?ArtistId 
                                            WHERE UserId=?UserId";

        public const string SelectArtistById = @"SELECT * 
                                                   FROM artist 
                                                  WHERE ArtistId=?ArtistId";

        public const string SelectAllArtists =  @"SELECT * 
                                                    FROM artistview";

        public const string SelectAllCountries = @"SELECT * 
                                                     FROM country";

        public const string SelectCountryById = @"SELECT * 
                                                    FROM country 
                                                   WHERE Code=?Code";

        public const string SelectAllCategories = @"SELECT * 
                                                      FROM category";

        public const string SelectCategoryById = @"SELECT * 
                                                     FROM category 
                                                    WHERE CategoryId=?CategoryId";

    }
}
