using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzarnieKatedra
{
    class Stanowisko
    {
        private string nazwa;
        private int liczbaGodzin;

        /// <summary>
        /// wczytuje stanowiska z pliku zewnatrznego
        /// </summary>
        public void wczytajStanowiska()
        {
        } 

        /// <summary>
        /// zapisuje stanowiska do pliku
        /// </summary>
        public void zapiszStanowiska()
        {
        } 

        public Stanowisko(string nazwa, int liczbaGodzin)
        {
            this.nazwa = nazwa;
            this.liczbaGodzin = liczbaGodzin;
            stanowiska = new List<Stanowisko>();
        }
        public Stanowisko()
        {

        }

        public void DodajStanowisko();
        public void UsunStanowisko();
        private List<Stanowisko> stanowiska;
        


        public List<Stanowisko> SzukajStanowiska(string wzorzec)
        {
            List<Stanowisko> tmp = new List<Stanowisko>();
            foreach (var item in stanowiska)
            {
                if (item.nazwa.Contains(wzorzec))
                {
                    tmp.Add(item);
                }
            }
            return tmp;
        }

        public Stanowisko SzukajStanowiska(string nazwa)
        {
            Stanowisko stan = new Stanowisko();
            foreach (var item in stanowiska)
            {
                if (item.nazwa==nazwa)
                {
                    stan = item;
                }
                else
                {
                    stan = null;
                }
            }
            return stan; 
        }
    }
}
