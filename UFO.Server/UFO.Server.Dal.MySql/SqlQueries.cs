using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFO.Server.Dal.MySql
{
    public static class SqlQueries
    {
        public const string UpdateUser =
            @"UPDATE user SET FirstName=@FirstName, LastName=@LastName, Password=@Password, IsAdmin=@IsAdmin, IsArtist=@IsArtist, ArtistId=@ArtistId WHERE UserId=@UserId";

        public const string SelectArtistById = @"SELECT * FROM artist WHERE ArtistId=@ArtistId";
    }
}
