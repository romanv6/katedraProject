using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieKatedraWFormsach
{
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
}
