using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class ModelSpecializari
    {
        public int idSpecializare;
        public string numeSpecializare;
        public int locuriDisponibile;
        public int locuriOcupate;
        public int aniStudiu;

        public ModelSpecializari()
        {

        }
        public ModelSpecializari(int idSpecializare, string numeSpecializare, int locuriDisponibile, int locuriOcupate, int aniStudiu)
        {
            this.idSpecializare = idSpecializare;
            this.numeSpecializare = numeSpecializare;
            this.locuriDisponibile = locuriDisponibile;
            this.locuriOcupate = locuriOcupate;
            this.aniStudiu = aniStudiu;
        }
       
    }
}