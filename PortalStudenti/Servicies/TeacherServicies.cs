using PortalStudenti.Models;
using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PortalStudenti.Models.ExamModel;
using static PortalStudenti.Models.GradeModel;

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
        public void stergeExamen(DeleteModel examen)
        {

            TeacherRepository up = new TeacherRepository();
            up.stergeExamen(examen);

        }
        public static List<FailedStudentsModel> countFailedStudentsToChart(int idUtilizator)
        {
            {
                TeacherRepository up = new TeacherRepository();
                List<FailedStudentsModel> listaStudenti = null;
                try
                {
                    listaStudenti = up.countFailedStudentsToChart(idUtilizator);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaStudenti;
            }
        }
        public static List<FailedStudentsModel> countPassOrFailStudent(int idMaterie)
        {
            {
                TeacherRepository up = new TeacherRepository();
                List<FailedStudentsModel> listaStudenti = null;
                try
                {
                    listaStudenti = up.countPassOrFailStudent(idMaterie);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaStudenti;
            }
        }
        public int countStudents(int idMaterie)
        {
            TeacherRepository us = new TeacherRepository();
            int count = us.test1(idMaterie);
            return count;

        }
        public int calculeazaVenit(int idUtilizator)
        {
            TeacherRepository us = new TeacherRepository();
            int count = us.calculeazaVenit(idUtilizator);
            return count;

        }
        public int countTeacherExams(int idUtilizator)
        {
            TeacherRepository us = new TeacherRepository();
            int count = us.countTeacherExams(idUtilizator);
            return count;

        }
        public int countPassedStudents(int idMaterie)
        {
            TeacherRepository us = new TeacherRepository();
            int count = us.countPassedStudent(idMaterie);
            return count;

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
        public static List<ModelStudenti> loadAllStudentsEnroledAtCourseByIdOfCourseAndIdOfType(int idSpecializare, int idMaterie)
        {
            TeacherRepository up = new TeacherRepository();
            List<ModelStudenti> listaStudenti = null;
            try
            {
                listaStudenti = up.loadAllStudentsEnroledAtCourseByIdOfCourseAndIdOfType(idSpecializare,idMaterie);
            }
            catch (Exception ex)
            {
                var mesajEroare = ex.Message + "-" + ex.InnerException; ;
            }
            return listaStudenti;
        }
        public string createAGrade(insertGrade grade)
        {
            TeacherRepository spec = new TeacherRepository();
            string mesaj = spec.createAGrade(grade);
            return mesaj;
        }
        public string updateContorCazuti(FailedStudentsModel failed)
        {

            TeacherRepository up = new TeacherRepository();
            string testing1 = up.updateContorCazuti(failed);
            return testing1;

        }
        public string updateContorTrecuti(FailedStudentsModel failed)
        {

            TeacherRepository up = new TeacherRepository();
            string testing1 = up.updateContorTrecuti(failed);
            return testing1;

        }
        public string createExam(insertModel exam)
        {
            TeacherRepository spec = new TeacherRepository();
            string mesaj = spec.createExam(exam);
            return mesaj;
        }
        public static List<CourseModel> getAllCourseWhereTeacherTeach(int idUtilizator)
        {
            {
                TeacherRepository up = new TeacherRepository();
                List<CourseModel> rolesList = null;
                try
                {
                    rolesList = up.getAllCourseWhereTeacherTeach(idUtilizator);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return rolesList;
            }
        }
        public static List<CourseModel> getProgramID(int idMaterie)
        {
            {
                TeacherRepository up = new TeacherRepository();
                List<CourseModel> rolesList = null;
                try
                {
                    rolesList = up.getProgramID(idMaterie);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return rolesList;
            }
        }
        public static List<ExamModel> getExamListByIdOfTeacher(int idUtilizator)
        {
            {
                TeacherRepository up = new TeacherRepository();
                List<ExamModel> rolesList = null;
                try
                {
                    rolesList = up.getExamListByIdOfTeacher(idUtilizator);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return rolesList;
            }
        }
    }
}