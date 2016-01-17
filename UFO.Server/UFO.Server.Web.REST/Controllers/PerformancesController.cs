using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using UFO.Server.Bll.Common;
using UFO.Server.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Dal.MySql;
using UFO.Server.Domain;

namespace UFO.Server.Web.REST.Controllers
{
    public class PerformancesController : ApiController
    {
        

        //// GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //public void Delete(int id)
        //{
        //}

        public List<Performance> Get()
        {
            return
                FactoryProvider.GetFactory<IDaoProviderFactory>(DaoProviderSettings.Instance)
                    .CreatePerformanceDao()
                    .SelectLastestPerformances()
                    .ResultObject;
        }
    }
}
