using System;
using System.Collections.Generic;
using UFO.Server.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public abstract class AViewAccessBll : IViewAccessBll
    {
        protected IPerformanceDao PerformanceDao = DalProviderFactories.GetDaoFactory().CreatePerformanceDao();
        protected IArtistDao ArtistDao = DalProviderFactories.GetDaoFactory().CreateArtistDao();
        protected ICategoryDao CategoryDao = DalProviderFactories.GetDaoFactory().CreateCategoryDao();
        protected ICountryDao CountryDao = DalProviderFactories.GetDaoFactory().CreateCountryDao();
        protected ILocationDao LocationDao = DalProviderFactories.GetDaoFactory().CreateLocationDao();
        protected IVenueDao VenueDao = DalProviderFactories.GetDaoFactory().CreateVenueDao();

        public abstract List<Artist> GetAllArtist();
        public abstract List<Category> GetAllCategories();
        public abstract List<Country> GetAllCountries();
        public abstract List<Location> GetAllLocations();
        public abstract List<Venue> GetAllVenues();
        public abstract List<Performance> GetAllPerformances();
        public abstract List<Performance> GetPerformancesPerDate(DateTime date);
    }
}
