using PortalStudenti.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
                        string numeMaterie = "george";
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


    }
}