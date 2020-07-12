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
      
        // autoInscriere//
        public int idMaterie;

        public ModelStudenti(int idUtilizator,int idSpecializare,int nrCredite,int anStudiu)
        {
            this.idUtilizator = idUtilizator;
            this.idSpecializare = idSpecializare;
            this.nrCredite = nrCredite;
            this.anStudiu = anStudiu;

        }
        public ModelStudenti(int idUtilizator, int nrCredite, int anStudiu,string numeSpecializare,int idSpecializare)
        {
            this.idUtilizator = idUtilizator;
          
            this.nrCredite = nrCredite;
            this.anStudiu = anStudiu;
            this.numeSpecializare = numeSpecializare;
            this.idSpecializare = idSpecializare;

        }
        public ModelStudenti(int idUtilizator,int idMaterie,int idSpecializare)
        {
            this.idUtilizator = idUtilizator;
            this.idMaterie = idMaterie;
            this.idSpecializare = idSpecializare;
        }
        public ModelStudenti(int idUtilizator,string nume,string prenume,int anStudiu)
        {
            this.idUtilizator = idUtilizator;
            this.nume = nume;
            this.prenume = prenume;
            this.anStudiu = anStudiu;
        }
        //

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

        public ModelStudenti(int idUtilizator, string nume, string prenume)
        {
            this.idUtilizator = idUtilizator;
            this.nume = nume;
            this.prenume = prenume;
        }
    }
}