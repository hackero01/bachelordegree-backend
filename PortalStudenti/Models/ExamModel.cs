using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class ExamModel
    {
        public int exam_id;
        public int idSpecializare;
        public int idMaterie;
        public string data;
        public int idUtilizator;
        public int timp;
        public string oraExamen;
        public string numeSpecializare;
        public int anStudiu;
        public string numeMaterie;
        public ExamModel(int exam_id,int idSpecializare,int idMaterie,string data,int idUtilizator,int timp,string oraExamen)
        {
            this.exam_id = exam_id;
            this.idSpecializare = idSpecializare;
            this.idMaterie = idMaterie;
            this.data = data;
            this.idUtilizator = idUtilizator;
            this.timp = timp;
            this.oraExamen = oraExamen;
        }
        public ExamModel(int exam_id, int idSpecializare, int idMaterie, string data, int timp, string oraExamen,string numeSpecializare,string numeMaterie,int anStudiu)
        {
            this.exam_id = exam_id;
            this.idSpecializare = idSpecializare;
            this.idMaterie = idMaterie;
            this.data = data;
            this.idUtilizator = idUtilizator;
            this.timp = timp;
            this.oraExamen = oraExamen;
            this.numeSpecializare = numeSpecializare;
            this.numeMaterie = numeMaterie;
            this.anStudiu = anStudiu;
        }
        public class DeleteModel
        {
            public int exam_id;
        }
        public class insertModel
        {

            public int exam_id;
            public int idSpecializare;
            public int idMaterie;
            public string data;
            public int idUtilizator;
            public int timp;
            public string oraExamen;
            public int anStudiu;
        }
    }
}