
using PortalStudenti.Models;
using PortalStudenti.Repository;
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
        public IHttpActionResult userLogOut([FromUri] int idUtilizator)
        {

            UserServicies us = new UserServicies();
            us.checkIfConnected(idUtilizator);
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
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getAllUserInformation")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getAllUserInformation([FromUri] int idUtilizator)
        {
            UserServicies us = new UserServicies();
           return Json(us.getAllUserInformation(idUtilizator));
           
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getStudentDetails")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult getStudentDetails([FromUri] int idUtilizator)
        {
            UserServicies us = new UserServicies();
            return Json(us.getStudentDetails(idUtilizator));

        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getExamListUserById")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getExamListByIdOfTeacher([FromUri] int idUtilizator,int idSpecializare,int anStudiu)
        {

            return Json(UserServicies.getExamListOfUserById(idUtilizator,idSpecializare, anStudiu));


        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getClassMates")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getClassMates([FromUri]  int idSpecializare, int anStudiu)
        {

            return Json(UserServicies.getListOfStudentClassById(idSpecializare, anStudiu));


        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getStudentGradeByIdOfUser")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getStudentGradeByIdOfUser([FromUri] int idUtilizator)
        {

            return Json(UserServicies.getStudentGradeByIdOfUser(idUtilizator));


        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/procentajNote")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult procentajNota([FromUri] int idUtilizator)
        {

            return Json(UserServicies.procentajNote(idUtilizator));


        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getNumberOfPassedExamByIdOfStudent")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countAccounts([FromUri] int idUtilizator)
        {

            UserServicies us = new UserServicies();
            int count = 0;
            count = us.countPassedExamByStudentId(idUtilizator);

            return Ok(count);


        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/calculeazaVenitPerStudent")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult calculeazaVenitPerStudent([FromUri]  int idUtilizator)
        {

            UserServicies us = new UserServicies();
            int count = 0;
            count = us.calculeazavenitStudent(idUtilizator);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/sendMail")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult sendMail([FromUri]  string email)
        {

            UserRepository us = new UserRepository();

            us.SendEmail(email);
            return Ok();

            

        }
    }
}
