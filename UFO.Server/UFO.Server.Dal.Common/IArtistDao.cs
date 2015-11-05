using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface IArtistDao
    {
        DaoResponse<Artist> InsertArtist(Artist artist);

        DaoResponse<Artist> UpdateArtist(Artist artist);

        DaoResponse<Artist> DeleteArtist(Artist artist);

        IList<Artist> GetAllArtists();

        IList<Artist> GetArtists<T>(T criteria, Filter<Artist, T> filter);
    }
}