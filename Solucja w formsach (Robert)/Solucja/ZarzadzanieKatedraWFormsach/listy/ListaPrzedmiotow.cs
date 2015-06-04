using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ZarzadzanieKatedraWFormsach
{
    public class ListaPrzedmiotowClass //ICollection<Przedmiot>, IList<Przedmiot>
    {
        private Przedmiot przedmiot;
        public List<Przedmiot> ListaPrzedmiotow;

        #region Nie ruszaæ!!!!

        /// <summary>
        /// metoda s³u¿y do za³adowywania przedmiotów z pliku zewnêtrznego
        /// </summary>
        public void ZaladujPrzedmioty(StreamReader sr)
        {
            string line = sr.ReadLine();
            var wiersz = line.Split(new char[] { ';' });
            int rokRozpoczecia = Convert.ToInt32(wiersz[0]); //pierwsza linijka, to rok rozpoczêcia

            line = sr.ReadLine();
            wiersz = line.Split(new char[] { ';' });
            string nazwaKierunku = wiersz[0]; //druga linijka to nazwa kierunku

            sr.ReadLine(); //trzeci¹ pomijamy

            ListaPrzedmiotow = new List<Przedmiot>();

            int id = 0;

            int rok = rokRozpoczecia;
            
            while ((line = sr.ReadLine()) != null)
                {
                    wiersz = line.Split(new char[] {';'});

                    if (Convert.ToInt32(wiersz[4]) == 1 || Convert.ToInt32(wiersz[4]) == 2)
                    {
                        rok = rokRozpoczecia;
                    }
                    else if (Convert.ToInt32(wiersz[4]) == 3 || Convert.ToInt32(wiersz[4]) == 4)
                    {
                        rok = rokRozpoczecia + 1;
                    }
                    else if (Convert.ToInt32(wiersz[4]) == 5 || Convert.ToInt32(wiersz[4]) == 6)
                    {
                        rok = rokRozpoczecia + 2;
                    }
                    else if (Convert.ToInt32(wiersz[4]) == 7 || Convert.ToInt32(wiersz[4]) == 8)
                    {
                        rok = rokRozpoczecia + 3;
                    }

                    for (int i = 1; i <= 3; i++)
                    {
                        if (Convert.ToInt32(wiersz[i]) > 0)
                        {
                            id++;

                            if (i == 1)
                            {
                                przedmiot = new Przedmiot(id, wiersz[0], nazwaKierunku, Convert.ToInt32(wiersz[i]), "wyk³ad", Convert.ToInt32(wiersz[4]), rok);
                            }
                            if (i == 2)
                            {
                                przedmiot = new Przedmiot(id, wiersz[0], nazwaKierunku, Convert.ToInt32(wiersz[i]), "æwiczenia", Convert.ToInt32(wiersz[4]), rok);
                            }
                            if (i == 3)
                            {
                                przedmiot = new Przedmiot(id, wiersz[0], nazwaKierunku, Convert.ToInt32(wiersz[i]), "laboratorium", Convert.ToInt32(wiersz[4]), rok);
                            }

                            ListaPrzedmiotow.Add(przedmiot);
                        }
                    }
                }
        }

        public void SortujOdNajmniejszejLiczbyUczacych()
        {
            PrzedmiotOdNajmniejszejLiczbyUczacych comparer = new PrzedmiotOdNajmniejszejLiczbyUczacych();
            ListaPrzedmiotow.Sort(comparer);
        }

        #endregion




        #region To trzeba poprawiæ
        //    public List<Przedmiot> SzukajProwadzacych(string tekst)
    //    {
            
    //    }

    //    public List<Prowadzacy> Wczytaj(string sciezka)
    //    {
    //        throw new System.Exception("Not implemented");
    //    }

    //    public void Zapisz(string sciezka)
    //    {
    //        throw new System.Exception("Not implemented");
    //    }

    //    public int Count //zwraca liczbê elementów lsty
    //    {
    //        get { return ListaPrzedmiotow.Count; }
    //    }

    //    public IEnumerator GetEnumerator() //do foreach'a
    //    {
    //        return ListaPrzedmiotow.GetEnumerator(); //
    //    }

    //    public int IndexOf(Przedmiot item) //przesy³a przedmiot i zwraca jego index
    //    {
    //        for (int i = 0; i < this.Count; i++)
    //        {
    //            if (item == ListaPrzedmiotow[i])
    //            {
    //                return i;
    //            }
    //        }
    //        return -1;
    //    }

    //    public void Insert(int index, Przedmiot item)
    //    {
    //        ListaPrzedmiotow.Insert(index, item);
    //    }

    //    public void RemoveAt(int index) //do usuwania elementu z przes³anego indeksu
    //    {
    //        ListaPrzedmiotow.RemoveAt(index);
    //    }

    //    public Przedmiot this[int index]
    //    {
    //        get
    //        {
    //            return ListaPrzedmiotow[index];
    //        }
    //        set
    //        {
    //            ListaPrzedmiotow[index] = value;
    //        }
    //    }

    //    public void Add(Przedmiot item)
    //    {
    //        ListaPrzedmiotow.Add(item);
    //    }

    //    public void Clear()
    //    {
    //        ListaPrzedmiotow.Clear();
    //    }

    //    public bool Contains(Przedmiot item)
    //    {
    //        for (int i = 0; i < this.Count; i++)
    //        {
    //            if (item == ListaPrzedmiotow[i])
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public void CopyTo(Przedmiot[] array, int arrayIndex) //kopiuje do okreœlonego indeksu, obecnie nie potrzebujemy
    //    {
    //        ListaPrzedmiotow.CopyTo(array, arrayIndex);
    //    }

    //    public bool IsReadOnly
    //    {
    //        get { return false; }
    //    }

    //    public bool Remove(Przedmiot item) // usuwa obiekty prowadz¹cy
    //    {
    //        return ListaPrzedmiotow.Remove(item);
    //    }

    //    IEnumerator<Przedmiot> IEnumerable<Przedmiot>.GetEnumerator()
    //    {
    //        return ListaPrzedmiotow.GetEnumerator();
        //    }
        #endregion
    }
}
