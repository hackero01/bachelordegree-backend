using PortalStudenti.Models;
using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Servicies
{
    public class TeacherServicies
    {

        public static List<EvidentaParticipantiMaterii> getAllEnroledStudentsAtCourseByIdofCourse(int idMaterie)
        {
            {
                TeacherRepository up = new TeacherRepository();
                List<EvidentaParticipantiMaterii> listaStudenti = null;
                try
                {
                    listaStudenti = up.getAllEnroledStudentsAtCourseByIdofCourse(idMaterie);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaStudenti;
            }
        }
        public static List<CourseModel> checkWhatCourseHeTeach(int idUtilizator)
        {
            TeacherRepository up = new TeacherRepository();
            List<CourseModel> listaStudenti = null;
            try
            {
                listaStudenti = up.checkWhatCourseHeTeach(idUtilizator);
            }
            catch (Exception ex)
            {
                var mesajEroare = ex.Message + "-" + ex.InnerException; ;
            }
            return listaStudenti;
        }
  
    }
}