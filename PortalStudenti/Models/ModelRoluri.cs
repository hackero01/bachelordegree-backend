using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class ModelRoluri
    {
        public int idRol;
        public string denumire;

        public ModelRoluri(int idRol,string denumire)
        {
            this.idRol = idRol;
            this.denumire = denumire;
        }
    }
}