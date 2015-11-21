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
//     Wurm Florian
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Common
{
    public static class IVenueDaoExtension
    {
        public static DaoResponse<Venue> GetAllAndFilterById(this IVenueDao venueDao, string id)
        {
            Filter<Venue, string> filter = (venues, criteria) => venues.Where(x => x.VenueId == criteria);
            return DaoResponse.QuerySuccessfull(venueDao.GetAllAndFilterBy(id, filter).ResultObject?.First());
        }

        public static DaoResponse<Venue> GetAllAndFilterByName(this IVenueDao venueDao, string name)
        {
            Filter<Venue, string> filter = (venues, criteria) => venues.Where(x => x.Name == criteria);
            return DaoResponse.QuerySuccessfull(venueDao.GetAllAndFilterBy(name, filter).ResultObject?.First());
        }
    }
}
