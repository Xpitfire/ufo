using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UFO.Server.Bll.Common;
using UFO.Server.Common;
using UFO.Server.Dal.Common;
using UFO.Server.Domain;

namespace UFO.Server.Web.REST.Controllers
{
    public class CategoriesController : ApiController
    {
        // GET: Category
        public List<Category> Get()
        {
            return new List<Category> { new Category(), new Category(), new Category() };
        }
    }
}