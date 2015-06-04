using System;
using System.Collections;
using System.Collections.Generic;

namespace ZarzadzanieKatedraWFormsach
{
    public class Przedmiot
    {
        #region Nie ruszaæ!!!!

        /// <summary>
        /// osoby, które dany przedmiot prowadz¹, oraz liczna godzin, które prowadz¹
        /// </summary>
        public List<Prowadzacy> OsobyProwadzacePrzedmiot;
        //public Dictionary<Prowadzacy, int> OsobyProwadzacePrzedmiot;

        /// <summary>
        /// inikalny identyfikator przedmiotu
        /// </summary>
        private int id;
        public int Id {
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
        /// kierunek na którym przedmiot jest uczony
        /// </summary>
        private string kierunek;
        public string Kierunek
        {
            get { return kierunek; }
            set { kierunek = value; }
        }

        /// <summary>
        /// ile godzin musi zrealizowaæ jedna grupa æwiczeniowa/laboratoryjna itp. danego przedmiotu
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
        /// liczba godzin w obrêbie danego przedmiotu, która pozosta³a do rozpisania
        /// </summary>
        private int pozostalaLiczbaGodzin;
        public int PozostalaLiczbaGodzin
        {
            get { return pozostalaLiczbaGodzin; }
            set { pozostalaLiczbaGodzin = value; }
        }

        /// <summary>
        /// ile osób mo¿e uczyæ danego przedmiotu
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
        /// numer semestru jest nam potrzebny, ¿eby w zale¿noœci od niego okreœiæ ile jest grup.
        /// </summary>
        private int numerSemestru;
        public int NumerSemestru {
            get { return numerSemestru; }
            set { numerSemestru = value; }
        }

        /// <summary>
        /// Rok, w którym zostanie zrealizowany.
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
        /// metoda zwraca ³¹czn¹ liczbê godzin które odbêd¹ siê w obrêbie danego przedmiotu
        /// </summary>
        public int LacznaLiczbaGodzinWZaleznosciOdSemestru(int numerSemestru, string typPrzedmiotu)
        {
            if (typPrzedmiotu != "wyk³ad") //wyk³adu nie ma podzia³u na grupy
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
                    return liczbaGodzinJednejGrupy * 4; //na 6,7 semestrze s¹ 4 grup
                }
                else
                {
                    return liczbaGodzinJednejGrupy * 2; //powy¿ej (magisterka itp.) s¹ 2 grupy
                }
            }
            else
            {
                return liczbaGodzinJednejGrupy; //wyk³adu nie ma podzia³u na grupy, liczba godzin jest taka sama
            }
        }

        public override string ToString()
        {
            return Id + " " + Nazwa + " " + Kierunek + " " + LiczbaGodzinJednejGrupy + " " + LacznaLiczbaGodzinPrzedmiotu + " " + TypPrzedmiotu + " " + PozostalaLiczbaGodzin + " " + liczbaUczacych + " " + numerSemestru + " " + numerRoku;
        }

        #endregion
    }
}

