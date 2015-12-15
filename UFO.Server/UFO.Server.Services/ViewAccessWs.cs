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
        public override List<Artist> GetAllArtist()
        {
            return base.GetAllArtist();
        }

        [OperationContract]
        public override List<Performance> GetPerformancesPerDate(DateTime date)
        {
            return base.GetPerformancesPerDate(date);
        }

        [OperationContract]
        public override List<Category> GetAllCategories()
        {
            return base.GetAllCategories();
        }

        [OperationContract]
        public override List<Country> GetAllCountries()
        {
            return base.GetAllCountries();
        }

        [OperationContract]
        public override List<Location> GetAllLocations()
        {
            return base.GetAllLocations();
        }

        [OperationContract]
        public override List<Venue> GetAllVenues()
        {
            return base.GetAllVenues();
        }

        [OperationContract]
        public override List<Performance> GetAllPerformances()
        {
            return base.GetAllPerformances();
        }
    }
}
