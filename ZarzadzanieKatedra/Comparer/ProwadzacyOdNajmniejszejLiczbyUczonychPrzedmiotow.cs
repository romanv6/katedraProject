using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZarzadzanieKatedra
{
    #region Nie ruszać!!!

    public class ProwadzacyOdNajmniejszejLiczbyUczonychPrzedmiotow : IComparer<Prowadzacy>
    {
        public int Compare(Prowadzacy a, Prowadzacy b)
        {
            if (a.LiczbaPrzedmiotowKtorychMozeUczyc < b.LiczbaPrzedmiotowKtorychMozeUczyc)
                return -1;
            if (a.LiczbaPrzedmiotowKtorychMozeUczyc > b.LiczbaPrzedmiotowKtorychMozeUczyc)
                return 1;

            return 0;
        }
    }

    #endregion
}
