using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ZarzadzanieKatedra
{

    public class Prowadzacy : IComparable<Prowadzacy>
    {
        #region pola klasy, które mog¹ Ci siê przydaæ przy poprawianiu kodu

        Stanowiska typyStanowisk;
        TypyPracownikow typyPracownikow;

        /// <summary>
        /// unikalny identyfikator prowadz¹cego
        /// </summary>
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// imiê prowadz¹cego
        /// </summary>
        private string imie;
        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        /// <summary>
        /// nazwisko prowadz¹cego
        /// </summary>
        private string nazwisko;
        public string Nazwisko
        {
            get { return nazwisko; }
            set { nazwisko = value; }
        }

        /// <summary>
        /// pesel prowadz¹cego
        /// </summary>
        private string pesel;
        public string Pesel
        {
            get { return pesel; }
            set { pesel = value; }
        }

        /// <summary>
        /// tytu³ prowadz¹cego (Profesor, Doktor itp.)
        /// </summary>
        private string tytul;
        public string Tytul
        {
            get { return tytul; }
            set { tytul = value; }
        }

        /// <summary>
        /// stanowisko prowadzacego (Audient, wykladowca itp.)
        /// </summary>
        private string stanowisko;
        public string Stanowisko
        {
            get { return stanowisko; }
            set { stanowisko = value; }
        }

        /// <summary>
        /// stanowisko prowadzacego (dziekan, Rektor itp.)
        /// </summary>
        private string typPracownika;
        public string TypPracownika
        {
            get { return typPracownika; }
            set { typPracownika = value; }
        }

        /// <summary>
        /// pensum prowadz¹cego
        /// </summary>
        private int pensum;
        public int Pensum
        {
            get { return pensum; }
            set { pensum = value; }
        }

        /// <summary>
        /// liczba godzin, które ju¿ zosta³y rozdysponowane
        /// </summary>
        private int liczbaUczonychGodzin;
        public int LiczbaUczonychGodzin
        {
            get { return liczbaUczonychGodzin; }
            set { liczbaUczonychGodzin = value; }
        }

        /// <summary>
        /// liczba godzin, która pozosta³a do rozdysponowania
        /// </summary>
        public int pozostaloGodzin
        {
            get { return pensum - liczbaUczonychGodzin; }
        }

        /// <summary>
        /// metoda ustala pensum w zale¿noœci od stanowiska
        /// </summary>
        private void UstalPensum()
        {
            typyStanowisk = new Stanowiska();
            typyPracownikow = new TypyPracownikow();
            pensum = Convert.ToInt32(Stanowiska.ZwrocLiczbeGodzinDlaStanowiska(Stanowisko) * TypyPracownikow.ZwrocLiczbeGodzinDlaStanowiska(TypPracownika));
        }

        /// <summary>
        /// liczba przedmiotów, których mo¿e dany prowadz¹cy uczyæ
        /// </summary>
        private int liczbaPrzedmiotowKtorychMozeUczyc;
        public int LiczbaPrzedmiotowKtorychMozeUczyc
        {
            get { return liczbaPrzedmiotowKtorychMozeUczyc; }
            set { liczbaPrzedmiotowKtorychMozeUczyc = value; }
        }

        /// <summary>
        /// przedmioty, których mo¿e uczyæ dany prowadz¹cy
        /// </summary>
        public List<string> przedmiotyKtorychMozeUczyc;

        public Dupa Ser { get; set; }
        public enum Dupa { ser,twaróg}
        public ObservableCollection<string> PrzedmiotyKtorychMozeUczyc
        {
            get
            {
                ObservableCollection<string> returnListModel = null;
                foreach (var item in przedmiotyKtorychMozeUczyc)
                {
                    if (returnListModel == null) returnListModel = new ObservableCollection<string>();
                    returnListModel.Add(item);
                }
                return returnListModel;
            }
        }

        /// <summary>
        /// konstruktor
        /// </summary>
        public Prowadzacy(int id, string imie, string nazwisko, string pesel, string tytul, string stanowisko, string typPracownika, List<string> przedmiotyKtorychMozeUczyc, int liczbaPrzedmiotowKtorychMozeUczyc)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            Tytul = tytul;
            Stanowisko = stanowisko;
            TypPracownika = typPracownika;
            UstalPensum();
            this.przedmiotyKtorychMozeUczyc = przedmiotyKtorychMozeUczyc;
            LiczbaPrzedmiotowKtorychMozeUczyc = liczbaPrzedmiotowKtorychMozeUczyc;
        }

        public override string ToString()
        {
            return Id + " " + Imie + " " + Nazwisko + " " + Pesel + " " + Tytul + " " + Stanowisko + " " + Pensum + " " + LiczbaUczonychGodzin + " " + LiczbaPrzedmiotowKtorychMozeUczyc + " " + TypPracownika;
        }

        #endregion

        public int CompareTo(Prowadzacy prowadzacy)
        {
            return this.nazwisko.CompareTo(prowadzacy.nazwisko);
        }

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
    }
}
