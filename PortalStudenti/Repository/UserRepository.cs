using PortalStudenti.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
namespace PortalStudenti.Repository
{
    public class UserRepository
    {
        private DBConnection db = new DBConnection();
        private SqlCommand cmd;
        private SqlDataReader reader;
        public ModelUtilizatori checkUserLogin(string email, string pass)
        {

            SqlConnection conn = db.initializare();
            ModelUtilizatori user = null;



            try
            {
                cmd = new SqlCommand(Query.loginCheck, conn);
                cmd.Parameters.Add(new SqlParameter("email", email));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        email = reader["email"].ToString();
                        string parola = reader["parola"].ToString();
                        string adresa = reader["adresa"].ToString();
                        string numarTelefon = reader["nr_telefon"].ToString();
                        bool conectat = bool.Parse(reader["conectat"].ToString());
                        string statut = reader["statut"].ToString();
                        int idRol = Int32.Parse(reader["id_rol"].ToString());
                        string numeMaterie = "blank";
                        string denumireRol = reader["denumire"].ToString();
                        user = new ModelUtilizatori(idUtilizator, nume, prenume, email, parola, adresa, numarTelefon, conectat, statut, idRol, numeMaterie,denumireRol);

                        if (pass == user.parola)
                        {
                            user.statusConectare = "Conectare cu succes";
                        }
                        else
                        {
                            user.statusConectare = "Parola gresita";
                        }
                    }

                }
                else
                {
                    user = new ModelUtilizatori();
                    user.statusConectare = "Utilizator inexistent";
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
            return user;
        }
        public void updateLogin(int idUtilizator, bool conectat)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(Query.loginUpdate, conn);
                cmd.Parameters.Add(new SqlParameter("id_utilizator", idUtilizator));
                cmd.Parameters.Add(new SqlParameter("conectat", conectat));
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
        public string checkIfConnected(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            //ModelUtilizatori user = null;
            string result = " ";
            bool conectat = true;
            try
            {
                cmd = new SqlCommand(Query.checkIfisLogged, conn);
                cmd.Parameters.Add(new SqlParameter("id_utilizator", idUtilizator));
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        conectat = bool.Parse(reader["conectat"].ToString());

                        if (conectat)
                        {
                            result = "con";
                        }
                        else
                        {
                            result= "decon";
                        }

                    }

                }
                else
                {
                    result = " Username not found";
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
            return result;
        }
        public string creeazaUser(ModelUtilizatori newAcc)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string mesaj = " ";

            try
            {
                cmd = new SqlCommand(Query.createAccount, conn);
                //cmd.Parameters.Add(new SqlParameter("idSpecializare", specializare.idSpecializare));
                cmd.Parameters.Add(new SqlParameter("nume", newAcc.nume));
                cmd.Parameters.Add(new SqlParameter("prenume", newAcc.prenume));
                cmd.Parameters.Add(new SqlParameter("email", newAcc.email));
                cmd.Parameters.Add(new SqlParameter("parola", newAcc.parola));
                cmd.Parameters.Add(new SqlParameter("adresa", newAcc.adresa));
                cmd.Parameters.Add(new SqlParameter("idRol", newAcc.idRol));
                cmd.Parameters.Add(new SqlParameter("conectat", newAcc.conectat));
                cmd.Parameters.Add(new SqlParameter("numarTelefon", newAcc.numarTelefon));
                cmd.Parameters.Add(new SqlParameter("idSpecializare", newAcc.idSpecializare));


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
        public string updateData(ModelUtilizatori user)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            string testing1 = " ";

            try
            {
                cmd = new SqlCommand(Query.updateAccount, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", user.idUtilizator));
                cmd.Parameters.Add(new SqlParameter("nume", user.nume));
                cmd.Parameters.Add(new SqlParameter("prenume", user.prenume));
                cmd.Parameters.Add(new SqlParameter("email", user.email));
                cmd.Parameters.Add(new SqlParameter("parola", user.parola));
                cmd.Parameters.Add(new SqlParameter("adresa", user.adresa));
                cmd.Parameters.Add(new SqlParameter("numarTelefon", user.numarTelefon));

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
        public ModelUtilizatori getAllUserInformation(int idUtilizator)
        {

            SqlConnection conn = db.initializare();
            ModelUtilizatori user = null;



            try
            {
                cmd = new SqlCommand(Query.getAllUserInformation, conn);
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
                        string numeMaterie = "george";
                        string denumireRol = reader["denumire"].ToString();
                        user = new ModelUtilizatori(idUtilizator, nume, prenume, email, parola, adresa, numarTelefon, conectat, statut, idRol, numeMaterie, denumireRol);

     
                    }

                }
                else
                {
                    user = new ModelUtilizatori();
                    user.statusConectare = "Utilizator inexistent";
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
            return user;
        }
        public List<GradeModel>getStudentGradeByIdOfUser(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<GradeModel> gradeList = new List<GradeModel>();
            GradeModel exam = null;
            try
            {
                cmd = new SqlCommand(Query.getGradeByIdOfStudent, conn);
         
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        // exam = new GradeModel(idExam, idSpecializare, idMaterie, data, timp, oraExamen, numeSpecializare, numeMaterie, anStudiu);
                        //     [nota]
                        //   ,a.[semestru]
                        //   ,a.[an_studiu]
                        //,b.nume_materie
                        //,c.nume,c.prenume
                        int nota = Int32.Parse(reader["nota"].ToString());
                        int semestru = Int32.Parse(reader["semestru"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        string numeMaterie = reader["nume_materie"].ToString();
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        exam = new GradeModel(nume, prenume, numeMaterie, nota, semestru, anStudiu);
                        gradeList.Add(exam);


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
            return gradeList;
        }
        public List<ModelStudenti> getListOfStudentClassById(int idSpecializare,int anStudiu)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelStudenti> colegi = new List<ModelStudenti>();
            ModelStudenti coleg = null;
            try
            {
                cmd = new SqlCommand(Query.getListOfStudentClassById, conn);

                cmd.Parameters.Add(new SqlParameter("idSpecializare", idSpecializare));
                cmd.Parameters.Add(new SqlParameter("anStudiu", anStudiu));
                reader = cmd.ExecuteReader();
            
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        coleg = new ModelStudenti(idUtilizator, nume, prenume);
                        colegi.Add(coleg);


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
            return colegi;
        }
        public List<GradeModel> procentajNote(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<GradeModel> gradeList = new List<GradeModel>();
            GradeModel exam = null;
            try
            {
                cmd = new SqlCommand(Query.getGradeByIdOfStudent, conn);

                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                int contor = 0;
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        // exam = new GradeModel(idExam, idSpecializare, idMaterie, data, timp, oraExamen, numeSpecializare, numeMaterie, anStudiu);
                        //     [nota]
                        //   ,a.[semestru]
                        //   ,a.[an_studiu]
                        //,b.nume_materie
                        //,c.nume,c.prenume
                        int nota = Int32.Parse(reader["nota"].ToString());
                        int semestru = Int32.Parse(reader["semestru"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        string numeMaterie = reader["nume_materie"].ToString();
                        string nume = reader["nume"].ToString();
                        string prenume = reader["prenume"].ToString();
                        if (nota >= 5)
                        {
                            contor++;
                        }
                        exam = new GradeModel(nume, prenume, numeMaterie, nota, semestru, anStudiu,contor);
                        gradeList.Add(exam);


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
            return gradeList;
        }
        public List<ExamModel> getExamListOfUserById(int idUtilizator,int idSpecializare,int anStudiu) 
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ExamModel> rolesList = new List<ExamModel>();
            ExamModel exam = null;
            try
            {
                cmd = new SqlCommand(Query.getExamListOfUserById, conn);
                cmd.Parameters.Add(new SqlParameter("idSpecializare", idSpecializare));
                cmd.Parameters.Add(new SqlParameter("anStudiu", anStudiu));
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {   
                        int idExam = Int32.Parse(reader["exam_id"].ToString());
                        idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int idMaterie = Int32.Parse(reader["id_materie"].ToString());
                        string data = reader["data"].ToString();
                        int timp = Int32.Parse(reader["timp"].ToString());
                        anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        string oraExamen = reader["ora_examen"].ToString();
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        string numeMaterie = reader["nume_materie"].ToString();
                        exam = new ExamModel(idExam, idSpecializare, idMaterie, data, timp, oraExamen, numeSpecializare, numeMaterie, anStudiu);
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
        public ModelStudenti getStudentDetails(int idUtilizator)
        {

            SqlConnection conn = db.initializare();
            ModelStudenti user = null;



            try
            {
                cmd = new SqlCommand(Query.getStudentInformation, conn);
                cmd.Parameters.Add(new SqlParameter("idUtilizator", idUtilizator));
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {
                        idUtilizator = Int32.Parse(reader["id_utilizator"].ToString());
                        int idSpecializare = Int32.Parse(reader["id_specializare"].ToString());
                        int anStudiu = Int32.Parse(reader["an_studiu"].ToString());
                        int numarCredite = Int32.Parse(reader["nr_credite"].ToString());
                        string numeSpecializare = reader["nume_specializare"].ToString();
                        user = new ModelStudenti(idUtilizator, numarCredite, anStudiu, numeSpecializare,idSpecializare);
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
            return user;
        }
        public int countPassedExamByStudentId(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.countPassedExamByStudentId, conn);
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
        public int calculeazavenitStudent(int idUtilizator)
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            int count = 0;
            try
            {
                cmd = new SqlCommand(Query.sumaDatorata, conn);
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
        public void SendEmail(string email)
        {
            string nume = string.Empty;
            string prenume = string.Empty;
            string password = string.Empty;
            string constr = ConfigurationManager.ConnectionStrings["licenta2019"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT nume, prenume,parola FROM tbl_utilizatori WHERE email = @email"))
                {
                    cmd.Parameters.AddWithValue("@email", email.Trim());
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            nume = sdr["nume"].ToString();
                            prenume = sdr["prenume"].ToString();
                            password = sdr["parola"].ToString();
                        }
                    }
                    con.Close();
                }
            }
            if (!string.IsNullOrEmpty(password))
            {
                MailMessage mm = new MailMessage("emaildetestare124@gmail.com", email.Trim());
                mm.Subject = "Password Recovery";
                mm.Body = string.Format("Hi {0} {1},<br /><br />Your password is {2}.<br /><br />Thank You.", nume,prenume, password);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = false;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "emaildetestare124@gmail.com";
                NetworkCred.Password = "121212Css";
                smtp.UseDefaultCredentials = true;

          

                smtp.Credentials = NetworkCred;
                smtp.Port = 465;
                smtp.Send(mm);
                
            }
            else
            {
              
                string eroare = " stai cuminte";
            }
        }
    }
}