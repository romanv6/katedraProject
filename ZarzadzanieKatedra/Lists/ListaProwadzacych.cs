using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZarzadzanieKatedra
{
    public class ListaProwadzacych : ICollection<Prowadzacy>, IList<Prowadzacy>
    {
        Prowadzacy prowadzacy;
        public List<Prowadzacy> listaProwadzacych;
        public List<String> przedmiotyKtorychMozeUczyc;


        /// <summary>
        /// metoda służy do załadowania prowadzących z pliku zewnętrznego
        /// </summary>
        public void ZaladujProwadzacych(string path)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                listaProwadzacych = new List<Prowadzacy>();

                int id = 1;
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    int dlugosc = 0; //długość linii 
                    int liczbaUczonychPrzedmiotow = 0;

                    przedmiotyKtorychMozeUczyc = new List<string>();
                    var wiersz = line.Split(new char[] { ';' });

                    foreach (var item in wiersz)
                    {
                        dlugosc++;
                    }

                    int temp = 5;
                    while (temp < dlugosc)
                    {
                        if (wiersz[temp] != "")
                        {
                            przedmiotyKtorychMozeUczyc.Add(wiersz[temp]);
                            liczbaUczonychPrzedmiotow++;
                        }
                        temp++;
                    }

                    foreach (var item in przedmiotyKtorychMozeUczyc)
                    {
                        Console.WriteLine(item);
                    }

                    prowadzacy = new Prowadzacy(id, wiersz[0], wiersz[1], wiersz[2], wiersz[3], wiersz[4], wiersz[5], przedmiotyKtorychMozeUczyc, liczbaUczonychPrzedmiotow);
                    listaProwadzacych.Add(prowadzacy);
                    id++;
                }
            }
        }

        /// <summary>
        /// metoda zapisuje listę prowadzących do pliku
        /// </summary>
        /// <param name="sw"></param>
        public void ZapiszListeProwadzacych(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (var prowadzacy in listaProwadzacych)
                {
                    string przedmioty = "";
                    foreach (var przedmiot in prowadzacy.przedmiotyKtorychMozeUczyc)
                    {
                        przedmioty += ";" + przedmiot;
                    }
                    sw.WriteLine(prowadzacy.Imie + ";" + prowadzacy.Nazwisko + ";" + prowadzacy.Pesel + ";" + prowadzacy.Tytul + ";" + prowadzacy.Stanowisko + ";" + prowadzacy.TypPracownika + przedmioty);
                }
            }
        }

        public void SortujOdNajmniejszejLiczbyUczonychPrzedmiotow()
        {
            ProwadzacyOdNajmniejszejLiczbyUczonychPrzedmiotow comparer = new ProwadzacyOdNajmniejszejLiczbyUczonychPrzedmiotow();
            listaProwadzacych.Sort(comparer);
        }
        public List<Prowadzacy> SzukajProwadzacych(string tekst)
        {
            List<Prowadzacy> listToReturn = null;

            foreach (var item in listaProwadzacych)
            {
                if (item.Imie.ToLower().Contains(tekst.ToLower()) || item.Nazwisko.ToLower().Contains(tekst.ToLower()) || item.Stanowisko.ToLower().Contains(tekst.ToLower()) || item.Tytul.ToLower().Contains(tekst.ToLower()))
                {
                    if (listToReturn == null) listToReturn = new List<Prowadzacy>();
                    listToReturn.Add(item);
                }
            }
            return listToReturn;
        }

        public int Count //zwraca liczbę elementów lsty
        {
            get { return listaProwadzacych.Count; }
        }

        public IEnumerator GetEnumerator() //do foreach'a
        {
            return listaProwadzacych.GetEnumerator();
        }

        public int IndexOf(Prowadzacy item) //przesyła prowadzącego i zwraca jego index
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item == listaProwadzacych[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, Prowadzacy item)
        {
            listaProwadzacych.Insert(index, item);
        }

        public void RemoveAt(int index) //do usuwania elementu z przesłanego indeksu
        {
            listaProwadzacych.RemoveAt(index);
        }

        public Prowadzacy this[int index]
        {
            get
            {
                return listaProwadzacych[index];
            }
            set
            {
                listaProwadzacych[index] = value;
            }
        }

        public void Add(Prowadzacy item)
        {
            listaProwadzacych.Add(item);
        }

        public void Clear()
        {
            listaProwadzacych.Clear();
        }

        public bool Contains(Prowadzacy item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item == listaProwadzacych[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Prowadzacy[] array, int arrayIndex) //kopiuje do określonego indeksu, obecnie nie potrzebujemy
        {
            listaProwadzacych.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Prowadzacy item) // usuwa obiekty prowadzący
        {
            return listaProwadzacych.Remove(item);
        }

        IEnumerator<Prowadzacy> IEnumerable<Prowadzacy>.GetEnumerator()
        {
            return listaProwadzacych.GetEnumerator();
        }
    }
}
