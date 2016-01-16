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
using System.ServiceModel;
using UFO.Server.Bll.Common;
using UFO.Server.Bll.Impl;
using UFO.Server.Common;
using UFO.Server.Domain;

namespace UFO.Server.Services
{
    [ServiceContract]
    public class ViewAccessWs
    {
        private static AViewAccessBll _viewAccessDelegate;
        private static readonly AViewAccessBll ViewAccessDelegate =
            _viewAccessDelegate ?? (_viewAccessDelegate = FactoryProvider.GetFactory<IBllProviderFactory>(BllProviderSettings.Instance).CreateAViewAccessBll());

        [OperationContract]
        public PagingData RequestArtistPagingData() => ViewAccessDelegate.RequestArtistPagingData();

        [OperationContract]
        public PagingData RequestCategoryPagingData() => ViewAccessDelegate.RequestCategoryPagingData();

        [OperationContract]
        public PagingData RequestCountryPagingData() => ViewAccessDelegate.RequestCountryPagingData();

        [OperationContract]
        public PagingData RequestLocationPagingData() => ViewAccessDelegate.RequestLocationPagingData();

        [OperationContract]
        public PagingData RequestPerformancePagingData() => ViewAccessDelegate.RequestPerformancePagingData();

        [OperationContract]
        public PagingData RequestVenuePagingData() => ViewAccessDelegate.RequestVenuePagingData();

        [OperationContract]
        public List<Artist> GetArtists(PagingData page) => ViewAccessDelegate.GetArtists(page);

        [OperationContract]
        public Artist GetArtist(int id) => ViewAccessDelegate.GetArtist(id);

        [OperationContract]
        public List<Performance> GetPerformances(PagingData page) => ViewAccessDelegate.GetPerformances(page);

        [OperationContract]
        public List<Performance> GetPerformancesPerDate(DateTime date) => ViewAccessDelegate.GetPerformancesPerDate(date);

        [OperationContract]
        public List<Performance> GetPerformancesPerArtist(Artist artist) => ViewAccessDelegate.GetPerformancesPerArtist(artist);

        [OperationContract]
        public List<Performance> GetPerformancesPerVenue(Venue venue) => ViewAccessDelegate.GetPerformancesPerVenue(venue);

        [OperationContract]
        public List<Performance> GetLatestPerformances() => ViewAccessDelegate.GetLatestPerformances();

        [OperationContract]
        public List<Category> GetCategories(PagingData page) => ViewAccessDelegate.GetCategories(page);

        [OperationContract]
        public List<Country> GetCountries(PagingData page) => ViewAccessDelegate.GetCountries(page);

        [OperationContract]
        public List<Location> GetLocations(PagingData page) => ViewAccessDelegate.GetLocations(page);

        [OperationContract]
        public List<Venue> GetVenues(PagingData page) => ViewAccessDelegate.GetVenues(page);

        [OperationContract]
        public Venue GetVenue(string id) => ViewAccessDelegate.GetVenue(id);

        [OperationContract]
        public List<Performance> SearchPerformancesPerKeyword(string keyword) => ViewAccessDelegate.SearchPerformancesPerKeyword(keyword);

        [OperationContract]
        public List<Venue> SearchVenuesPerKeyword(string keyword) => ViewAccessDelegate.SearchVenuesPerKeyword(keyword);

        [OperationContract]
        public List<Artist> SearchArtistsPerKeyword(string keyword) => ViewAccessDelegate.SearchArtistsPerKeyword(keyword);
    }
}
