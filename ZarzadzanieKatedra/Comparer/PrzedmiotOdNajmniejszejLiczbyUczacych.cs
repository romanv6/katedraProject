using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieKatedra
{
    #region Nie ruszać!!!

    public class PrzedmiotOdNajmniejszejLiczbyUczacych : IComparer<Przedmiot>
    {
        public int Compare(Przedmiot a, Przedmiot b)
        {
            if (a.LiczbaUczacych < b.LiczbaUczacych)
                return -1;
            if (a.LiczbaUczacych > b.LiczbaUczacych)
                return 1;

            return 0;
        }
    }

    #endregion
}
