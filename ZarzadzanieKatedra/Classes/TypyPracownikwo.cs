using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZarzadzanieKatedra
{
    class TypyPracownikow
    {
        #region Nie ruszać!!!!!
        /// <summary>
        /// slownik z typami stanowisk
        /// </summary>
        static Dictionary<string, double> typyStanowisk = new Dictionary<string, double>();
        static public Dictionary<string, double> TypyStanowisk
        {
            get { return typyStanowisk; }
        }

        /// <summary>
        /// metoda dodająca typ stanowiska do słownika
        /// </summary>
        static private void dodajStanowisko(string nazwa, double mnoznik)
        {
            typyStanowisk.Add(nazwa, mnoznik);
        }

        /// <summary>
        /// metoda wczytująca typ stanowiska z pliku
        /// </summary>
        static public void ZaladujStanowiska(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    var wiersz = line.Split(new char[] { ';' });
                    dodajStanowisko(wiersz[0], Convert.ToDouble(wiersz[1]));
                }
            }
        }

        /// <summary>
        /// zwraca mnoznik dla danego typu stanowiska
        /// </summary>
        static public double ZwrocLiczbeGodzinDlaStanowiska(string stanowisko)
        {
            double temp;
            typyStanowisk.TryGetValue(stanowisko, out temp);

            return temp;
        }
        #endregion
    }
}
