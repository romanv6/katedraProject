using System;
using System.Collections;
using System.Collections.Generic;

namespace ZarzadzanieKatedraWFormsach
{
    public class Przedmiot
    {
        private List<Prowadzacy> osobyProwadzacePrzedmiot;

        private int id;
        public int Id {
            get { return id; }
            set { id = value; }
        }

        private string nazwa;
        public string Nazwa
        {
            get { return nazwa; }
            set { nazwa = value; }
        }

        private string kierunek;
        public string Kierunek
        {
            get { return kierunek; }
            set { kierunek = value; }
        }

        private int liczbaGodzin;
        public int LiczbaGodzin
        {
            get { return liczbaGodzin; }
            set { liczbaGodzin = value; }
        }

        private int pozostalaLiczbaGodzin;
        public int PozostalaLiczbaGodzin
        {
            get { return pozostalaLiczbaGodzin; }
            set { pozostalaLiczbaGodzin = value; }
        }

        private int liczbaUczacych;
        public int LiczbaUczacych
        {
            get { return liczbaUczacych; }
            set { liczbaUczacych = value; }
        }

        private string typPrzedmiotu;
        public string TypPrzedmiotu
        {
            get { return typPrzedmiotu; }
            set { typPrzedmiotu = value; }
        }

        public Przedmiot(int id, string nazwa, string kierunek, int liczbaGodzin, string typPrzedmiotu)
        {
            Id = id;
            Nazwa = nazwa;
            Kierunek = kierunek;
            LiczbaGodzin = liczbaGodzin;
            PozostalaLiczbaGodzin = liczbaGodzin;
            TypPrzedmiotu = typPrzedmiotu;
            osobyProwadzacePrzedmiot = new List<Prowadzacy>();
        }

        public override string ToString()
        {
            return id + " " + Nazwa + " " + Kierunek + " " + LiczbaGodzin + " " + TypPrzedmiotu + " " + PozostalaLiczbaGodzin;
        }
    }
}

