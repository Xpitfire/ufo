using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public abstract class AViewAccessBll : IViewAccessBll
    {
        public abstract List<Artist> GetAllArtist();
        public abstract List<Artist> GetArtistWhereCatrgory(Category category);
        public abstract List<Category> GetAllCategories();
        public abstract List<Country> GetAllCountries();
        public abstract List<Location> GetAllLocations();
        public abstract List<Venue> GetAllVenues();
    }
}
