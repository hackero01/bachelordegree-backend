using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class GradeModel
    {
        public int idNota;
        public int nota;
        public bool restanta;
        public int idUtilizator;
        public int idMaterie;
        public int semestru;
        public int anStudiu;

        public int contor;
        public string nume;
        public string prenume;
        public string numeMaterie;

        public GradeModel(int idNota,int nota,bool restanta,int idUtilizator,int idMaterie,int semestru,int anStudiu)
        {
            this.idNota = idNota;
            this.nota = nota;
            this.restanta = restanta;
            this.idUtilizator = idUtilizator;
            this.idMaterie = idMaterie;
            this.semestru = semestru;
            this.anStudiu = anStudiu;
        }
        public GradeModel(int idUtilizator,int idMaterie,int nota)
        {
            this.idMaterie = idMaterie;
            this.idUtilizator = idUtilizator;
            this.nota = nota;
        }
        public GradeModel(string nume, string prenume, string numeMaterie, int nota, int semestru, int anStudiu, int contor)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.numeMaterie = numeMaterie;
            this.nota = nota;
            this.semestru = semestru;
            this.anStudiu = anStudiu;
            this.contor = contor;
        }

        public GradeModel(string nume, string prenume, string numeMaterie, int nota, int semestru, int anStudiu)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.numeMaterie = numeMaterie;
            this.nota = nota;
            this.semestru = semestru;
            this.anStudiu = anStudiu;
           
        }

        public class insertGrade
        {
            public int idNota;
            public int nota;
            public bool restanta;
            public int idUtilizator;
            public int idMaterie;
            public int semestru;
            public int anStudiu;
        }
    }
}