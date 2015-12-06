using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    public interface IArtistAccessBll
    {
        IList<Artist> GetAll();
        IList<Artist> GetAndFilterByCatrgory(Category category);
    }
}
