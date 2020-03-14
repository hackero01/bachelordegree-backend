using PortalStudenti.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalStudenti.Repository
{
    public class RolRepository
    {
        private DBConnection db = new DBConnection();
        private SqlCommand cmd;
        private SqlDataReader reader;

        public List<ModelRoluri> getAllRoles()
        {
            SqlConnection conn = db.initializare();
            SqlCommand cmd;
            List<ModelRoluri> rolesList = new List<ModelRoluri>();
            ModelRoluri rol = null;
            try
            {
                cmd = new SqlCommand(Query.getAllRoles, conn);

                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {


                    while (reader.Read())
                    {

                        int idRol = Int32.Parse(reader["id_rol"].ToString());

                        string name = reader["denumire"].ToString();

                        rol = new ModelRoluri(idRol, name);

                        rolesList.Add(rol);


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