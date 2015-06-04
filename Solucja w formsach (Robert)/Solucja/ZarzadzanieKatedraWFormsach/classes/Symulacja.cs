using System;
using System.Collections.Generic;

namespace ZarzadzanieKatedraWFormsach
{
    public class Symulacja
    {
        #region Nie ruszaæ!!!
        ListaPrzedmiotowClass listaPrzedmiotow;
        ListaProwadzacychClass listaProwadzacych;

        public Symulacja(ListaPrzedmiotowClass listaPrzedmiotow, ListaProwadzacychClass listaProwadzacych)
        {
            this.listaPrzedmiotow = listaPrzedmiotow;
            this.listaProwadzacych = listaProwadzacych;
        }

        /// <summary>
        /// funkcja próbuje zrealizowaæ pensum ka¿dego z pracowników
        /// </summary>
        private void RealizacjaPensumProwadzacych()
        {
            int temp;
            foreach (var prowadzacy in listaProwadzacych.ListaProwadzacych)
            {
                temp = 0;
                while (prowadzacy.pozostaloGodzin > 0 && (temp < listaPrzedmiotow.ListaPrzedmiotow.Count)) //szukamy przedmiotów dla prowadz¹cego dopóki jego pensum nie zostanie zrealizowane. Jak nasze dane nie pozaol¹ na realizacjê pensum, to pêtla biegnie w nieskoñczonoœæ
                {
                    temp++;
                    foreach (var przedmiot in listaPrzedmiotow.ListaPrzedmiotow) //jako, ¿e pensum nie zosta³o zrealizowane szukamy przedmiotu, który mo¿na prowadz¹cemu przypisaæ
                    {
                        if (prowadzacy.przedmiotyKtorychMozeUczyc.Contains(przedmiot.Nazwa)) //je¿eli prowadz¹cy mo¿e uczyæ danego przedmiotu, to przechodzimy dalej
                        {
                            if (przedmiot.PozostalaLiczbaGodzin >= przedmiot.LiczbaGodzinJednejGrupy) //je¿eli liczba godzin tego przedmiotu do rozdysponowania, jest wiêksza od liczby godzin jednej grupy
                            {
                                prowadzacy.LiczbaUczonychGodzin += przedmiot.LiczbaGodzinJednejGrupy; //prowadzacemu dajemy jedna grupe
                                przedmiot.PozostalaLiczbaGodzin -= przedmiot.LiczbaGodzinJednejGrupy; //przedmiotowi liczbe godzin do zrealizowania zmniejszamy o liczbê godzin jednej grupy
                                //przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy, przedmiot.LiczbaGodzinJednejGrupy); //prowadz¹cego dodajemy do s³ownika osób ucz¹cych danego przedmiotu, wraz z przypisan¹ wartoœci¹ ilu godzin uczy
                                przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// funkcja próbuje przypisaæ prowadz¹cych do przedmiotów, które nie zosta³y jeszcze zrealizowane
        /// </summary>
        private void RealizacjaWszystkichPrzedmiotow()
        {
            int temp;
            foreach (var przedmiot in listaPrzedmiotow.ListaPrzedmiotow)
            {
                temp = 0;
                while (przedmiot.PozostalaLiczbaGodzin > 0 && (temp < listaProwadzacych.ListaProwadzacych.Count) ) //je¿eli pozosta³y jeszcze jakieœ godziny, ¿eby zrealizowaæ dany przedmiot
                {
                    temp++;
                    foreach (var prowadzacy in listaProwadzacych.ListaProwadzacych) //to szukamy prowadz¹cego, któremu mo¿emy go daæ
                    {
                        if (prowadzacy.przedmiotyKtorychMozeUczyc.Contains(przedmiot.Nazwa)) //je¿eli prowadz¹cy mo¿e uczyæ danego przedmiotu, to przechodzimy dalej
                        {
                            if ((prowadzacy.LiczbaUczonychGodzin + przedmiot.LiczbaGodzinJednejGrupy) <= (prowadzacy.Pensum * 2.5)) //sprawdzamy, czy po jak przypiszemy ten przedmiot prowadz¹cemu, to nie przekroczymy jego górnej granicy godzin
                            {
                                prowadzacy.LiczbaUczonychGodzin += przedmiot.LiczbaGodzinJednejGrupy; //prowadzacemu dajemy jedna grupe
                                przedmiot.PozostalaLiczbaGodzin -= przedmiot.LiczbaGodzinJednejGrupy; //przedmiotowi liczbe godzin do zrealizowania zmniejszamy o liczbê godzin jednej grupy
                                //przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy, przedmiot.LiczbaGodzinJednejGrupy); //prowadz¹cego dodajemy do s³ownika osób ucz¹cych danego przedmiotu, wraz z przypisan¹ wartoœci¹ ilu godzin uczy
                                przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// wykonuje symulacjê. Jak siê uda, zwraca true, jak nie false
        /// </summary>
        public bool WykonajSymulacje()
        {
            listaProwadzacych.SortujOdNajmniejszejLiczbyUczonychPrzedmiotow();
            listaPrzedmiotow.SortujOdNajmniejszejLiczbyUczacych();

            RealizacjaPensumProwadzacych();
            RealizacjaWszystkichPrzedmiotow();

            foreach (var przedmiot in listaPrzedmiotow.ListaPrzedmiotow)
            {
                if (przedmiot.PozostalaLiczbaGodzin > 0)
                {
                    return false;
                }
            }

            foreach (var prowadzacy in listaProwadzacych.ListaProwadzacych)
            {
                if (prowadzacy.pozostaloGodzin > 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// zwraca listê prowadz¹cych po wykonaniu symulacji
        /// </summary>
        public ListaProwadzacychClass ZwrocListeProwadzacychPoSymulacji()
        {
            return listaProwadzacych;
        }

        /// <summary>
        /// zwraca listê przedmiotów po wykonaniu symulacji
        /// </summary>
        public ListaPrzedmiotowClass ZwrocListePrzedmiotowPoSymulacji()
        {
            return listaPrzedmiotow;
        }

        #endregion
    }
}
