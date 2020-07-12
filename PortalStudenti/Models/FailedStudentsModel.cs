using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class FailedStudentsModel
    {
        public int id;
        public int numar;
        public int idMaterie;

        public string numeMaterie;
        public int nrTrecuti;
        public FailedStudentsModel(string numeMaterie, int numar, int idMaterie,int nrTrecuti)
        {
            this.numeMaterie = numeMaterie;
            this.numar = numar;
            this.idMaterie = idMaterie;
            this.nrTrecuti = nrTrecuti;
        }
    }
}