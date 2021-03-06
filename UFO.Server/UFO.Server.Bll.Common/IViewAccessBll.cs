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
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public interface IViewAccessBll
    {
        // Artist
        List<Artist> GetArtists(PagingData page);
        Artist GetArtist(int id);

        // Category
        List<Category> GetCategories(PagingData page);

        // Country
        List<Country> GetCountries(PagingData page);

        // Location
        List<Location> GetLocations(PagingData page);

        // Venue
        List<Venue> GetVenues(PagingData page);
        Venue GetVenue(string id);

        // Performance
        List<Performance> GetPerformances(PagingData page);
        List<Performance> GetPerformancesPerDate(DateTime date);
        List<Performance> GetPerformancesPerArtist(Artist artist);
        List<Performance> GetPerformancesPerVenue(Venue venue);
        List<Performance> GetLatestPerformances();
        List<DateTime> GetAllPerformanceDates();

        // Paging Requests
        PagingData RequestArtistPagingData();
        PagingData RequestCategoryPagingData();
        PagingData RequestCountryPagingData();
        PagingData RequestLocationPagingData();
        PagingData RequestPerformancePagingData();
        PagingData RequestVenuePagingData();

        // Search Requests
        List<Performance> SearchPerformancesPerKeyword(string keyword);
        List<Artist> SearchArtistsPerKeyword(string keyword);
        List<Venue> SearchVenuesPerKeyword(string keyword);

        List<string> GetPerformanceAutoCompletion(string keyword);

    }
}
