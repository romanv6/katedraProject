using System;
using System.Collections;
using System.Collections.Generic;

namespace ZarzadzanieKatedra
{
    public class Przedmiot : IComparable<Przedmiot>
    {
        #region Nie rusza�!!!!

        /// <summary>
        /// osoby, kt�re dany przedmiot prowadz�, oraz liczna godzin, kt�re prowadz�
        /// </summary>
        public List<Prowadzacy> OsobyProwadzacePrzedmiot;
        //public Dictionary<Prowadzacy, int> OsobyProwadzacePrzedmiot;

        /// <summary>
        /// inikalny identyfikator przedmiotu
        /// </summary>
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// nazwa przedmiotu
        /// </summary>
        private string nazwa;
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }

        /// <summary>
        /// kierunek na kt�rym przedmiot jest uczony
        /// </summary>
        private string kierunek;
        public string Kierunek
        {
            get { return kierunek; }
            set { kierunek = value; }
        }

        /// <summary>
        /// ile godzin musi zrealizowa� jedna grupa �wiczeniowa/laboratoryjna itp. danego przedmiotu
        /// </summary>
        private int liczbaGodzinJednejGrupy;
        public int LiczbaGodzinJednejGrupy
        {
            get { return liczbaGodzinJednejGrupy; }
            set { liczbaGodzinJednejGrupy = value; }
        }

        /// <summary>
        /// laczna liczba godzin (liczba grup razy liczba godzin)
        /// </summary>
        private int lacznaLiczbaGodzinPrzedmiotu;
        public int LacznaLiczbaGodzinPrzedmiotu
        {
            get { return lacznaLiczbaGodzinPrzedmiotu; }
            set { lacznaLiczbaGodzinPrzedmiotu = value; }
        }

        /// <summary>
        /// liczba godzin w obr�bie danego przedmiotu, kt�ra pozosta�a do rozpisania
        /// </summary>
        private int pozostalaLiczbaGodzin;
        public int PozostalaLiczbaGodzin
        {
            get { return pozostalaLiczbaGodzin; }
            set { pozostalaLiczbaGodzin = value; }
        }

        /// <summary>
        /// ile os�b mo�e uczy� danego przedmiotu
        /// </summary>
        private int liczbaUczacych;
        public int LiczbaUczacych
        {
            get { return liczbaUczacych; }
            set { liczbaUczacych = value; }
        }

        /// <summary>
        /// typ przedmiotu (wyklad,lab itp.)
        /// </summary>
        private string typPrzedmiotu;
        public string TypPrzedmiotu
        {
            get { return typPrzedmiotu; }
            set { typPrzedmiotu = value; }
        }

        /// <summary>
        /// numer semestru jest nam potrzebny, �eby w zale�no�ci od niego okre�i� ile jest grup.
        /// </summary>
        private int numerSemestru;
        public int NumerSemestru
        {
            get { return numerSemestru; }
            set { numerSemestru = value; }
        }

        /// <summary>
        /// Rok, w kt�rym zostanie zrealizowany.
        /// </summary>
        private int numerRoku;
        public int NumerRoku
        {
            get { return numerRoku; }
            set { numerRoku = value; }
        }

        /// <summary>
        /// konstruktor
        /// </summary>
        public Przedmiot(int id, string nazwa, string kierunek, int liczbaGodzinJednejGrupy, string typPrzedmiotu, int numerSemestru, int numerRoku)
        {
            Id = id;
            Nazwa = nazwa;
            Kierunek = kierunek;
            LiczbaGodzinJednejGrupy = liczbaGodzinJednejGrupy;
            NumerSemestru = numerSemestru;
            TypPrzedmiotu = typPrzedmiotu;
            LacznaLiczbaGodzinPrzedmiotu = LacznaLiczbaGodzinWZaleznosciOdSemestru(NumerSemestru, TypPrzedmiotu);
            PozostalaLiczbaGodzin = LacznaLiczbaGodzinPrzedmiotu;
            //OsobyProwadzacePrzedmiot = new Dictionary<Prowadzacy, int>();
            OsobyProwadzacePrzedmiot = new List<Prowadzacy>();
            NumerRoku = numerRoku;
        }

        /// <summary>
        /// metoda zwraca ��czn� liczb� godzin kt�re odb�d� si� w obr�bie danego przedmiotu
        /// </summary>
        public int LacznaLiczbaGodzinWZaleznosciOdSemestru(int numerSemestru, string typPrzedmiotu)
        {
            if (typPrzedmiotu != "wyk�ad") //wyk�adu nie ma podzia�u na grupy
            {
                if (numerSemestru == 1)
                {
                    return liczbaGodzinJednejGrupy * 8; //na pierwszym semestrze jest 8 grup
                }
                else if (numerSemestru == 2)
                {
                    return liczbaGodzinJednejGrupy * 6; //na 2 semestrze jest 6 grup
                }
                else if (numerSemestru == 3)
                {
                    return liczbaGodzinJednejGrupy * 5; //na 3 semestrze jest 5 grup
                }
                else if (numerSemestru == 4)
                {
                    return liczbaGodzinJednejGrupy * 4; //na 4 semestrze jest 5 grup
                }
                else if (numerSemestru == 5)
                {
                    return liczbaGodzinJednejGrupy * 4; //na 5 semestrze jest 4 grup
                }
                else if (numerSemestru == 6 || numerSemestru == 7)
                {
                    return liczbaGodzinJednejGrupy * 4; //na 6,7 semestrze s� 4 grup
                }
                else
                {
                    return liczbaGodzinJednejGrupy * 2; //powy�ej (magisterka itp.) s� 2 grupy
                }
            }
            else
            {
                return liczbaGodzinJednejGrupy; //wyk�adu nie ma podzia�u na grupy, liczba godzin jest taka sama
            }
        }

        public override string ToString()
        {
            return Id + " " + Nazwa + " " + Kierunek + " " + LiczbaGodzinJednejGrupy + " " + LacznaLiczbaGodzinPrzedmiotu + " " + TypPrzedmiotu + " " + PozostalaLiczbaGodzin + " " + liczbaUczacych + " " + numerSemestru + " " + numerRoku;
        }

        #endregion

        public int CompareTo(Przedmiot other)
        {
            return this.Nazwa.CompareTo(other.Nazwa);
        }
    }
}

