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
        public List<Artist> GetArtist(PagingData page)
        {
            return ViewAccessDelegate.GetArtist(page);
        }

        [WebMethod]
        public List<Category> GetCategories(PagingData page)
        {
            return ViewAccessDelegate.GetCategories(page);
        }

        [WebMethod]
        public List<Country> GetCountries(PagingData page)
        {
            return ViewAccessDelegate.GetCountries(page);
        }

        [WebMethod]
        public List<Location> GetLocations(PagingData page)
        {
            return ViewAccessDelegate.GetLocations(page);
        }

        [WebMethod]
        public List<Venue> GetVenues(PagingData page)
        {
            return ViewAccessDelegate.GetVenues(page);
        }

        [WebMethod]
        public List<Performance> GetPerformances(PagingData page)
        {
            return ViewAccessDelegate.GetPerformances(page);
        }

        [WebMethod]
        public List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return ViewAccessDelegate.GetPerformancesPerDate(date);
        }

        [WebMethod]
        public PagingData RequestArtistPagingData()
        {
            return ViewAccessDelegate.RequestArtistPagingData();
        }

        [WebMethod]
        public PagingData RequestCategoryPagingData()
        {
            return ViewAccessDelegate.RequestCategoryPagingData();
        }

        [WebMethod]
        public PagingData RequestCountryPagingData()
        {
            return ViewAccessDelegate.RequestCountryPagingData();
        }

        [WebMethod]
        public PagingData RequestLocationPagingData()
        {
            return ViewAccessDelegate.RequestLocationPagingData();
        }

        [WebMethod]
        public PagingData RequestPerformancePagingData()
        {
            return ViewAccessDelegate.RequestPerformancePagingData();
        }

        [WebMethod]
        public PagingData RequestVenuePagingData()
        {
            return ViewAccessDelegate.RequestVenuePagingData();
        }

        [WebMethod]
        public bool IsUserAuthenticated(SessionToken token)
        {
            return AdminAccessDelegate.IsUserAuthenticated(token);
        }

        [WebMethod]
        public bool LoginAdmin(SessionToken token)
        {
            return AdminAccessDelegate.LoginAdmin(token);
        }

        [WebMethod]
        public void LogoutAdmin(SessionToken token)
        {
            AdminAccessDelegate.LogoutAdmin(token);
        }

        [WebMethod]
        public SessionToken RequestSessionToken(User user)
        {
            return AdminAccessDelegate.RequestSessionToken(user);
        }

        [WebMethod]
        public bool ModifyPerformance(SessionToken token, Performance performance)
        {
            return AdminAccessDelegate.ModifyPerformance(token, performance);
        }
    }
}
