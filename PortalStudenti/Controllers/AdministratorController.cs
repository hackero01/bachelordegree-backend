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
using static PortalStudenti.Models.ModelStudenti;
using static PortalStudenti.Models.ModelUtilizatori;
using static PortalStudenti.Models.TeacherModel;

namespace PortalStudenti.Controllers
{
    public class AdministratorController : ApiController
    {
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getNumberOfAccounts")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countAccounts()
        {

            AdministratorServicies us = new AdministratorServicies();
            int count = 0;
            count = us.countAccounts(count);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getNumberOfPrograms")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countCourse()
        {

            AdministratorServicies us = new AdministratorServicies();
            int count = 0;
            count = us.countCourse(count);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/getNumbersOfTeacher")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult countTeachers()
        {

            AdministratorServicies us = new AdministratorServicies();
            int count = 0;
            count = us.countTeachers(count);

            return Ok(count);

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/creeazaUser")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult creeazaCont([FromBody] ModelUtilizatori spc)
        {
            AdministratorServicies spec = new AdministratorServicies();
            spec.creeazaUser(spc);
            return Ok();
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/modificaAnul")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult modificaAnul([FromBody] ModificaAnu spc)
        {
            AdministratorRepository spec = new AdministratorRepository();
            spec.modificaAnul(spc);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/incarcaConturi")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult incarcaConturi()
        {

            return Json(AdministratorServicies.incarcaConturi()); // index pags

        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/detaliiCont")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult detaliiCont([FromUri] int idUtilizator)
        {

            return Json(AdministratorServicies.detaliiCont(idUtilizator)); // index pags

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/stergeCont")]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult stergeCont([FromBody] DeleteModel cont)
        {
            AdministratorServicies spec = new AdministratorServicies();
            spec.stergeCont(cont);
            return Ok();
        }
       
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/updateAccountAdmin")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult updateAccountsAdmin([FromBody] ModelUtilizatori usr)
        {
            AdministratorServicies us = new AdministratorServicies();
            us.updateAccountsAdmin(usr);
            return Ok();
        }
       
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/creeazaSpecializare")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult creeazaSpecializare([FromBody] ModelSpecializari spc)
        {
            AdministratorServicies spec = new AdministratorServicies();
            spec.creeazaSpecializare(spc);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/incarcaSpecializare")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult incarcaSpecializare()
        {

            return Json(AdministratorServicies.incarcaSpecializare()); // index pags

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/stergeSpecializare")]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult stergeSpecializare([FromBody] ModelSpecializari spc)
        {
            AdministratorServicies spec = new AdministratorServicies();
            spec.stergeSpecializare(spc);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/detaliiSpecializare")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult detaliiSpecializare([FromUri] int idSpecializare)
        {

            return Json(AdministratorServicies.detaliiSpecializari(idSpecializare)); // index pags

        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/editeazaSpecializare")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult modificaSpecializare([FromBody] ModelSpecializari specializare)
        {
            AdministratorServicies us = new AdministratorServicies();
            us.modificaSpecializare(specializare);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/loadAllTeachers")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult loadAllTeachers()
        {

            return Json(AdministratorServicies.loadAllTeachers()); // index pags

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/deleteTeacher")]

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult deleteTeacher([FromBody] TeacherModel teacher)
        {
            AdministratorServicies ts = new AdministratorServicies();
            ts.deleteTeacher(teacher);
            return Ok();
        }
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/setTeacherCourse")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult setTeacherCourse([FromBody] SetTeacherCourse user)
        {
            AdministratorServicies ts = new AdministratorServicies();
            ts.setTeacherCourse(user);
            return Ok();
        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getAllCourses")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getAllCourses()
        {

            return Json(AdministratorServicies.getAllCourses());

        }
        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/teacherDetails")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult teacherDetails([FromUri] int id)
        {

            return Json(AdministratorServicies.teacherDetails(id)); // index pags

        }
        [System.Web.Http.HttpPost]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getProfilesMembers")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getProfilesMembers([FromUri] int idSpecializare)
        {

            return Json(AdministratorServicies.getProfileMembers(idSpecializare)); // index pags

        }

        [System.Web.Http.HttpGet]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true)]
        [System.Web.Http.Route("api/getAllCourseByIdOfType")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]


        public IHttpActionResult getAllCourseByIdOfType([FromUri] int idSpecializare)
        {

            return Json(AdministratorServicies.getAllCourseByIdOfType(idSpecializare)); // index pags

        }
    }

}
