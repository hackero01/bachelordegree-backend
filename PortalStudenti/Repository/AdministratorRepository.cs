using PortalStudenti.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static PortalStudenti.Models.ModelUtilizatori;
using static PortalStudenti.Models.TeacherModel;

namespace PortalStudenti.Repository
{
    public class AdministratorRepository
    {
        private DBConnection db = new DBConnection();
        private SqlCommand cmd;
        private SqlDataReader reader;
        public int countAccounts()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.countAccount, conn);
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
        public int countTeachers()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.countTeachers, conn);
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
        public int countCourse()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.countCourse, conn);
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
      
        public string creeazaUser(ModelUtilizatori newAcc)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string mesaj = " ";

            try
            {
                cmd = new SqlCommand("insertAnewAccAndANewStudent", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add(new SqlParameter("idSpecializare", specializare.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("@nume", newAcc.nume));
                cmd.Parameters.Add(new SqlParameter("@prenume", newAcc.prenume));
                cmd.Parameters.Add(new SqlParameter("@email", newAcc.email));
                cmd.Parameters.Add(new SqlParameter("@parola", newAcc.parola));
                cmd.Parameters.Add(new SqlParameter("@adresa", newAcc.adresa));
                cmd.Parameters.Add(new SqlParameter("@idRol", newAcc.idRol));
                cmd.Parameters.Add(new SqlParameter("@conectat", newAcc.conectat));
                cmd.Parameters.Add(new SqlParameter("@nrTelefon", newAcc.numarTelefon));
                cmd.Parameters.Add(new SqlParameter("@idSpecializare", newAcc.idSpecializare));


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
        public List<ModelUtilizatori> incarcaConturi()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelUtilizatori> listaConturi = new List<ModelUtilizatori>();
            ModelUtilizatori cont = null;
            try
            {
                cmd = new SqlCommand(Query.incarcaConturi, conn);
                // cmd.Parameters.Add(new SqlParameter("username", username));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        string email = reader["email"].ToString();
                        string parola = reader["parola"].ToString();
                        string adresa = reader["adresa"].ToString();
                        string numarTelefon = reader["nr_telefon"].ToString();
                        bool conectat = bool.Parse(reader["conectat"].ToString());
                        string statut = reader["statut"].ToString();
                        int idRol = Int32.Parse(reader["id_rol"].ToString());

                        cont = new ModelUtilizatori(idUtilizator, nume, prenume, email, parola, adresa, numarTelefon, conectat, statut, idRol);
                        listaConturi.Add(cont);


                    }

                }
                else
                {

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
            return listaConturi;


        }
      
        public ModelUtilizatori detaliiCont(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelUtilizatori> listaConturi = new List<ModelUtilizatori>();
            ModelUtilizatori cont = null;
            try
            {
                cmd = new SqlCommand(Query.detaliiCont, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        string email = reader["email"].ToString();
                        string parola = reader["parola"].ToString();
                        string adresa = reader["adresa"].ToString();
                        string numarTelefon = reader["nr_telefon"].ToString();
                        bool conectat = bool.Parse(reader["conectat"].ToString());
                        string statut = reader["statut"].ToString();
                        int idRol = Int32.Parse(reader["id_rol"].ToString());
                        cont = new ModelUtilizatori(idUtilizator, nume, prenume, email, parola, adresa, numarTelefon, conectat, statut, idRol);

                        listaConturi.Add(cont);


                    }

                }
                else
                {

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
            return cont;


        }
        public void stergeCont(DeleteModel cont)
        {

            SqlConnection conn = db.initializare();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand(Query.stergeExamen, conn);
                cmd.Parameters.Add(new SqlParameter("id_utilizator", cont.idUtilizator));

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
        public string updateAccountsAdmin(ModelUtilizatori user)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string testing1 = " ";

            try
            {
                cmd = new SqlCommand(Query.adminUpdateAccount, conn);
                cmd.Parameters.Add(new SqlParameter("id_utilizator", user.idUtilizator));
                cmd.Parameters.Add(new SqlParameter("nume", user.nume));
                cmd.Parameters.Add(new SqlParameter("prenume", user.prenume));
                cmd.Parameters.Add(new SqlParameter("email", user.email));
                cmd.Parameters.Add(new SqlParameter("parola", user.parola));
                cmd.Parameters.Add(new SqlParameter("adresa", user.adresa));
                cmd.Parameters.Add(new SqlParameter("numarTelefon", user.numarTelefon));
                cmd.Parameters.Add(new SqlParameter("conectat", user.conectat));






                if (cmd.ExecuteNonQuery() == 1)
                {
                    testing1 = "Profile updated successfully";
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

  
        public string creeazaSpecializare(ModelSpecializari specializare)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string mesaj = " ";

            try
            {
                cmd = new SqlCommand(Query.creeazaSpecializare, conn);
                //cmd.Parameters.Add(new SqlParameter("idSpecializare", specializare.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("numeSpecializare", specializare.numeSpecializare));
                cmd.Parameters.Add(new SqlParameter("locuriDisponibile", specializare.locuriDisponibile));
                cmd.Parameters.Add(new SqlParameter("locuriOcupate", specializare.locuriOcupate));
                cmd.Parameters.Add(new SqlParameter("aniStudiu", specializare.aniStudiu));


                if (cmd.ExecuteNonQuery() == 1)
                {
                    mesaj = "Specializare creata cu succes";
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
      
    
        public List<ModelSpecializari> incarcaSpecializari()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelSpecializari> listaSpecializari = new List<ModelSpecializari>();
            ModelSpecializari specializare = null;
            try
            {
                cmd = new SqlCommand(Query.incarcaSpecializari, conn);
                // cmd.Parameters.Add(new SqlParameter("username", username));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());

                        string numeSpecializare = reader["nume_specializare"].ToString();
                        int locuriOcupate = Int32.Parse(reader["locuri_ocupate"].ToString());
                        int locuriDisponibile = Int32.Parse(reader["locuri_disponibile"].ToString());
                        int aniStudiu = Int32.Parse(reader["ani_studiu"].ToString());

                        specializare = new ModelSpecializari(idSpecializare, numeSpecializare, locuriDisponibile, locuriOcupate, aniStudiu);
                        listaSpecializari.Add(specializare);


                    }

                }
                else
                {

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
            return listaSpecializari;


        }
        public void stergeSpecializare(ModelSpecializari spc)
        {

            SqlConnection conn = db.initializare();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand(Query.stergeSpecializari, conn);
                cmd.Parameters.Add(new SqlParameter("id_specializare", spc.idSpecializare));

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
        public ModelSpecializari detaliiSpecializare(int idSpecializare)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelSpecializari> listaSpecializari = new List<ModelSpecializari>();
            ModelSpecializari specializare = null;
            try
            {
                cmd = new SqlCommand(Query.detaliiSpecializare, conn);
                cmd.Parameters.Add(new SqlParameter("id_specializare", idSpecializare));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        int locuriDisponibile = Int32.Parse(reader["locuri_disponibile"].ToString());
                        int locuriOcupate = Int32.Parse(reader["locuri_ocupate"].ToString());
                        int aniStudiu = Int32.Parse(reader["ani_studiu"].ToString());




                        specializare = new ModelSpecializari(idSpecializare, numeSpecializare, locuriDisponibile, locuriOcupate, aniStudiu);
                        listaSpecializari.Add(specializare);


                    }

                }
                else
                {

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
            return specializare;


        }
        public string modificaSpecialziare(ModelSpecializari specializare)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string mesaj = " ";

            try
            {
                cmd = new SqlCommand(Query.modificaSpecializari, conn);
                cmd.Parameters.Add(new SqlParameter("idSpecializare", specializare.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("nume_specializare", specializare.numeSpecializare));
                cmd.Parameters.Add(new SqlParameter("locuri_disponibile", specializare.locuriDisponibile));
                cmd.Parameters.Add(new SqlParameter("locuri_ocupate", specializare.locuriOcupate));
                cmd.Parameters.Add(new SqlParameter("ani_studiu", specializare.aniStudiu));





                if (cmd.ExecuteNonQuery() == 1)
                {
                    mesaj = "Specializare modificata cu success";
                }
                else
                {
                    mesaj = "Nu se poate modifica specializarea";
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
   
        public List<ModelStudenti> getProfileMembers(int idSpecializare)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelStudenti> listaMembrii = new List<ModelStudenti>();
            ModelStudenti membrii = null;
            try
            {
                cmd = new SqlCommand(Query.incarcaMembriiSpecializari, conn);
                cmd.Parameters.Add(new SqlParameter("idSpecializare", idSpecializare));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int id = Int32.Parse(reader["id"].ToString());
                        idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        int nrCredite = Int32.Parse(reader["nr_credite"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        membrii = new ModelStudenti(id, idUtilizator, idSpecializare, nrCredite, anStudiu, nume, prenume, numeSpecializare);
                        listaMembrii.Add(membrii);


                    }

                }
                else
                {

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
            return listaMembrii;


        }
        public List<TeacherModel> loadAllTeachers()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<TeacherModel> teacherList = new List<TeacherModel>();
            TeacherModel teacher = null;
            try
            {
                cmd = new SqlCommand(Query.loadAllTeacher, conn);
                // cmd.Parameters.Add(new SqlParameter("username", username));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int id = Int32.Parse(reader["id"].ToString());
                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        string numeMaterie = reader["nume_materie"].ToString();
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        teacher = new TeacherModel(id, idUtilizator, idSpecializare, idMaterie, nume, prenume, numeMaterie, numeSpecializare);

                        teacherList.Add(teacher);


                    }

                }
                else
                {

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
            return teacherList;


        }
        public void deleteTeacher(TeacherModel tch)
        {

            SqlConnection conn = db.initializare();
            SqlCommand cmd;


            try
            {
                cmd = new SqlCommand(Query.deleteTeacher, conn);
                cmd.Parameters.Add(new SqlParameter("id", tch.id));

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
        public string setTeacherCourse(SetTeacherCourse course)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string mesaj = " ";

            try
            {
                cmd = new SqlCommand(Query.setTeacherCourse, conn);
                cmd.Parameters.Add(new SqlParameter("idMaterie", course.idMaterie));
                cmd.Parameters.Add(new SqlParameter("id", course.id));
                // cmd.Parameters.Add(new SqlParameter("idMaterie", teacher.idMaterie));






                if (cmd.ExecuteNonQuery() == 1)
                {
                    mesaj = "Materie atribuita cu succes";
                }
                else
                {
                    mesaj = "Nu se poate atribuii materia acestui profesor";
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
        public List<CourseModel> getAllCourses()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<CourseModel> courseList = new List<CourseModel>();
            CourseModel materie = null;
            try
            {
                cmd = new SqlCommand(Query.getAllCourses, conn);

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        string numeMaterie = reader["nume_materie"].ToString();
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int credite = Int32.Parse(reader["credite"].ToString());
                        int semestru = Int32.Parse(reader["semestru"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        int idUtilizator = 0;
                        materie = new CourseModel(idMaterie, numeMaterie, idSpecializare, credite, semestru, anStudiu, idUtilizator);
                        courseList.Add(materie);

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
            return courseList;

        }
        public TeacherModel teacherDetails(int id)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<TeacherModel> listaDetalii = new List<TeacherModel>();
            TeacherModel teacher = null;
            try
            {
                cmd = new SqlCommand(Query.loadTeacherDetails, conn);
                cmd.Parameters.Add(new SqlParameter("id", id));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        id = Int32.Parse(reader["id"].ToString());
                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        string numeMaterie = reader["nume_materie"].ToString();
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        teacher = new TeacherModel(id, idUtilizator, idSpecializare, idMaterie, nume, prenume, numeMaterie, numeSpecializare);

                        listaDetalii.Add(teacher);


                    }

                }
                else
                {

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
            return teacher;


        }
        public List<CourseModel> getAllCourseByIdOfType(int idSpecializare)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<CourseModel> listaConturi = new List<CourseModel>();
            CourseModel cont = null;
            try
            {
                cmd = new SqlCommand(Query.selectAllCourseById, conn);
                cmd.Parameters.Add(new SqlParameter("idSpecializare", idSpecializare));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        
                        idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                      
                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());

                        cont = new CourseModel(idMaterie, idSpecializare, idUtilizator);
                        listaConturi.Add(cont);


                    }

                }
                else
                {

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
            return listaConturi;

        }

    }
}