using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LProwadzacych
{
    class Prowadzacy
    {
        
    }
    public class ListaProwadzacych : ICollection<Prowadzacy>, IList<Prowadzacy> {

        public List<Prowadzacy> ListaProwadzacych;

        public ListaProwadzacych()
        {
            ListaProwadzacych = new List<Prowadzacy>();
        }

        public List<Prowadzacy> SzukajProwadzacych(string tekst)
        {
            return ListaProwadzacych;
        }

        public List<Przedmiot> Wczytaj(string sciezka)
        {
            throw new System.Exception("Not implemented");
        }

        public void Zapisz(string sciezka)
        {
            throw new System.Exception("Not implemented");
        }

        public int Count //zwraca liczbę elementów lsty
        {
            get { return ListaProwadzacych.Count; }
        }

        public IEnumerator GetEnumerator() //do foreach'a
        {
            return ListaProwadzacych.GetEnumerator(); //
        }

        public int IndexOf(Prowadzacy item) //przesyła prowadzącego i zwraca jego index
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item== ListaProwadzacych[i] )
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, Prowadzacy item)
        {
            ListaProwadzacych.Insert(index, item);
        }

        public void RemoveAt(int index) //do usuwania elementu z przesłanego indeksu
        {
            ListaProwadzacych.RemoveAt(index);
        }

        public Prowadzacy this[int index]
        {
            get
            {
                return ListaProwadzacych[index];
            }
            set
            {
                ListaProwadzacych[index] = value;
            }
        }

        public void Add(Prowadzacy item)
        {
            ListaProwadzacych.Add(item);
        }

        public void Clear()
        {
            ListaProwadzacych.Clear();
        }

        public bool Contains(Prowadzacy item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item == ListaProwadzacych[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Prowadzacy[] array, int arrayIndex) //kopiuje do określonego indeksu, obecnie nie potrzebujemy
        {
            ListaProwadzacych.CopyTo(array, arrayIndex);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Prowadzacy item) // usuwa obiekty prowadzący
        {
           return ListaProwadzacych.Remove(item);
        }

        IEnumerator<Prowadzacy> IEnumerable<Prowadzacy>.GetEnumerator()
        {
            return ListaProwadzacych.GetEnumerator();
        }
    }
}
