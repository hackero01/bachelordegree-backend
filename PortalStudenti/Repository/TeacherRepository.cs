using PortalStudenti.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using static PortalStudenti.Models.ExamModel;
using static PortalStudenti.Models.GradeModel;

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

        public void stergeExamen(DeleteModel examen)
        {

            SqlConnection conn = db.initializare();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand(Query.stergeExamen, conn);
                cmd.Parameters.Add(new SqlParameter("exam_id", examen.exam_id));

                cmd.ExecuteNonQuery();


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
        public int test1(int idMaterie)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.countStudents, conn);
                cmd.Parameters.Add(new SqlParameter("idMaterie", idMaterie));
                count = (int)cmd.ExecuteScalar();
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
            return count;
        }
        public int calculeazaVenit(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.venituriGenerate, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                count = (int)cmd.ExecuteScalar();
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
            return count;
        }
        public List<FailedStudentsModel> countFailedStudentsToChart(int idUtilizator)
        {
            List<FailedStudentsModel> failedStudentsToChart = new List<FailedStudentsModel>();

            //

            SqlConnection conn = db.initializare();
            SqlCommand cmd;




            FailedStudentsModel noote = null;
            try
            {
                cmd = new SqlCommand(Query.contorel, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {



                        string numeMaterie = reader["nume_materie"].ToString();
                       
                        int id_materie = Int32.Parse(reader["id_materie"].ToString());
                        int numar = Int32.Parse(reader["numar_picati"].ToString());
                        int nrTrecuti= Int32.Parse(reader["numar_trecuti"].ToString());
                        noote = new FailedStudentsModel(numeMaterie, numar,id_materie, nrTrecuti);
                        failedStudentsToChart.Add(noote);
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                conn.Close();
            }
           

           

            return failedStudentsToChart;
        }
        public List<FailedStudentsModel> countPassOrFailStudent(int idMaterie)
        {
            List<FailedStudentsModel> failedStudentsToChart = new List<FailedStudentsModel>();

            //

            SqlConnection conn = db.initializare();
            SqlCommand cmd;




            FailedStudentsModel noote = null;
            try
            {
                cmd = new SqlCommand(Query.contorel1, conn);
                cmd.Parameters.Add(new SqlParameter("idMaterie", idMaterie));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {



                        string numeMaterie = reader["nume_materie"].ToString();

                        int id_materie = Int32.Parse(reader["id_materie"].ToString());
                        int numar = Int32.Parse(reader["numar_picati"].ToString());
                        int nrTrecuti = Int32.Parse(reader["numar_trecuti"].ToString());
                        
                        noote = new FailedStudentsModel(numeMaterie, numar, id_materie, nrTrecuti);
                        failedStudentsToChart.Add(noote);
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                conn.Close();
            }




            return failedStudentsToChart;
        }

        public int countPassedStudent(int idMaterie)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.passedStudent, conn);
                cmd.Parameters.Add(new SqlParameter("idMaterie", idMaterie));
                count = (int)cmd.ExecuteScalar();
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
            return count;
        }
        public string updateContorCazuti(FailedStudentsModel failed)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string testing1 = " ";

            try
            {
                cmd = new SqlCommand(Query.updatenr, conn);
                
                cmd.Parameters.Add(new SqlParameter("idMaterie", failed.idMaterie));
                cmd.Parameters.Add(new SqlParameter("numar_picati", failed.numar));
 

                if (cmd.ExecuteNonQuery() == 1)
                {
                    testing1 = "Contor updated successfully";
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

            return testing1;
        }
        public string updateContorTrecuti(FailedStudentsModel failed)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string testing1 = " ";

            try
            {
                cmd = new SqlCommand(Query.updatenr1, conn);

                cmd.Parameters.Add(new SqlParameter("idMaterie", failed.idMaterie));
                cmd.Parameters.Add(new SqlParameter("numar_trecuti", failed.numar));


                if (cmd.ExecuteNonQuery() == 1)
                {
                    testing1 = "Contor updated successfully";
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

            return testing1;
        }
        public int countTeacherExams(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.countTeacherExams, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                count = (int)cmd.ExecuteScalar();
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
            return count;
        }
        public List<ModelStudenti> loadAllStudentsEnroledAtCourseByIdOfCourseAndIdOfType(int idSpecializare, int idMaterie)
        {

            SqlConnection conn = db.initializare();
            ModelStudenti user = null;
            List<ModelStudenti> studentList = new List<ModelStudenti>();


            try
            {
                cmd = new SqlCommand(Query.a, conn);
                cmd.Parameters.Add(new SqlParameter("idSpecializare", idSpecializare));
                cmd.Parameters.Add(new SqlParameter("idMaterie", idMaterie));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {




                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        string nume =   reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        user = new ModelStudenti(idUtilizator,nume, prenume, anStudiu);
   
                        studentList.Add(user);
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
        public string createAGrade(insertGrade grade)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            
            string mesaj = " ";

            try
            {
                cmd = new SqlCommand("gradeManagement", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("idSpecializare", specializare.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("@nota", grade.nota));
                cmd.Parameters.Add(new SqlParameter("@id_utilizator", grade.idUtilizator));
                cmd.Parameters.Add(new SqlParameter("@id_materie", grade.idMaterie));
                cmd.Parameters.Add(new SqlParameter("@semestru", grade.semestru));
                cmd.Parameters.Add(new SqlParameter("@an_studiu", grade.anStudiu));
             
                if (cmd.ExecuteNonQuery() == 1)
                {
                    mesaj = "Cont creat cu succes";
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

            return mesaj;
        }
        public List<CourseModel> getAllCourseWhereTeacherTeach(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<CourseModel> rolesList = new List<CourseModel>();
            CourseModel course = null;
            try
            {
                cmd = new SqlCommand(Query.getAllCourseWhatHeTeach, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        string numeMaterie = reader["nume_materie"].ToString();
                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());

                        course = new CourseModel(idMaterie, idSpecializare, numeMaterie);

                        rolesList.Add(course);


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
            return rolesList;

        }
        public List<CourseModel> getProgramID(int idMaterie)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<CourseModel> rolesList = new List<CourseModel>();
            CourseModel course = null;
            try
            {
                cmd = new SqlCommand(Query.getProgramID, conn);
                cmd.Parameters.Add(new SqlParameter("idMaterie", idMaterie));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        string numeMaterie = reader["nume_materie"].ToString();
                        idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        course = new CourseModel(idMaterie, idSpecializare, numeMaterie,numeSpecializare);

                        rolesList.Add(course);


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
            return rolesList;

        }
        public string createExam(insertModel exam)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;

            string mesaj = " ";

            try
            {
                cmd = new SqlCommand(Query.insertExam, conn);
                
                //cmd.Parameters.Add(new SqlParameter("idSpecializare", specializare.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("@idSpecializare", exam.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("@idMaterie", exam.idMaterie));
                cmd.Parameters.Add(new SqlParameter("@idUtilizator", exam.idUtilizator));
                cmd.Parameters.Add(new SqlParameter("@data", exam.data)); 
                cmd.Parameters.Add(new SqlParameter("@timp", exam.timp));
                cmd.Parameters.Add(new SqlParameter("@oraExamen", exam.oraExamen));
                cmd.Parameters.Add(new SqlParameter("@anStudiu", exam.anStudiu));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    mesaj = "Examen creat cu succes";
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

            return mesaj;
        }
        public List<ExamModel> getExamListByIdOfTeacher(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ExamModel> rolesList = new List<ExamModel>();
            ExamModel exam = null;
            try
            {
                cmd = new SqlCommand(Query.getExamListByIdOfTeacher, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int idExam = Int32.Parse(reader["exam_id"].ToString());
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        string data = reader["data"].ToString();
                        int timp = Int32.Parse(reader["timp"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        string oraExamen = reader["ora_examen"].ToString();
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        string numeMaterie = reader["nume_materie"].ToString();
                        exam = new ExamModel(idExam, idSpecializare, idMaterie, data, timp, oraExamen,numeSpecializare,numeMaterie,anStudiu); 
                        rolesList.Add(exam);


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
            return rolesList;

        }
    }
}
