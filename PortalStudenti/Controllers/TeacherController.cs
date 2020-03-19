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
    public class TeacherController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getAllEnroledStudentsAtCourseByIdofCourse")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getAllEnroledStudentsAtCourseByIdofCourse([FromUri] int idMaterie)
        {

            return Json(TeacherServicies.getAllEnroledStudentsAtCourseByIdofCourse(idMaterie)); // index pags

        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/checkWhatCourseHeTeach")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getWhatCourseTeach([FromUri] int idUtilizator)
        {

            return Json(TeacherServicies.checkWhatCourseHeTeach(idUtilizator)); // index pags

        }
    }
}
