using PortalStudenti.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalStudenti.Repository
{
    public class TeacherRepository
    {
        private DBConnection db = new DBConnection();
        private SqlCommand cmd;
        private SqlDataReader reader;

        public List<EvidentaParticipantiMaterii> getAllEnroledStudentsAtCourseByIdofCourse(int idMaterie)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<EvidentaParticipantiMaterii> studentList = new List<EvidentaParticipantiMaterii>();
            EvidentaParticipantiMaterii student = null;
            try
            {
                cmd = new SqlCommand(Query.getAllEnroledStudentsAtCourseByIdOfCourse, conn);
                cmd.Parameters.Add(new SqlParameter("idMaterie", idMaterie));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int id = Int32.Parse(reader["id"].ToString());
                        idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        string numeMaterie = reader["nume_materie"].ToString();
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        student = new EvidentaParticipantiMaterii(id, idMaterie, idSpecializare, idUtilizator, nume, prenume, numeMaterie,anStudiu,numeSpecializare);
                        studentList.Add(student);


                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                conn.Dispose();
                conn.Close();
            }
            return studentList;
        }
        public List<CourseModel> checkWhatCourseHeTeach(int idUtilizator)
        {

            SqlConnection conn = db.initializare();
            CourseModel course = null;
            List<CourseModel> studentList = new List<CourseModel>();


            try
            {
                cmd = new SqlCommand(Query.getNameOfCourse, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {


                       
                         int idMaterie=Int32.Parse(reader["id_materie"].ToString());
                        string numeMaterie = reader["nume_materie"].ToString();
                        int idSpecializare =Int32.Parse(reader["id_specializare"].ToString());
                        int numarCredite = Int32.Parse(reader["credite"].ToString());
                        int semestru = Int32.Parse(reader["semestru"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());

     
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        course = new CourseModel(idMaterie,numeMaterie,idSpecializare,numarCredite,semestru,anStudiu,idUtilizator,numeSpecializare);
                        studentList.Add(course);
                    }

                }
               

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                conn.Dispose();
                conn.Close();
            }
            return studentList;
        }
    }
}