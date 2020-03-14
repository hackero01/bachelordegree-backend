using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class ModelAnunturi
    {
        public int userId;
        public string nume;
        public string prenume;
        public string mesaj;
        public string data;
         public ModelAnunturi()
        {

        }
        public ModelAnunturi(int userId,string nume,string prenume,string mesaj,string data)
        {
            this.userId = userId;
            this.nume = nume;
            this.prenume = prenume;
            this.mesaj = mesaj;
            this.data = data;
        }
    }
}