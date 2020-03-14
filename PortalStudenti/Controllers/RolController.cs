using PortalStudenti.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PortalStudenti.Controllers
{
    public class RolController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getAllRoles")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getAllAnnouncement()
        {

            return Json(RolServicies.getAllRoles());

        }
    }
}
