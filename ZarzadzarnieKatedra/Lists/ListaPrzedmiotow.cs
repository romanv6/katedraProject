using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPrzedmiotow
{
    class Przedmiot
    {

    }
    public class ListaPrzedmiotow : ICollection<Przedmiot>, IList<Przedmiot>
    {

        public List<Przedmiot> ListaPrzedmiotow;

        public ListaPrzedmiotow()
        {
            ListaPrzedmiotow = new List<Przedmiot>();
        }

        public List<Przedmiot> SzukajProwadzacych(string tekst)
        {
            return ListaPrzedmiotow;
        }

        public List<Przedmiot> Wczytaj(string sciezka)
        {
            throw new System.Exception("Not implemented");
        }

        public void Zapisz(string sciezka)
        {
            throw new System.Exception("Not implemented");
        }

        public int Count //zwraca liczbê elementów lsty
        {
            get { return ListaPrzedmiotow.Count; }
        }

        public IEnumerator GetEnumerator() //do foreach'a
        {
            return ListaPrzedmiotow.GetEnumerator(); //
        }

        public int IndexOf(Przedmiot item) //przesy³a przedmiot i zwraca jego index
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item == ListaPrzedmiotow[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, Przedmiot item)
        {
            ListaPrzedmiotow.Insert(index, item);
        }

        public void RemoveAt(int index) //do usuwania elementu z przes³anego indeksu
        {
            ListaPrzedmiotow.RemoveAt(index);
        }

        public Przedmiot this[int index]
        {
            get
            {
                return ListaPrzedmiotow[index];
            }
            set
            {
                ListaPrzedmiotow[index] = value;
            }
        }

        public void Add(Przedmiot item)
        {
            ListaPrzedmiotow.Add(item);
        }

        public void Clear()
        {
            ListaPrzedmiotow.Clear();
        }

        public bool Contains(Przedmiot item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item == ListaPrzedmiotow[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Przedmiot[] array, int arrayIndex) //kopiuje do okreœlonego indeksu, obecnie nie potrzebujemy
        {
            ListaPrzedmiotow.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Przedmiot item) // usuwa obiekty prowadz¹cy
        {
            return ListaPrzedmiotow.Remove(item);
        }

        IEnumerator<Przedmiot> IEnumerable<Przedmiot>.GetEnumerator()
        {
            return ListaPrzedmiotow.GetEnumerator();
        }
    }
}
