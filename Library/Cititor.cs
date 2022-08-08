using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Cititor
    {
        private string numeCititor;
        private DateTime dataImpumutarii;
        private Carte carteImprumutata;
        private bool platit;

        // constructor cu paramterii
        public Cititor(string numeCititor, DateTime dataImpumutarii, Carte carteImprumutata, bool platit)
        {
            this.numeCititor = numeCititor;
            this.dataImpumutarii = dataImpumutarii;
            this.carteImprumutata = carteImprumutata;
            this.platit = platit;  
        }

        // constructor fara parametri
        public Cititor()
        {
        }

        public string NumeCititor
        {
            get { return numeCititor; }
            set { numeCititor = value; }
        }
        public DateTime DataImprumutarii
        {
            get { return dataImpumutarii; }
            set { dataImpumutarii = value; }
        }

        public Carte CarteImprumutata
        {
            get { return carteImprumutata; }
            set { carteImprumutata = value; }
        }

        public bool Platit
        {
            get { return platit; }
            set { platit = value; }
        }

        public override string ToString()
        {
            return $"Nume = {numeCititor}, Data imprumutarii = {dataImpumutarii.ToString("dd/MM/yyyy")}, Nume carte = {CarteImprumutata.NumeCarte}";
        }
    }
}
