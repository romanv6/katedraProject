﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZarzadzanieKatedraWFormsach
{
    public class ListaProwadzacychClass //: ICollection<Prowadzacy>, IList<Prowadzacy>
    {
        Prowadzacy prowadzacy;
        public List<Prowadzacy> ListaProwadzacych;
        public List<String> przedmiotyKtorychMozeUczyc;

        public void ZaladujProwadzacych(StreamReader sr)
        {
            ListaProwadzacych = new List<Prowadzacy>();

            int id = 1;
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                int dlugosc = 0;
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
                    }
                    temp++;
                }

                foreach (var item in przedmiotyKtorychMozeUczyc)
                {
                    Console.WriteLine(item);
                }

                prowadzacy = new Prowadzacy(id, wiersz[0], wiersz[1], Convert.ToInt32(wiersz[2]), wiersz[3], wiersz[4], przedmiotyKtorychMozeUczyc);
                ListaProwadzacych.Add(prowadzacy);
                id++;
            }
        }

        //public List<Prowadzacy> SzukajProwadzacych(string tekst)
        //{
            //return ListaProwadzacych;
        //}

        //public void Zapisz(string sciezka)
        //{
        //    throw new System.Exception("Not implemented");
        //}

        //public int Count //zwraca liczbę elementów lsty
        //{
        //    get { return ListaProwadzacych.Count; }
        //}

        //public IEnumerator GetEnumerator() //do foreach'a
        //{
        //    return ListaProwadzacych.GetEnumerator(); //
        //}

        //public int IndexOf(Prowadzacy item) //przesyła prowadzącego i zwraca jego index
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        if (item == ListaProwadzacych[i])
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //public void Insert(int index, Prowadzacy item)
        //{
        //    ListaProwadzacych.Insert(index, item);
        //}

        //public void RemoveAt(int index) //do usuwania elementu z przesłanego indeksu
        //{
        //    ListaProwadzacych.RemoveAt(index);
        //}

        //public Prowadzacy this[int index]
        //{
        //    get
        //    {
        //        return ListaProwadzacych[index];
        //    }
        //    set
        //    {
        //        ListaProwadzacych[index] = value;
        //    }
        //}

        //public void Add(Prowadzacy item)
        //{
        //    ListaProwadzacych.Add(item);
        //}

        //public void Clear()
        //{
        //    ListaProwadzacych.Clear();
        //}

        //public bool Contains(Prowadzacy item)
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        if (item == ListaProwadzacych[i])
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public void CopyTo(Prowadzacy[] array, int arrayIndex) //kopiuje do określonego indeksu, obecnie nie potrzebujemy
        //{
        //    ListaProwadzacych.CopyTo(array, arrayIndex);
        //}

        //public bool IsReadOnly
        //{
        //    get { return false; }
        //}

        //public bool Remove(Prowadzacy item) // usuwa obiekty prowadzący
        //{
        //    return ListaProwadzacych.Remove(item);
        //}

        //IEnumerator<Prowadzacy> IEnumerable<Prowadzacy>.GetEnumerator()
        //{
        //    return ListaProwadzacych.GetEnumerator();
        //}
    }
}
