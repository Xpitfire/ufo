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
using UFO.Server.Domain;
using UFO.Server.Dal.Common;

namespace UFO.Server.Bll.Impl
{
    public class ViewAccessBll : AViewAccessBll
    {
        public override List<Artist> GetAllArtist()
        {
            return ArtistDao.SelectAll().ResultObject;
        }
        
        public override List<Category> GetAllCategories()
        {
            return CategoryDao.SelectAll().ResultObject;
        }

        public override List<Country> GetAllCountries()
        {
            return CountryDao.SelectAll().ResultObject;
        }

        public override List<Location> GetAllLocations()
        {
            return LocationDao.SelectAll().ResultObject;
        }

        public override List<Venue> GetAllVenues()
        {
            return VenueDao.SelectAll().ResultObject;
        }

        public override List<Performance> GetAllPerformances()
        {
            return PerformanceDao.SelectAll().ResultObject;
        }

        public override List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return PerformanceDao.SelectByDateTime(date).ResultObject;
        }
    }
}
