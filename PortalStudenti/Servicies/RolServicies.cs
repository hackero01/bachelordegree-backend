using PortalStudenti.Models;
using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Servicies
{
    public class RolServicies
    {
        public static List<ModelRoluri> getAllRoles()
        {
            {
                RolRepository up = new RolRepository();
                List<ModelRoluri> rolesList = null;
                try
                {
                    rolesList = up.getAllRoles();
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