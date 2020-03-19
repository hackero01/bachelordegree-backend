using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class EvidentaParticipantiMaterii
    {
        public int id;
        public int idMaterie;
        public int idSpecializare;
        public int idUtilizator;
        public string nume;
        public string prenume;
        public string numeMaterie;
        public int anStudiu;
        public string numeSpecializare;
        public EvidentaParticipantiMaterii(int id,int idMaterie,int idSpecializare,int idUtilizator,string nume,string prenume,string numeMaterie,int anStudiu,string numeSpecializare)
        {
            this.id = id;
            this.idMaterie = idMaterie;
            this.idSpecializare = idSpecializare;
            this.idUtilizator = idUtilizator;
            this.nume = nume;
            this.prenume = prenume;
            this.numeMaterie = numeMaterie;
            this.anStudiu = anStudiu;
            this.numeSpecializare = numeSpecializare;
        }
    }
}