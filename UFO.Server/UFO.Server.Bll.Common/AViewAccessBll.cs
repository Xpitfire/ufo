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
        private static IPerformanceDao _performanceDao;
        protected static IPerformanceDao PerformanceDao = _performanceDao ?? (_performanceDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreatePerformanceDao());
        private static IArtistDao _artistDao;
        protected static IArtistDao ArtistDao = _artistDao ?? (_artistDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateArtistDao());
        private static ICategoryDao _categoryDao;
        protected static ICategoryDao CategoryDao = _categoryDao ?? (_categoryDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateCategoryDao());
        private static ICountryDao _countryDao;
        protected static ICountryDao CountryDao = _countryDao ?? (_countryDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateCountryDao());
        private static ILocationDao _locationDao;
        protected static ILocationDao LocationDao = _locationDao ?? (_locationDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateLocationDao());
        private static IVenueDao _venueDao;
        protected static IVenueDao VenueDao = _venueDao ?? (_venueDao = FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance).CreateVenueDao());
        
        public abstract List<Artist> GetArtists(PagingData page);
        public abstract Artist GetArtist(int id);
        public abstract List<Category> GetCategories(PagingData page);
        public abstract List<Country> GetCountries(PagingData page);
        public abstract List<Location> GetLocations(PagingData page);
        public abstract List<Venue> GetVenues(PagingData page);
        public abstract Venue GetVenue(string id);
        public abstract List<Performance> GetPerformances(PagingData page);
        public abstract List<Performance> GetPerformancesPerDate(DateTime date);
        public abstract List<Performance> GetPerformancesPerArtist(Artist artist);
        public abstract List<Performance> GetPerformancesPerVenue(Venue venue);
        public abstract List<Performance> GetLatestPerformances();
        public abstract List<Performance> SearchPerformancesPerKeyword(string keyword);
        public abstract List<Artist> SearchArtistsPerKeyword(string keyword);
        public abstract List<Venue> SearchVenuesPerKeyword(string keyword);
        public abstract List<string> GetPerformanceAutoCompletion(string keyword);

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
