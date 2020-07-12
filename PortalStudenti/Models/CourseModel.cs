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

        // pt verificare ce materie preda
        public string numeSpecializare;
       
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
        public CourseModel(int idMaterie, string numeMaterie, int idSpecializare, int numarCredite, int semestru, int anStudiu, int idUtilizator,string numeSpecializare)
        {
            this.idMaterie = idMaterie;
            this.numeMaterie = numeMaterie;
            this.idSpecializare = idSpecializare;
            this.numarCredite = numarCredite;
            this.semestru = semestru;
            this.anStudiu = anStudiu;
            this.idUtilizator = idUtilizator;
            this.numeSpecializare = numeSpecializare;
        }
        public CourseModel(int idMaterie,int idSpecializare,int idUtilizator)
        {
            this.idUtilizator = idUtilizator;
            this.idMaterie = idMaterie;
            this.idSpecializare = idSpecializare;
        }
        public CourseModel(int idMaterie, int idSpecializare, string numeMaterie)
        {
            this.numeMaterie = numeMaterie;
            this.idMaterie = idMaterie;
            this.idSpecializare = idSpecializare;
        }
        public CourseModel(int idMaterie, int idSpecializare, string numeMaterie,string numeSpecializare)
        {
            this.numeMaterie = numeMaterie;
            this.idMaterie = idMaterie;
            this.idSpecializare = idSpecializare;
            this.numeSpecializare = numeSpecializare;
        }
    }
}