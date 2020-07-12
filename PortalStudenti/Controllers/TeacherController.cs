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
using static PortalStudenti.Models.ExamModel;
using static PortalStudenti.Models.GradeModel;

namespace PortalStudenti.Controllers
{
    public class TeacherController : ApiController
    {

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/adunaNumerele")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countStudents([FromUri] int idMaterie)
        {

            TeacherServicies us = new TeacherServicies();
            int count = 0;
            count = us.countStudents(idMaterie);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/countPassedStudent")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countPassedStudent([FromUri] int idMaterie)
        {

            TeacherServicies us = new TeacherServicies();
            int count = 0;
            count = us.countPassedStudents(idMaterie);

            return Ok(count);

        }
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
        [System.Web.Http.HttpPost]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/checkCeva")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult checkCeva([FromUri] int idUtilizator)
        {

            return Json(TeacherServicies.countFailedStudentsToChart(idUtilizator)); // index pags

        }
        [System.Web.Http.HttpPost]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/passOrFailStudent")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countPassOrFailStudent([FromUri] int idMaterie)
        {

            return Json(TeacherServicies.countPassOrFailStudent(idMaterie)); // index pags

        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/loadAllStudentsEnroledAtCourseByIdOfCourseAndIdOfType")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult loadAllStudentsEnroledAtCourseByIdOfCourseAndIdOfType([FromUri] int idSpecializare, int idMaterie)
        {
            // TeacherServicies spc = new TeacherServicies();
            return Ok(TeacherServicies.loadAllStudentsEnroledAtCourseByIdOfCourseAndIdOfType(idSpecializare, idMaterie));



        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getNumberOfStudents")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countAccounts([FromUri]  int idSpecializare)
        {

            TeacherServicies us = new TeacherServicies();
            int count = 0;
            count = us.countStudents(idSpecializare);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/calculeazaVenit")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult calculeazaVenit([FromUri]  int idUtilizator)
        {

            TeacherServicies us = new TeacherServicies();
            int count = 0;
            count = us.calculeazaVenit(idUtilizator);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getNumberOfExamsByIdOfTeacher")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countTeacherExams([FromUri]  int idUtilizator)
        {

            TeacherServicies us = new TeacherServicies();
            int count = 0;
            count = us.countTeacherExams(idUtilizator);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/insertAGrade")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult createAgrade([FromBody] insertGrade grade)
        {
            TeacherServicies spec = new TeacherServicies();
            spec.createAGrade(grade);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getAllCourseWhatHeTeach")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getAllCourseWhatHeTeach([FromUri] int idUtilizator)
        {

            return Json(TeacherServicies.getAllCourseWhereTeacherTeach(idUtilizator));

        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getProgramID")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getProgramID([FromUri] int idMaterie)
        {

            return Json(TeacherServicies.getProgramID(idMaterie));

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/stergeExam")]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult stergeCont([FromBody] DeleteModel examen)
        {
            TeacherServicies spec = new TeacherServicies();
            spec.stergeExamen(examen);
            return Ok();
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/updateContorCazuti")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult updateContorCazuti([FromBody] FailedStudentsModel usr)
        {
            TeacherServicies us = new TeacherServicies();
            us.updateContorCazuti(usr);
            return Ok();
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/updateContorTrecuti")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult updateContorTrecuti([FromBody] FailedStudentsModel usr)
        {
            TeacherServicies us = new TeacherServicies();
            us.updateContorTrecuti(usr);
            return Ok();
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/createExam")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult createExam([FromBody] insertModel exam)
        {
            TeacherServicies spec = new TeacherServicies();
            spec.createExam(exam);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getExamList")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getExamListByIdOfTeacher([FromUri] int idUtilizator)
        {

            return Json(TeacherServicies.getExamListByIdOfTeacher(idUtilizator));

        }

    }
}
