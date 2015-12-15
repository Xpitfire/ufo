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

        public List<BLL.Artist> GetAllArtist()
        {
            return ProxyHelper.ToListOf<WS.Artist, BLL.Artist>(_viewAccessWs.GetAllArtist());
        }

        public List<BLL.Category> GetAllCategories()
        {
            return ProxyHelper.ToListOf<WS.Category, BLL.Category>(_viewAccessWs.GetAllCategories());
        }

        public List<BLL.Country> GetAllCountries()
        {
            return ProxyHelper.ToListOf<WS.Country, BLL.Country>(_viewAccessWs.GetAllCountries());
        }

        public List<BLL.Location> GetAllLocations()
        {
            return ProxyHelper.ToListOf<WS.Location, BLL.Location>(_viewAccessWs.GetAllLocations());
        }

        public List<BLL.Venue> GetAllVenues()
        {
            return ProxyHelper.ToListOf<WS.Venue, BLL.Venue>(_viewAccessWs.GetAllVenues());
        }

        public List<BLL.Performance> GetAllPerformances()
        {
            return ProxyHelper.ToListOf<WS.Performance, BLL.Performance>(_viewAccessWs.GetAllPerformances());
        }
    }
}
