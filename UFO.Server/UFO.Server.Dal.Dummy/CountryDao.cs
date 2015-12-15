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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Dal.Dummy
{
    class CountryDao : ICountryDao
    {
        public DaoResponse<Country> GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Country> Insert(Country entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Country> Update(Country entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<Country> Delete(Country entity)
        {
            throw new NotImplementedException();
        }

        public DaoResponse<long> Count()
        {
            throw new NotImplementedException();
        }

        [DaoExceptionHandler(typeof(List<Country>))]
        public DaoResponse<List<Country>> SelectAll()
        {
            throw new NotSupportedException("Test exception for DaoExceptionHandlerAtrribute test!");
        }

        public DaoResponse<List<Country>> Select(PagingData page)
        {
            throw new NotImplementedException();
        }
    }
}
