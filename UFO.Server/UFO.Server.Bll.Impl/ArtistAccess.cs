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
using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Bll.Common;
using UFO.Server.Domain;
using PostSharp.Patterns.Model;
using UFO.Server.Bll.Impl;
using UFO.Server.Dal.Common;

namespace UFO.Server.Bll.Impl
{
    [NotifyPropertyChanged]
    [Transaction(TransactionOption.Required)]
    public class ArtistAccess : IArtistAccessBll
    {
        public IList<Artist> GetAll()
        {
            return DalProviderFactories.GetDaoFactory().CreateArtistDao().SelectAll().ResultObject;
        }

        public IList<Artist> GetAndFilterByCatrgory(Category category)
        {
            return DalProviderFactories
                .GetDaoFactory()
                .CreateArtistDao()
                .SelectWhere(artists => artists.Where(
                    artist => artist.Category.Equals(category))).ResultObject;
        }
    }
}
