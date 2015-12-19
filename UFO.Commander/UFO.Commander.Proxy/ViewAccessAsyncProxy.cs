using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Bll.Common;
using BLL = UFO.Server.Domain;
using WS = UFO.Services.ViewAccess;

namespace UFO.Commander.Proxy
{
    public static class ViewAccessAsyncProxy
    {
        private static readonly WS.ViewAccessWsClient ViewAccessWs = new WS.ViewAccessWsClient();

        public static async Task<List<BLL.Artist>> GetArtistAsync(this IViewAccessBll accessBll, BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Artist, BLL.Artist>(
                await ViewAccessWs.GetArtistAsync(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public static async Task<List<BLL.Category>> GetCategoriesAsync(this IViewAccessBll accessBll, BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Category, BLL.Category>(
                await ViewAccessWs.GetCategoriesAsync(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public static async Task<List<BLL.Country>> GetCountriesAsync(this IViewAccessBll accessBll, BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Country, BLL.Country>(
                await ViewAccessWs.GetCountriesAsync(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public static async Task<List<BLL.Location>> GetLocationsAsync(this IViewAccessBll accessBll, BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Location, BLL.Location>(
                await ViewAccessWs.GetLocationsAsync(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public static async Task<List<BLL.Venue>> GetVenuesAsync(this IViewAccessBll accessBll, BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Venue, BLL.Venue>(
                await ViewAccessWs.GetVenuesAsync(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public static async Task<List<BLL.Performance>> GetPerformancesAsync(this IViewAccessBll accessBll, BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Performance, BLL.Performance>(
                await ViewAccessWs.GetPerformancesAsync(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public static async Task<List<BLL.Performance>> GetPerformancesPerDateAsync(this IViewAccessBll accessBll, DateTime date)
        {
            return ProxyHelper.ToListOf<WS.Performance, BLL.Performance>(
                await ViewAccessWs.GetPerformancesPerDateAsync(date));
        }

        public static async Task<BLL.PagingData> RequestArtistPagingDataAsync(this IViewAccessBll accessBll)
        {
            var result = await ViewAccessWs.RequestArtistPagingDataAsync();
            return result.ToDomainObject<BLL.PagingData>();
        }

        public static async Task<BLL.PagingData> RequestCategoryPagingDataAsync(this IViewAccessBll accessBll)
        {
            var result = await ViewAccessWs.RequestCategoryPagingDataAsync();
            return result.ToDomainObject<BLL.PagingData>();
        }

        public static async Task<BLL.PagingData> RequestCountryPagingDataAsync(this IViewAccessBll accessBll)
        {
            var result = await ViewAccessWs.RequestCountryPagingDataAsync();
            return result.ToDomainObject<BLL.PagingData>();
        }

        public static async Task<BLL.PagingData> RequestLocationPagingDataAsync(this IViewAccessBll accessBll)
        {
            var result = await ViewAccessWs.RequestLocationPagingDataAsync();
            return result.ToDomainObject<BLL.PagingData>();
        }

        public static async Task<BLL.PagingData> RequestPerformancePagingDataAsync(this IViewAccessBll accessBll)
        {
            var result = await ViewAccessWs.RequestPerformancePagingDataAsync();
            return result.ToDomainObject<BLL.PagingData>();
        }

        public static async Task<BLL.PagingData> RequestVenuePagingDataAsync(this IViewAccessBll accessBll)
        {
            var result = await ViewAccessWs.RequestVenuePagingDataAsync();
            return result.ToDomainObject<BLL.PagingData>();
        }

    }
}
