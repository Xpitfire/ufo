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

using System.Collections.Generic;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public interface IAdminAccessBll : IAuthAccessBll, IValidationAccessBll
    {
        // User
        List<User> GetUser(SessionToken token, PagingData page);
        PagingData RequestUserPagingData(SessionToken token);

        // Artist
        bool ModifyArtistRange(SessionToken token, List<Artist> artists);
        bool ModifyArtist(SessionToken token, Artist artist);
        bool RemoveArtist(SessionToken token, Artist artist);

        // Venue
        bool ModifyVenueRange(SessionToken token, List<Venue> venues);
        bool ModifyVenue(SessionToken token, Venue venue);
        bool RemoveVenue(SessionToken token, Venue venue);

        // Performance
        bool ModifyPerformanceRange(SessionToken token, List<Performance> performances);
        bool ModifyPerformance(SessionToken token, Performance performance);
        bool RemovePerformance(SessionToken token, Performance performance);

        // Location
        bool ModifyLocationRange(SessionToken token, List<Location> locations);
        bool ModifyLocation(SessionToken token, Location location);
        bool RemoveLocation(SessionToken token, Location location);

    }
}
