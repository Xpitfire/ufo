using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UFO.Server.Domain;

namespace UFO.Server.Bll.Common
{
    [ServiceContract]
    public interface IAdminAccessBll : IAuthAccessBll, IValidationAccessBll
    {
        [OperationContract]
        void InsertArtist(Artist artist);
    }
}
