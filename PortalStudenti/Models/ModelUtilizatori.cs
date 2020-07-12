using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudenti.Models
{
    public class ModelUtilizatori
    {
        public int idUtilizator;
        public string nume;
        public string prenume;
        public string email;
        public string parola;
        public string adresa;
        public string numarTelefon;
        public bool conectat;
        public string statut;
        public string statusConectare;
        public int idRol;
        public string numeMaterie;
        public string denumireRol;
        public string anStudiu;


        // 
        public int idSpecializare;
        public int numarCredite;
   
        public ModelUtilizatori(int idUtilizator, string nume, string prenume, string email, string parola, string adresa, string numarTelefon, bool conectat, string statut, int idRol,string numeMaterie,string denumireRol)
        {
            this.idUtilizator = idUtilizator;
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.parola = parola;
            this.adresa = adresa;
            this.numarTelefon = numarTelefon;
            this.conectat = conectat;
            this.statut = statut;
            this.idRol = idRol;
            this.numeMaterie = numeMaterie;
            this.denumireRol = denumireRol;
        }
        public ModelUtilizatori(int idUtilizator, string nume, string prenume, string email, string parola, string adresa, string numarTelefon, bool conectat, string statut, int idRol)
        {
            this.idUtilizator = idUtilizator;
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.parola = parola;
            this.adresa = adresa;
            this.numarTelefon = numarTelefon;
            this.conectat = conectat;
            this.statut = statut;
            this.idRol = idRol;
            
        }
        public ModelUtilizatori(string nume, string prenume, string email, string parola, string adresa, string numarTelefon) // pt editare informatii
        {
            this.nume = nume;
            this.prenume = prenume;
            this.email = email;
            this.parola = parola;
            this.adresa = adresa;
            this.numarTelefon = numarTelefon;
        }
        public ModelUtilizatori(int idUtilizator, bool conectat)
        {
            this.idUtilizator = idUtilizator;
            this.conectat = conectat;
        }
        public ModelUtilizatori(string nume,string prenume,string anStudiu)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.anStudiu = anStudiu;
        }
        public ModelUtilizatori()
        {
        }

        public class LogoutModel
        {

            public int idUtilizator;
        }


        public class Detalii
        {
            public int idUtilizator;

        }
        public class DeleteModel
        {
            public int idUtilizator;
        }
    }
}