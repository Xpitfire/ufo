using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;

using BLL = UFO.Server.Domain;
using WS = UFO.Services.AdminAccess;

namespace UFO.Commander.Proxy
{
    public static class AdminAccessAsyncProxyExtensions
    {
        private static readonly WS.AdminAccessWs AdminAccessWs = new WS.AdminAccessWsClient();

        public static async Task<bool> IsUserAuthenticatedAsync(this IAdminAccessBll accessBll, SessionToken token)
        {
            return await AdminAccessWs.IsUserAuthenticatedAsync(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public static async Task<bool> IsValidAdminAsync(this IAdminAccessBll accessBll, SessionToken token)
        {
            return await AdminAccessWs.IsValidAdminAsync(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public static async Task<bool> LoginAdminAsync(this IAdminAccessBll accessBll, SessionToken token)
        {
            return await AdminAccessWs.LoginAdminAsync(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public static async Task LogoutAdminAsync(this IAdminAccessBll accessBll, SessionToken token)
        {
            await AdminAccessWs.LogoutAdminAsync(token.ToWebSeriveObject<WS.SessionToken>());
        }

        public static async Task<SessionToken> RequestSessionTokenAsync(this IAdminAccessBll accessBll, User user)
        {
            var result = await AdminAccessWs.RequestSessionTokenAsync(user.ToWebSeriveObject<WS.User>());
            return result.ToDomainObject<BLL.SessionToken>();
        }

        public static async Task<List<User>> GetUserAsync(this IAdminAccessBll accessBll, SessionToken token, PagingData page)
        {
            var result = await AdminAccessWs.GetUsersAsync(
                            token.ToWebSeriveObject<WS.SessionToken>(),
                            page.ToWebSeriveObject<WS.PagingData>());
            return ProxyHelper.ToListOf<WS.User, BLL.User>(result);
        }

        public static async Task<List<User>> SearchUsersPerKeywordAsync(this IAdminAccessBll accessBll, SessionToken token, string keyword)
        {
            var result = await AdminAccessWs.SearchUsersPerKeywordAsync(
                            token.ToWebSeriveObject<WS.SessionToken>(),
                            keyword);
            return ProxyHelper.ToListOf<WS.User, BLL.User>(result);
        }

        public static async Task<PagingData> RequestUserPagingDataAsync(this IAdminAccessBll accessBll, SessionToken token)
        {
            var result = await AdminAccessWs.RequestUserPagingDataAsync(
                token.ToWebSeriveObject<WS.SessionToken>());
            return result.ToDomainObject<BLL.PagingData>();
        }

        public static async Task<bool> ModifyArtistRangeAsync(this IAdminAccessBll accessBll, SessionToken token, List<Artist> artists)
        {
            var artistsWs = ProxyHelper.ToArrayOf<BLL.Artist, WS.Artist>(artists);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyArtistRangeAsync(tokenWs, artistsWs);
        }

        public static async Task<bool> ModifyArtistAsync(this IAdminAccessBll accessBll, SessionToken token, Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyArtistAsync(tokenWs, artistWs);
        }

        public static async Task<bool> RemoveArtistAsync(this IAdminAccessBll accessBll, SessionToken token, Artist artist)
        {
            var artistWs = artist.ToWebSeriveObject<WS.Artist>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.RemoveArtistAsync(tokenWs, artistWs);
        }

        public static async Task<bool> ModifyVenueRangeAsync(this IAdminAccessBll accessBll, SessionToken token, List<Venue> venues)
        {
            var venuesWs = ProxyHelper.ToArrayOf<BLL.Venue, WS.Venue>(venues);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyVenueRangeAsync(tokenWs, venuesWs);
        }

        public static async Task<bool> ModifyVenueAsync(this IAdminAccessBll accessBll, SessionToken token, Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyVenueAsync(tokenWs, venueWs);
        }

        public static async Task<bool> RemoveVenueAsync(this IAdminAccessBll accessBll, SessionToken token, Venue venue)
        {
            var venueWs = venue.ToWebSeriveObject<WS.Venue>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.RemoveVenueAsync(tokenWs, venueWs);
        }

        public static async Task<bool> ModifyPerformanceRangeAsync(this IAdminAccessBll accessBll, SessionToken token, List<Performance> performances)
        {
            var performancesWs = ProxyHelper.ToArrayOf<BLL.Performance, WS.Performance>(performances);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyPerformanceRangeAsync(tokenWs, performancesWs);
        }

        public static async Task<bool> ModifyPerformanceAsync(this IAdminAccessBll accessBll, SessionToken token, Performance performance)
        {
            var performanceWs = performance.ToWebSeriveObject<WS.Performance>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyPerformanceAsync(tokenWs, performanceWs);
        }

        public static async Task<bool> RemovePerformanceAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, BLL.Performance performance)
        {
            var performanceWs = performance.ToWebSeriveObject<WS.Performance>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.RemovePerformanceAsync(tokenWs, performanceWs);
        }

        public static async Task<bool> ModifyLocationRangeAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, List<BLL.Location> locations)
        {
            var locationsWs = ProxyHelper.ToArrayOf<BLL.Location, WS.Location>(locations);
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyLocationRangeAsync(tokenWs, locationsWs);
        }

        public static async Task<bool> ModifyLocationAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, BLL.Location location)
        {
            var locationWs = location.ToWebSeriveObject<WS.Location>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.ModifyLocationAsync(tokenWs, locationWs);
        }

        public static async Task<bool> RemoveLocationAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, BLL.Location location)
        {
            var locationWs = location.ToWebSeriveObject<WS.Location>();
            var tokenWs = token.ToWebSeriveObject<WS.SessionToken>();
            return await AdminAccessWs.RemoveLocationAsync(tokenWs, locationWs);
        }
        
        public static async Task<List<string>> GetUserAutoCompletionAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, string keyword)
        {
            return (await AdminAccessWs.GetUserAutoCompletionAsync(
                token.ToWebSeriveObject<WS.SessionToken>(),
                keyword))?.ToList();
        }

        public static async Task<bool> SendNotificationAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, BLL.Notification notification)
        {
            return await AdminAccessWs.SendNotificationAsync(token.ToWebSeriveObject<WS.SessionToken>(),
                notification.ToWebSeriveObject<WS.Notification>());
        }

        public static async Task<bool> DelayPerformanceAsync(this IAdminAccessBll accessBll, BLL.SessionToken token, BLL.Performance oldPerformance, BLL.Performance newPerformance)
        {
            return await AdminAccessWs.DelayPerformanceAsync(token.ToWebSeriveObject<WS.SessionToken>(),
                oldPerformance.ToWebSeriveObject<WS.Performance>(), newPerformance.ToWebSeriveObject<WS.Performance>());
        }
    }
}
