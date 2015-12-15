#region copyright
// (C) Copyright 2015 Dinu Marius-Constantin (http://dinu.at) and others.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Contributors:
//     Dinu Marius-Constantin
#endregion
using System;
using System.Collections.Generic;
using UFO.Server.Bll.Common;
using BLL = UFO.Server.Domain;
using WS = UFO.Services.ViewAccess;

namespace UFO.Commander.Proxy
{
    public class ViewAccessProxy : IViewAccessBll
    {
        private readonly WS.ViewAccessWsClient _viewAccessWs = new WS.ViewAccessWsClient();

        public List<BLL.Artist> GetArtist(BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Artist, BLL.Artist>(
                _viewAccessWs.GetArtist(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public List<BLL.Category> GetCategories(BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Category, BLL.Category>(
                _viewAccessWs.GetCategories(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public List<BLL.Country> GetCountries(BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Country, BLL.Country>(
                _viewAccessWs.GetCountries(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public List<BLL.Location> GetLocations(BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Location, BLL.Location>(
                _viewAccessWs.GetLocations(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public List<BLL.Venue> GetVenues(BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Venue, BLL.Venue>(
                _viewAccessWs.GetVenues(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public List<BLL.Performance> GetPerformances(BLL.PagingData page)
        {
            return ProxyHelper.ToListOf<WS.Performance, BLL.Performance>(
                _viewAccessWs.GetPerformances(page.ToWebSeriveObject<WS.PagingData>()));
        }

        public List<BLL.Performance> GetPerformancesPerDate(DateTime date)
        {
            return ProxyHelper.ToListOf<WS.Performance, BLL.Performance>(
                _viewAccessWs.GetPerformancesPerDate(date));
        }

        public BLL.PagingData RequestArtistPagingData()
        {
            return _viewAccessWs.RequestArtistPagingData().ToDomainObject<BLL.PagingData>();
        }

        public BLL.PagingData RequestCategoryPagingData()
        {
            return _viewAccessWs.RequestCategoryPagingData().ToDomainObject<BLL.PagingData>();
        }

        public BLL.PagingData RequestCountryPagingData()
        {
            return _viewAccessWs.RequestCountryPagingData().ToDomainObject<BLL.PagingData>();
        }

        public BLL.PagingData RequestLocationPagingData()
        {
            return _viewAccessWs.RequestLocationPagingData().ToDomainObject<BLL.PagingData>();
        }

        public BLL.PagingData RequestPerformancePagingData()
        {
            return _viewAccessWs.RequestPerformancePagingData().ToDomainObject<BLL.PagingData>();
        }

        public BLL.PagingData RequestVenuePagingData()
        {
            return _viewAccessWs.RequestVenuePagingData().ToDomainObject<BLL.PagingData>();
        }
    }
}
