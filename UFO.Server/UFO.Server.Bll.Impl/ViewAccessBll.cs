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
using UFO.Server.Bll.Common.Helper;
using UFO.Server.Domain;
using UFO.Server.Dal.Common;

namespace UFO.Server.Bll.Impl
{
    public class ViewAccessBll : AViewAccessBll
    {
        public override List<Artist> GetArtist(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => ArtistDao.Select(page).ResultObject);
        }
        
        public override List<Category> GetCategories(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => CategoryDao.Select(page).ResultObject);
        }

        public override List<Country> GetCountries(PagingData page)
        {
            return CountryDao.Select(page).ResultObject;
        }

        public override List<Location> GetLocations(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => LocationDao.Select(page).ResultObject);
        }

        public override List<Venue> GetVenues(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => VenueDao.Select(page).ResultObject);
        }

        public override List<Performance> GetPerformances(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => PerformanceDao.Select(page).ResultObject);
        }

        public override List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return PerformanceDao.SelectByDateTime(date).ResultObject;
        }
    }
}
