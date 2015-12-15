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

using UFO.Commander.Proxy;
using BLL = UFO.Server.Domain;

namespace UFO.Commander.ViewModel.Entities
{
    public static class ViewModelExtensions
    {
        public static UserViewModel ToViewModelObject(this BLL.User user)
        {
            return ProxyHelper.ToObjectOf<BLL.User, UserViewModel>(user);
        }

        public static ArtistViewModel ToViewModelObject(this BLL.Artist artist)
        {
            return ProxyHelper.ToObjectOf<BLL.Artist, ArtistViewModel>(artist);
        }

        public static BlobDataViewModel ToViewModelObject(this BLL.BlobData blobData)
        {
            return ProxyHelper.ToObjectOf<BLL.BlobData, BlobDataViewModel>(blobData);
        }

        public static VenueViewModel ToViewModelObject(this BLL.Venue venue)
        {
            return ProxyHelper.ToObjectOf<BLL.Venue, VenueViewModel>(venue);
        }

        public static PerformanceViewModel ToViewModelObject(this BLL.Performance performance)
        {
            return ProxyHelper.ToObjectOf<BLL.Performance, PerformanceViewModel>(performance);
        }

        public static CountryViewModel ToViewModelObject(this BLL.Country country)
        {
            return ProxyHelper.ToObjectOf<BLL.Country, CountryViewModel>(country);
        }

        public static CategoryViewModel ToViewModelObject(this BLL.Category category)
        {
            return ProxyHelper.ToObjectOf<BLL.Category, CategoryViewModel>(category);
        }

        public static LocationViewModel ToViewModelObject(this BLL.Location location)
        {
            return ProxyHelper.ToObjectOf<BLL.Location, LocationViewModel>(location);
        }
    }
}
