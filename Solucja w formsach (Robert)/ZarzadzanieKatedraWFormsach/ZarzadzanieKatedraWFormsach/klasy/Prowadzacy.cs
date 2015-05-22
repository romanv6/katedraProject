using System;
using System.Collections;
using System.Collections.Generic;

namespace ZarzadzanieKatedraWFormsach
{

    public class Prowadzacy //: IComparable
    {
        Stanowiska typyStanowisk;

        private int id;
        public int Id {
            get { return id; }
            set { id = value; } 
        }
        private string imie;
        public string Imie {
            get { return imie; }
            set { imie = value; }
        }

        private string nazwisko;
        public string Nazwisko {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        private int pesel;
        public int Pesel {
            get { return pesel; }
            set { pesel = value; }
        }

        private string tytul;
        public string Tytul {
            get { return tytul; }
            set { tytul = value; } 
        }

        private string stanowisko;
        public string Stanowisko {
            get { return stanowisko; }
            set { stanowisko = value; }
        }

        private int pensum;
        public int Pensum {
            get { return pensum; }
            set { pensum = value; }
        }

        private int liczbaUczonychGodzin; //liczba godzin aktualnie wykorzystanych przez prowadz¹cego
        public int LiczbaUczonychGodzin {
            get { return liczbaUczonychGodzin; }
            set { liczbaUczonychGodzin = value; }
        }
        
        public int pozostaloGodzin { 
            get { return pensum - liczbaUczonychGodzin; }
        }

        private void UstalPensum()
        {
            typyStanowisk = new Stanowiska();
            pensum = Stanowiska.ZwrocLiczbeGodzinDlaStanowiska(stanowisko);
        }

        public List<string> przedmiotyKtorychMozeUczyc; // Przedmioty, których mo¿e uczyæ dany prowadz¹cy

        public Prowadzacy(int id, string imie, string nazwisko, int pesel, string tytul, string stanowisko, List<string> przedmiotyKtorychMozeUczyc)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            Tytul = tytul;
            Stanowisko = stanowisko;
            UstalPensum();
            this.przedmiotyKtorychMozeUczyc = przedmiotyKtorychMozeUczyc;
        }

        public override string ToString()
        {
            return "Imiê: " + imie + " Nazwisko: " + nazwisko + " Pesel: " + pesel + " Tytu³: " + tytul + " Stanowisko: " + stanowisko;
        }

        //public int CompareTo(Prowadzacy prowadzacy)
        //{
        //    return this.nazwisko.CompareTo(prowadzacy.nazwisko);
        //}

        //public void Edytuj(string imiê, string nazwisko, int pesel, string tytul, string stanowisko)
        //{
        //    imiê = this.imie;
        //    nazwisko = this.nazwisko;
        //    pesel = this.pesel;
        //    tytul = this.tytul;
        //    stanowisko = this.stanowisko;
        //}

        //public void Edytuj(Prowadzacy prowadzacy)
        //{
        //    //zmienia wartoœci obiektu przy pomocy kontrolek z GUI, do zrobienia
        //}

        //public int CompareTo(object obj)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
