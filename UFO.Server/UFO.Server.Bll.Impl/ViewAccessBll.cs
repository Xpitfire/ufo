﻿#region copyright
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
using System.Linq;
using System.Text.RegularExpressions;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Common.Helper;
using UFO.Server.Domain;
using UFO.Server.Dal.Common;

namespace UFO.Server.Bll.Impl
{
    public class ViewAccessBll : AViewAccessBll
    {
        public override List<Artist> GetArtists(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => ArtistDao.Select(page).ResultObject);
        }

        public override Artist GetArtist(int id)
        {
            return ArtistDao.SelectById(id).ResultObject;
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

        public override Venue GetVenue(string id)
        {
            return VenueDao.SelectById(id).ResultObject;
        }

        public override List<Performance> GetPerformances(PagingData page)
        {
            return PagingHelper.EvaluatePagingResult(page, () => PerformanceDao.Select(page).ResultObject);
        }

        public override List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return PerformanceDao.SelectByDate(date).ResultObject;
        }

        public override List<Performance> GetPerformancesPerArtist(Artist artist)
        {
            return artist != null ? PerformanceDao.SelectByArtistId(artist.ArtistId).ResultObject : null;
        }

        public override List<Performance> GetPerformancesPerVenue(Venue venue)
        {
            return venue != null ? PerformanceDao.SelectByVenueId(venue.VenueId).ResultObject : null;
        }

        public override List<Performance> GetLatestPerformances()
        {
            return PerformanceDao.SelectLastestPerformances().ResultObject;
        }

        public override List<DateTime> GetAllPerformanceDates()
        {
            return PerformanceDao.SelectAllPerformanceDates().ResultObject;
        }

        public override List<Performance> SearchPerformancesPerKeyword(string keyword)
        {
            return PerformanceDao.SelectByKeyword(keyword).ResultObject;
        }

        public override List<Artist> SearchArtistsPerKeyword(string keyword)
        {
            return ArtistDao.SelectByKeyword(keyword).ResultObject;
        }

        public override List<Venue> SearchVenuesPerKeyword(string keyword)
        {
            return VenueDao.SearchByKeyword(keyword).ResultObject;
        }

        public override List<string> GetPerformanceAutoCompletion(string keyword)
        {
            var set = new HashSet<string>();
            if (keyword != null && keyword.Length >= 2)
            {
                SearchPerformancesPerKeyword(keyword)?.ForEach(p =>
                {
                    if (Regex.IsMatch(p.Artist.Name, keyword, RegexOptions.IgnoreCase))
                        set.Add(p.Artist.Name);
                    if (Regex.IsMatch(p.Venue.Name, keyword, RegexOptions.IgnoreCase))
                        set.Add(p.Venue.Name);
                    if (Regex.IsMatch(p.Venue.Location.Name, keyword, RegexOptions.IgnoreCase))
                        set.Add(p.Venue.Location.Name);
                });
            }
            return set.ToList();
        }
    }
}
