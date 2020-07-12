using PortalStudenti.Models;
using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PortalStudenti.Models.ModelUtilizatori;

namespace PortalStudenti.Servicies
{
    public class UserServicies
    {
        public static ModelUtilizatori userLogin(string email, string pass)
        {

            UserRepository up = new UserRepository();
            ModelUtilizatori user = up.checkUserLogin(email, pass);
            if (user.statusConectare == "Conectare cu succes")
            {
                up.updateLogin(user.idUtilizator, true);

            }
            return user;
        }
        public  ModelUtilizatori getAllUserInformation(int idUtilizator)
        {
            UserRepository up = new UserRepository();
            ModelUtilizatori user = null;
            user = up.getAllUserInformation(idUtilizator);
            return user;
        }
        public static List<GradeModel> getStudentGradeByIdOfUser(int idUtilizator)
        {
            {
                UserRepository up = new UserRepository();
                List<GradeModel> gradeList = null;
                try
                {
                    gradeList = up.getStudentGradeByIdOfUser(idUtilizator);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return gradeList;
            }
        }
        public static List<ModelStudenti> getListOfStudentClassById(int idSpecializare,int anStudiu)
        {
            {
                UserRepository up = new UserRepository();
                List<ModelStudenti> listaColegi = null;
                try
                {
                    listaColegi = up.getListOfStudentClassById(idSpecializare,anStudiu);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return listaColegi;
            }
        }
        public static List<GradeModel> procentajNote(int idUtilizator)
        {
            {
                UserRepository up = new UserRepository();
                List<GradeModel> gradeList = null;
                try
                {
                    gradeList = up.procentajNote(idUtilizator);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return gradeList;
            }
        }
        public static List<ExamModel> getExamListOfUserById(int idUtilizator,int idSpecializare,int anStudiu)
        {
            {
                UserRepository up = new UserRepository();
                List<ExamModel> rolesList = null;
                try
                {
                    rolesList = up.getExamListOfUserById(idUtilizator,idSpecializare,anStudiu);
                }
                catch (Exception ex)
                {
                    var mesajEroare = ex.Message + "-" + ex.InnerException; ;
                }
                return rolesList;
            }
        }
        public ModelStudenti getStudentDetails(int idUtilizator)
        {
            UserRepository up = new UserRepository();
            ModelStudenti user = null;
            user = up.getStudentDetails(idUtilizator);
            return user;
        }
        public void checkIfConnected(int idUtilizator)
        {
            UserRepository us = new UserRepository();
            string result = us.checkIfConnected(idUtilizator);
            if (result == "con")
            {
                us.updateLogin(idUtilizator, false);

            }

        }
        
        public string updateData(ModelUtilizatori user)
        {

            UserRepository up = new UserRepository();
            string testing1 = up.updateData(user);
            return testing1;

        }
        public int countPassedExamByStudentId(int idUtilizator)
        {
            UserRepository us = new UserRepository();
            int count = us.countPassedExamByStudentId(idUtilizator);
            return count;

        }
        public int calculeazavenitStudent(int idUtilizator)
        {
            UserRepository us = new UserRepository();
            int count = us.calculeazavenitStudent(idUtilizator);
            return count;

        }

    }
}