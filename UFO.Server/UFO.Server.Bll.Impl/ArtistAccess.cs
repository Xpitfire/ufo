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
