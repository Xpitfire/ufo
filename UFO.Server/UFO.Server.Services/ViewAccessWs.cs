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
        public PagingData RequestArtistPagingData()
        {
            return ViewAccessDelegate.RequestArtistPagingData();
        }

        [OperationContract]
        public PagingData RequestCategoryPagingData()
        {
            return ViewAccessDelegate.RequestCategoryPagingData();
        }

        [OperationContract]
        public PagingData RequestCountryPagingData()
        {
            return ViewAccessDelegate.RequestCountryPagingData();
        }

        [OperationContract]
        public PagingData RequestLocationPagingData()
        {
            return ViewAccessDelegate.RequestLocationPagingData();
        }

        [OperationContract]
        public PagingData RequestPerformancePagingData()
        {
            return ViewAccessDelegate.RequestPerformancePagingData();
        }

        [OperationContract]
        public PagingData RequestVenuePagingData()
        {
            return ViewAccessDelegate.RequestVenuePagingData();
        }

        [OperationContract]
        public List<Artist> GetArtist(PagingData page)
        {
            return ViewAccessDelegate.GetArtist(page);
        }

        [OperationContract]
        public List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return ViewAccessDelegate.GetPerformancesPerDate(date);
        }

        [OperationContract]
        public List<Category> GetCategories(PagingData page)
        {
            return ViewAccessDelegate.GetCategories(page);
        }

        [OperationContract]
        public List<Country> GetCountries(PagingData page)
        {
            return ViewAccessDelegate.GetCountries(page);
        }

        [OperationContract]
        public List<Location> GetLocations(PagingData page)
        {
            return ViewAccessDelegate.GetLocations(page);
        }

        [OperationContract]
        public List<Venue> GetVenues(PagingData page)
        {
            return ViewAccessDelegate.GetVenues(page);
        }

        [OperationContract]
        public List<Performance> GetPerformances(PagingData page)
        {
            return ViewAccessDelegate.GetPerformances(page);
        }
    }
}
