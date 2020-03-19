using PortalStudenti.Models;
using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PortalStudenti.Models.ModelUtilizatori;
using static PortalStudenti.Models.TeacherModel;

namespace PortalStudenti.Servicies
{
    public class AdministratorServicies
    {
        public int countAccounts(int count)
        {
            AdministratorRepository us = new AdministratorRepository();
            count = us.countAccounts();
            return count;

        }
        public int countCourse(int count)
        {
            AdministratorRepository us = new AdministratorRepository();
            count = us.countCourse();
            return count;

        }
        public string creeazaUser(ModelUtilizatori newAcc)
        {
            AdministratorRepository spec = new AdministratorRepository();
            string mesaj = spec.creeazaUser(newAcc);
            return mesaj;
        }
        public static List<ModelUtilizatori> incarcaConturi()
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                List<ModelUtilizatori> listaConturi = null;
                try
                {


                    listaConturi = up.incarcaConturi();
                }
                catch (Exception ex)
                {
                    //mesajele de eroare se logheaz in baza de date intr-o tabela de log-uri
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaConturi;
            }
        }
        public static ModelUtilizatori detaliiCont(int idUtilizator)
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                ModelUtilizatori listaConturi = null;
                try
                {


                    listaConturi = up.detaliiCont(idUtilizator);
                }
                catch (Exception ex)
                {
                    //mesajele de eroare se logheaz in baza de date intr-o tabela de log-uri
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaConturi;
            }
        }
        public void stergeCont(DeleteModel cont)
        {

            AdministratorRepository up = new AdministratorRepository();
            up.stergeCont(cont);

        }
        public string updateAccountsAdmin(ModelUtilizatori user)
        {

            AdministratorRepository up = new AdministratorRepository();
            string testing1 = up.updateAccountsAdmin(user);
            return testing1;

        }
        public string creeazaSpecializare(ModelSpecializari specializare)
        {
            AdministratorRepository spec = new AdministratorRepository();
            string mesaj = spec.creeazaSpecializare(specializare);
            return mesaj;
        }
        public static List<ModelSpecializari> incarcaSpecializare()
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                List<ModelSpecializari> listaSpecializari = null;
                try
                {


                    listaSpecializari = up.incarcaSpecializari();
                }
                catch (Exception ex)
                {
                    //mesajele de eroare se logheaz in baza de date intr-o tabela de log-uri
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaSpecializari;
            }
        }
        public void stergeSpecializare(ModelSpecializari spc)
        {

            AdministratorRepository up = new AdministratorRepository();
            up.stergeSpecializare(spc);

        }
        public static ModelSpecializari detaliiSpecializari(int idSpecializare)
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                ModelSpecializari listaSpecializare = null;
                try
                {


                    listaSpecializare = up.detaliiSpecializare(idSpecializare);
                }
                catch (Exception ex)
                {
                    //mesajele de eroare se logheaz in baza de date intr-o tabela de log-uri
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaSpecializare;
            }
        }
        public string modificaSpecializare(ModelSpecializari specializare)
        {

            AdministratorRepository up = new AdministratorRepository();
            string mesaj = up.modificaSpecialziare(specializare);
            return mesaj;

        }
        public static List<TeacherModel> loadAllTeachers()
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                List<TeacherModel> teacherList = null;
                try
                {


                    teacherList = up.loadAllTeachers();
                }
                catch (Exception ex)
                {

                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return teacherList;
            }
        }
        public void deleteTeacher(TeacherModel teacher)
        {

            AdministratorRepository up = new AdministratorRepository();
            up.deleteTeacher(teacher);

        }
        public string setTeacherCourse(SetTeacherCourse teacher)
        {

            AdministratorRepository up = new AdministratorRepository();
            string mesaj = up.setTeacherCourse(teacher);
            return mesaj;

        }
        public static List<CourseModel> getAllCourses()
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                List<CourseModel> courseList = null;
                try
                {
                    courseList = up.getAllCourses();
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return courseList;
            }
        }
        public static TeacherModel teacherDetails(int idUtilizator)
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                TeacherModel teacher = null;
                try
                {


                    teacher = up.teacherDetails(idUtilizator);
                }
                catch (Exception ex)
                {
                    //mesajele de eroare se logheaz in baza de date intr-o tabela de log-uri
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return teacher;
            }
        }
        public static List<ModelStudenti> getProfileMembers()
        {
            {
                AdministratorRepository up = new AdministratorRepository();
                List<ModelStudenti> listaMembrii = null;
                try
                {


                    listaMembrii = up.getProfileMembers();
                }
                catch (Exception ex)
                {
                    //mesajele de eroare se logheaz in baza de date intr-o tabela de log-uri
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaMembrii;
            }
        }
    }
}