using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Services;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
using UFO.Server.Common;
using UFO.Server.Common.Properties;
using UFO.Server.Domain;

namespace UFO.Server.Web
{
    /// <summary>
    /// Summary description for WebAccessService
    /// </summary>
    [WebService(Namespace = "http://ufo.at/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebAccessService : WebService
    {
        private static AViewAccessBll _viewAccessDelegate;
        private static readonly AViewAccessBll ViewAccessDelegate = 
            _viewAccessDelegate ?? (_viewAccessDelegate = FactoryProvider.GetFactory<IBllProviderFactory>(BllProviderSettings.Instance).CreateAViewAccessBll());

        private static AAdminAccessBll _adminAccessDelegate;
        private static readonly AAdminAccessBll AdminAccessDelegate =
            _adminAccessDelegate ?? (_adminAccessDelegate = FactoryProvider.GetFactory<IBllProviderFactory>(BllProviderSettings.Instance).CreateAAdminAccessBll());

        [WebMethod]
        public List<Artist> GetArtists(PagingData page) => ViewAccessDelegate.GetArtists(page);

        [WebMethod]
        public Artist GetArtist(int id) => ViewAccessDelegate.GetArtist(id);

        [WebMethod]
        public List<Category> GetCategories(PagingData page) => ViewAccessDelegate.GetCategories(page);

        [WebMethod]
        public List<Country> GetCountries(PagingData page) => ViewAccessDelegate.GetCountries(page);

        [WebMethod]
        public List<Location> GetLocations(PagingData page) => ViewAccessDelegate.GetLocations(page);

        [WebMethod]
        public List<Venue> GetVenues(PagingData page) => ViewAccessDelegate.GetVenues(page);

        [WebMethod]
        public Venue GetVenue(string id) => ViewAccessDelegate.GetVenue(id);

        [WebMethod]
        public List<Performance> GetPerformances(PagingData page) => ViewAccessDelegate.GetPerformances(page);

        [WebMethod]
        public List<Performance> GetLatestPerformances() => ViewAccessDelegate.GetLatestPerformances();

        [WebMethod]
        public List<Performance> GetPerformancesPerDate(DateTime date) => ViewAccessDelegate.GetPerformancesPerDate(date);

        [WebMethod]
        public List<Performance> GetPerformancesPerArtist(Artist artist) => ViewAccessDelegate.GetPerformancesPerArtist(artist);

        [WebMethod]
        public List<Performance> GetPerformancesPerVenue(Venue venue) => ViewAccessDelegate.GetPerformancesPerVenue(venue);

        [WebMethod]
        public PagingData RequestArtistPagingData() => ViewAccessDelegate.RequestArtistPagingData();

        [WebMethod]
        public PagingData RequestCategoryPagingData() => ViewAccessDelegate.RequestCategoryPagingData();

        [WebMethod]
        public PagingData RequestCountryPagingData() => ViewAccessDelegate.RequestCountryPagingData();

        [WebMethod]
        public PagingData RequestLocationPagingData() => ViewAccessDelegate.RequestLocationPagingData();

        [WebMethod]
        public PagingData RequestPerformancePagingData() => ViewAccessDelegate.RequestPerformancePagingData();

        [WebMethod]
        public PagingData RequestVenuePagingData() => ViewAccessDelegate.RequestVenuePagingData();

        [WebMethod]
        public bool IsUserAuthenticated(SessionToken token) => AdminAccessDelegate.IsUserAuthenticated(token);

        [WebMethod]
        public bool LoginAdmin(SessionToken token) => AdminAccessDelegate.LoginAdmin(token);

        [WebMethod]
        public void LogoutAdmin(SessionToken token) => AdminAccessDelegate.LogoutAdmin(token);

        [WebMethod]
        public SessionToken RequestSessionToken(User user) => AdminAccessDelegate.RequestSessionToken(user);

        [WebMethod]
        public bool ModifyPerformance(SessionToken token, Performance performance) => AdminAccessDelegate.ModifyPerformance(token, performance);

        [WebMethod]
        public List<Performance> SearchPerformancesPerKeyword(string keyword) => ViewAccessDelegate.SearchPerformancesPerKeyword(keyword);

        [WebMethod]
        public List<Venue> SearchVenuesPerKeyword(string keyword) => ViewAccessDelegate.SearchVenuesPerKeyword(keyword);

        [WebMethod]
        public List<Artist> SearchArtistsPerKeyword(string keyword) => ViewAccessDelegate.SearchArtistsPerKeyword(keyword);

        [WebMethod]
        public List<string> GetPerformanceAutoCompletion(string keyword) => ViewAccessDelegate.GetPerformanceAutoCompletion(keyword);
    }
}
