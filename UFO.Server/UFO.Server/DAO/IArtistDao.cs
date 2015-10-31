using System.Collections.Generic;
using FH.SEv.UFO.Server.Model.Commands;
using FH.SEv.UFO.Server.Model.Entities;

namespace FH.SEv.UFO.Server.Dao
{
    public interface IArtistDao
    {
        DaoResponse<Artist> InsertArtist(Artist artist);

        DaoResponse<Artist> UpdateArtist(Artist artist);

        DaoResponse<Artist> DeleteArtist(Artist artist);

        IList<Artist> GetAllArtists();

        IList<Artist> GetArtists(Filter<User, string> filter);
    }
}