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
        protected IPerformanceDao PerformanceDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreatePerformanceDao();
        protected IArtistDao ArtistDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateArtistDao();
        protected ICategoryDao CategoryDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateCategoryDao();
        protected ICountryDao CountryDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateCountryDao();
        protected ILocationDao LocationDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateLocationDao();
        protected IVenueDao VenueDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateVenueDao();

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
