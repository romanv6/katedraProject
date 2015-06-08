using System;
using System.Collections.Generic;

namespace ZarzadzanieKatedra
{
    public class Symulacja
    {
        #region Nie rusza�!!!
        ListaPrzedmiotow listaPrzedmiotow;
        ListaProwadzacych listaProwadzacych;

        public Symulacja(ListaPrzedmiotow listaPrzedmiotow, ListaProwadzacych listaProwadzacych)
        {
            this.listaPrzedmiotow = listaPrzedmiotow;
            this.listaProwadzacych = listaProwadzacych;
        }

        /// <summary>
        /// funkcja pr�buje zrealizowa� pensum ka�dego z pracownik�w
        /// </summary>
        private void RealizacjaPensumProwadzacych()
        {
            int temp;
            foreach (Prowadzacy prowadzacy in listaProwadzacych)
            {
                temp = 0;
                while (prowadzacy.pozostaloGodzin > 0 && (temp < listaPrzedmiotow.Count)) //szukamy przedmiot�w dla prowadz�cego dop�ki jego pensum nie zostanie zrealizowane. Jak nasze dane nie pozaol� na realizacj� pensum, to p�tla biegnie w niesko�czono��
                {
                    temp++;
                    foreach (Przedmiot przedmiot in listaPrzedmiotow) //jako, �e pensum nie zosta�o zrealizowane szukamy przedmiotu, kt�ry mo�na prowadz�cemu przypisa�
                    {
                        if (prowadzacy.przedmiotyKtorychMozeUczyc.Contains(przedmiot.Nazwa)) //je�eli prowadz�cy mo�e uczy� danego przedmiotu, to przechodzimy dalej
                        {
                            if (przedmiot.PozostalaLiczbaGodzin >= przedmiot.LiczbaGodzinJednejGrupy) //je�eli liczba godzin tego przedmiotu do rozdysponowania, jest wi�ksza od liczby godzin jednej grupy
                            {
                                prowadzacy.LiczbaUczonychGodzin += przedmiot.LiczbaGodzinJednejGrupy; //prowadzacemu dajemy jedna grupe
                                przedmiot.PozostalaLiczbaGodzin -= przedmiot.LiczbaGodzinJednejGrupy; //przedmiotowi liczbe godzin do zrealizowania zmniejszamy o liczb� godzin jednej grupy
                                //przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy, przedmiot.LiczbaGodzinJednejGrupy); //prowadz�cego dodajemy do s�ownika os�b ucz�cych danego przedmiotu, wraz z przypisan� warto�ci� ilu godzin uczy
                                przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// funkcja pr�buje przypisa� prowadz�cych do przedmiot�w, kt�re nie zosta�y jeszcze zrealizowane
        /// </summary>
        private void RealizacjaWszystkichPrzedmiotow()
        {
            int temp;
            foreach (Przedmiot przedmiot in listaPrzedmiotow)
            {
                temp = 0;
                while (przedmiot.PozostalaLiczbaGodzin > 0 && (temp < listaProwadzacych.Count) ) //je�eli pozosta�y jeszcze jakie� godziny, �eby zrealizowa� dany przedmiot
                {
                    temp++;
                    foreach (Prowadzacy prowadzacy in listaProwadzacych) //to szukamy prowadz�cego, kt�remu mo�emy go da�
                    {
                        if (prowadzacy.przedmiotyKtorychMozeUczyc.Contains(przedmiot.Nazwa)) //je�eli prowadz�cy mo�e uczy� danego przedmiotu, to przechodzimy dalej
                        {
                            if ((prowadzacy.LiczbaUczonychGodzin + przedmiot.LiczbaGodzinJednejGrupy) <= (prowadzacy.Pensum * 2.5)) //sprawdzamy, czy po jak przypiszemy ten przedmiot prowadz�cemu, to nie przekroczymy jego g�rnej granicy godzin
                            {
                                prowadzacy.LiczbaUczonychGodzin += przedmiot.LiczbaGodzinJednejGrupy; //prowadzacemu dajemy jedna grupe
                                przedmiot.PozostalaLiczbaGodzin -= przedmiot.LiczbaGodzinJednejGrupy; //przedmiotowi liczbe godzin do zrealizowania zmniejszamy o liczb� godzin jednej grupy
                                //przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy, przedmiot.LiczbaGodzinJednejGrupy); //prowadz�cego dodajemy do s�ownika os�b ucz�cych danego przedmiotu, wraz z przypisan� warto�ci� ilu godzin uczy
                                przedmiot.OsobyProwadzacePrzedmiot.Add(prowadzacy);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// wykonuje symulacj�. Jak si� uda, zwraca true, jak nie false
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
        /// zwraca list� prowadz�cych po wykonaniu symulacji
        /// </summary>
        public ListaProwadzacych ZwrocListeProwadzacychPoSymulacji()
        {
            return listaProwadzacych;
        }

        /// <summary>
        /// zwraca list� przedmiot�w po wykonaniu symulacji
        /// </summary>
        public ListaPrzedmiotow ZwrocListePrzedmiotowPoSymulacji()
        {
            return listaPrzedmiotow;
        }

        #endregion
    }
}
