using System;
using System.Collections.Generic;
using UFO.Server.Bll.Common.Helper;
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

        public abstract List<Artist> GetArtist(PagingData page);
        public abstract List<Category> GetCategories(PagingData page);
        public abstract List<Country> GetCountries(PagingData page);
        public abstract List<Location> GetLocations(PagingData page);
        public abstract List<Venue> GetVenues(PagingData page);
        public abstract List<Performance> GetPerformances(PagingData page);
        public abstract List<Performance> GetPerformancesPerDate(DateTime date);
        
        public virtual PagingData RequestArtistPagingData()
        {
            return PagingHelper.RequestPagingData(ArtistDao);
        }

        public virtual PagingData RequestCategoryPagingData()
        {
            return PagingHelper.RequestPagingData(CategoryDao);
        }

        public virtual PagingData RequestCountryPagingData()
        {
            return PagingHelper.RequestPagingData(CountryDao);
        }

        public virtual PagingData RequestLocationPagingData()
        {
            return PagingHelper.RequestPagingData(LocationDao);
        }

        public virtual PagingData RequestPerformancePagingData()
        {
            return PagingHelper.RequestPagingData(PerformanceDao);
        }

        public virtual PagingData RequestVenuePagingData()
        {
            return PagingHelper.RequestPagingData(VenueDao);
        }
    }
}
