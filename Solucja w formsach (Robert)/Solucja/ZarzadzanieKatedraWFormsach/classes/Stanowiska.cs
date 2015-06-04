using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ZarzadzanieKatedraWFormsach
{
    public class Stanowiska
    {
        #region Nie ruszać!!!!!
        /// <summary>
        /// slownik z rodzajami stanowisk
        /// </summary>
        static Dictionary<string, int> listaStanowisk = new Dictionary<string, int>();
        static public Dictionary<string, int> ListaStanowisk
        {
            get { return listaStanowisk; }
        }

        /// <summary>
        /// metoda dodająca stanowisko do słownika
        /// </summary>
        static private void dodajStanowisko(string nazwa, int pensum)
        {
            ListaStanowisk.Add(nazwa, pensum);
        }

        /// <summary>
        /// metoda wczytująca stanowiska z pliku
        /// </summary>
        static public void ZaladujStanowiska(StreamReader sr)
        {
            sr.ReadLine(); //pomijamy pierwszą linijkę w każdym pliku

            string line;
            
            while ((line = sr.ReadLine()) != null)
                {
                    var wiersz = line.Split(new char[] {';'});
                    dodajStanowisko(wiersz[0],Convert.ToInt32(wiersz[1]));
                }
        }

        /// <summary>
        /// zwraca liczbe godzin dla danego stanowiska
        /// </summary>
        static public int ZwrocLiczbeGodzinDlaStanowiska(string stanowisko)
        {
            int temp;
            listaStanowisk.TryGetValue(stanowisko,out temp);

            return temp;
        }
        #endregion
    }
}
