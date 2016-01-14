using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Services;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
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
        private readonly AViewAccessBll _viewAccessDelegate = new ViewAccessBll();

        [WebMethod]
        public List<Artist> GetArtist(PagingData page)
        {
            var test = UFO.Server.Common.Properties.Settings.Default.DaoProviderAssemblyName;
            var test2 = UFO.Server.Web.Properties.Settings.Default.DaoProviderAssemblyName;
            return _viewAccessDelegate.GetArtist(page);
        }

        [WebMethod]
        public List<Category> GetCategories(PagingData page)
        {
            return _viewAccessDelegate.GetCategories(page);
        }

        [WebMethod]
        public List<Country> GetCountries(PagingData page)
        {
            return _viewAccessDelegate.GetCountries(page);
        }

        [WebMethod]
        public List<Location> GetLocations(PagingData page)
        {
            return _viewAccessDelegate.GetLocations(page);
        }

        [WebMethod]
        public List<Venue> GetVenues(PagingData page)
        {
            return _viewAccessDelegate.GetVenues(page);
        }

        [WebMethod]
        public List<Performance> GetPerformances(PagingData page)
        {
            return _viewAccessDelegate.GetPerformances(page);
        }

        [WebMethod]
        public List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return _viewAccessDelegate.GetPerformancesPerDate(date);
        }

        [WebMethod]
        public PagingData RequestArtistPagingData()
        {
            return _viewAccessDelegate.RequestArtistPagingData();
        }

        [WebMethod]
        public PagingData RequestCategoryPagingData()
        {
            return _viewAccessDelegate.RequestCategoryPagingData();
        }

        [WebMethod]
        public PagingData RequestCountryPagingData()
        {
            return _viewAccessDelegate.RequestCountryPagingData();
        }

        [WebMethod]
        public PagingData RequestLocationPagingData()
        {
            return _viewAccessDelegate.RequestLocationPagingData();
        }

        [WebMethod]
        public PagingData RequestPerformancePagingData()
        {
            return _viewAccessDelegate.RequestPerformancePagingData();
        }

        [WebMethod]
        public PagingData RequestVenuePagingData()
        {
            return _viewAccessDelegate.RequestVenuePagingData();
        }
    }
}
