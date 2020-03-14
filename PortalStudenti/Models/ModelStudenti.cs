using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class ModelStudenti
    {

        public int id;
        public int idUtilizator;
        public int idSpecializare;
        public int nrCredite;
        public int anStudiu;
        public string nume;
        public string prenume;
        public string numeSpecializare;

        public ModelStudenti(int id,int idUtilizator,int idSpecializare,int nrCredite,int anStudiu,string nume,string prenume,string numeSpecializare)
        {
            this.id = id;
            this.idUtilizator = idUtilizator;
            this.idSpecializare = idSpecializare;
            this.nrCredite = nrCredite;
            this.anStudiu = anStudiu;
            this.nume = nume;
            this.prenume = prenume;
            this.numeSpecializare = numeSpecializare;
        }
    }
}