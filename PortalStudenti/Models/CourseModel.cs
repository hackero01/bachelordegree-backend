using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class CourseModel
    {
     
        public int idMaterie;
        public string numeMaterie;
        public int idSpecializare;
        public int numarCredite;
        public int semestru;
        public int anStudiu;
        public int idUtilizator;

        public CourseModel(int idMaterie,string numeMaterie,int idSpecializare,int numarCredite, int semestru,int anStudiu,int idUtilizator)
        {
           this.idMaterie = idMaterie;
            this.numeMaterie = numeMaterie;
            this.idSpecializare = idSpecializare;
            this.numarCredite = numarCredite;
            this.semestru = semestru;
            this.anStudiu = anStudiu;
            this.idUtilizator = idUtilizator;
        }
    }
}