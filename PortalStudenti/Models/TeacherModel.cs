using PortalStudenti.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class TeacherModel
    {
        public int id;
        public int idUtilizator;
        public int idSpecializare;
        public int idMaterie;
        public string nume; // pt iloadAllTeacher
        public string prenume;// pt iloadAllTeacher
        public string numeMaterie; // pt iloadAllTeacher
        public string numeSpecializare;

        public TeacherModel(int id,int idUtilizator,int idSpecialiare,int idMaterie,string nume,string prenume,string numeMaterie,string numeSpecializare)
        {
            this.id = id;
            this.idUtilizator = idUtilizator;
            this.idSpecializare = idSpecialiare;
            this.idMaterie = idMaterie;
            this.nume = nume;
            this.prenume = prenume;
            this.numeMaterie = numeMaterie;
            this.numeSpecializare = numeSpecializare;
        }
     
        public class SetTeacherCourse
        {
            public int id;
            public int idMaterie;
        }
    }
}