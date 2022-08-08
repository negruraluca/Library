using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Carte
    {
        private string numeCarte;
        private string ISBN;
        private double pret;
        private int numarExemplare;

        public Carte(string numeCarte, string iSBN, double pret)
        {
            this.numeCarte = numeCarte;
            ISBN = iSBN;
            this.pret = pret;
        }

        public Carte(string numeCarte, string iSBN, double pret, int numarExemplare)
        {
            this.numeCarte = numeCarte;
            ISBN = iSBN;
            this.pret = pret;
            this.numarExemplare = numarExemplare;
        }

        public Carte()
        {
           
        }

        public Carte(string numeCarte)
        {
            this.numeCarte = numeCarte;
        }

        public string NumeCarte { 
            get { return numeCarte; } 
            set { numeCarte = value; }
        }
        public string ISBNCarte { 
            get { return ISBN; }
            set { ISBN = value; }
        }

        public double PretCarte {
            get { return pret; }
            set { pret = value;}
        }

        public int NumarExemplare
        {
            get { return numarExemplare; }
            set { numarExemplare = value; }
        }

        public override string ToString()
        {
            return $"Nume = {numeCarte}, Pret = {pret}, ISBN = {ISBN}, nume exemplare disponibile = {NumarExemplare}";
        }

    }
}
