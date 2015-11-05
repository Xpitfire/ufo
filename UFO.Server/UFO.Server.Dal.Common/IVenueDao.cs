using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public interface IVenueDao
    {
        DaoResponse<Venue> InsertVenue(Venue venue);

        DaoResponse<Venue> UpdateVenue(Venue venue);

        IList<Venue> GetAllVenues();

        IList<Venue> GetVenues<T>(T criteria, Filter<Venue, T> filter);
    }
}