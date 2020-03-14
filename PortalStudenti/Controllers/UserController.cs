
using PortalStudenti.Models;
using PortalStudenti.Servicies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using static PortalStudenti.Models.ModelUtilizatori;

namespace PortalStudenti.Controllers
{
    public class UserController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/userLogin")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult userLogin(string email, string pass)
        {

            return Ok(UserServicies.userLogin(email, pass));

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/userLogOut")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult userLogOut([FromBody] LogoutModel usr)
        {

            UserServicies us = new UserServicies();
            us.checkIfConnected(usr.idUtilizator);
            return Ok();

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/updateData")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult updateData([FromBody] ModelUtilizatori usr)
        {
            UserServicies us = new UserServicies();
            us.updateData(usr);
            return Ok();
        }
    }
}
