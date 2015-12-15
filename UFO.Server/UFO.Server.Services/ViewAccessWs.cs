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
using UFO.Server.Bll.Impl;
using UFO.Server.Domain;

namespace UFO.Server.Services
{
    [ServiceContract]
    public class ViewAccessWs : ViewAccessBll
    {
        [OperationContract]
        public override PagingData RequestArtistPagingData()
        {
            return base.RequestArtistPagingData();
        }

        [OperationContract]
        public override PagingData RequestCategoryPagingData()
        {
            return base.RequestCategoryPagingData();
        }

        [OperationContract]
        public override PagingData RequestCountryPagingData()
        {
            return base.RequestCountryPagingData();
        }

        [OperationContract]
        public override PagingData RequestLocationPagingData()
        {
            return base.RequestLocationPagingData();
        }

        [OperationContract]
        public override PagingData RequestPerformancePagingData()
        {
            return base.RequestPerformancePagingData();
        }

        [OperationContract]
        public override PagingData RequestVenuePagingData()
        {
            return base.RequestVenuePagingData();
        }

        [OperationContract]
        public override List<Artist> GetArtist(PagingData page)
        {
            return base.GetArtist(page);
        }

        [OperationContract]
        public override List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return base.GetPerformancesPerDate(date);
        }

        [OperationContract]
        public override List<Category> GetCategories(PagingData page)
        {
            return base.GetCategories(page);
        }

        [OperationContract]
        public override List<Country> GetCountries(PagingData page)
        {
            return base.GetCountries(page);
        }

        [OperationContract]
        public override List<Location> GetLocations(PagingData page)
        {
            return base.GetLocations(page);
        }

        [OperationContract]
        public override List<Venue> GetVenues(PagingData page)
        {
            return base.GetVenues(page);
        }

        [OperationContract]
        public override List<Performance> GetPerformances(PagingData page)
        {
            return base.GetPerformances(page);
        }
    }
}
