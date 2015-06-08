using System;
using System.Collections.Generic;

namespace ZarzadzanieKatedra
{
    public class Symulacja
    {
        #region Nie ruszaæ!!!
        ListaPrzedmiotow listaPrzedmiotow;
        ListaProwadzacych listaProwadzacych;

        public Symulacja(ListaPrzedmiotow listaPrzedmiotow, ListaProwadzacych listaProwadzacych)
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
            foreach (Prowadzacy prowadzacy in listaProwadzacych)
            {
                temp = 0;
                while (prowadzacy.pozostaloGodzin > 0 && (temp < listaPrzedmiotow.Count)) //szukamy przedmiotów dla prowadz¹cego dopóki jego pensum nie zostanie zrealizowane. Jak nasze dane nie pozaol¹ na realizacjê pensum, to pêtla biegnie w nieskoñczonoœæ
                {
                    temp++;
                    foreach (Przedmiot przedmiot in listaPrzedmiotow) //jako, ¿e pensum nie zosta³o zrealizowane szukamy przedmiotu, który mo¿na prowadz¹cemu przypisaæ
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
            foreach (Przedmiot przedmiot in listaPrzedmiotow)
            {
                temp = 0;
                while (przedmiot.PozostalaLiczbaGodzin > 0 && (temp < listaProwadzacych.Count) ) //je¿eli pozosta³y jeszcze jakieœ godziny, ¿eby zrealizowaæ dany przedmiot
                {
                    temp++;
                    foreach (Prowadzacy prowadzacy in listaProwadzacych) //to szukamy prowadz¹cego, któremu mo¿emy go daæ
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

            foreach (Przedmiot przedmiot in listaPrzedmiotow)
            {
                if (przedmiot.PozostalaLiczbaGodzin > 0)
                {
                    return false;
                }
            }

            foreach (Prowadzacy prowadzacy in listaProwadzacych)
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
        public ListaProwadzacych ZwrocListeProwadzacychPoSymulacji()
        {
            return listaProwadzacych;
        }

        /// <summary>
        /// zwraca listê przedmiotów po wykonaniu symulacji
        /// </summary>
        public ListaPrzedmiotow ZwrocListePrzedmiotowPoSymulacji()
        {
            return listaPrzedmiotow;
        }

        #endregion
    }
}
