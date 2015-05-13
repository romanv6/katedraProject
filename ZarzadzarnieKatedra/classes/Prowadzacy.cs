using System;
using System.Collections;
using System.Collections.Generic; 
public class Prowadzacy : IComparable
{
    private string id { get; set; }
	private string imie{get;set;}
    private string nazwisko { get; set; }
    private int pesel { get; set; }
    private string tytul { get; set; }
    private string stanowisko { get; set; }
    private int pensum 
    { 
     get { return pensum; }
        set
        {
            if (stanowisko=="Rektor")
            {
                pensum = 30; //do skoñczenia, pensum zale¿y od stanowiska, stanowisko pobierane z pliku zewnêtrznego
            }
        }
    }

    private List<Przedmiot> przedmioty { public get; private set; } // Przedmioty które mo¿e prowadziæ dany prowadz¹cy
    private List<Przedmiot> przedmiotyNauczane {get; set;} //przedmioty, które prowadz¹cy aktualnie uczy
    private int liczbaUczonychGodzin; //liczba godzin aktualnie wykorzystanych przez prowadz¹cego
    private int pozostaloGodzin { get { return pensum - liczbaUczonychGodzin; } set; }
    

	public Prowadzacy(string imie, string nazwisko, int pesel, string tytul, string stanowisko) 
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.pesel = pesel;
        this.tytul = tytul;
        this.stanowisko = stanowisko;
        przedmioty = new List<Przedmiot>();
        przedmiotyNauczane = new List<Przedmiot>();
	}

    public int CompareTo(Prowadzacy prowadzacy)
    {
        return this.nazwisko.CompareTo(prowadzacy.nazwisko);
    }

    public void Edytuj(string imiê, string nazwisko, int pesel, string tytul, string stanowisko)
    {
        imiê = this.imie;
        nazwisko = this.nazwisko;
        pesel = this.pesel;
        tytul = this.tytul;
        stanowisko = this.stanowisko;
    }

    public void Edytuj(Prowadzacy prowadzacy)
    {
        //zmienia wartoœci obiektu przy pomocy kontrolek z GUI, do zrobienia
    }

    public override string ToString()
    {
        return "Imiê: " + imie + " Nazwisko: " + nazwisko + " Pesel: " + pesel + " Tytu³: " + tytul + " Stanowisko: " + stanowisko;
    }
}
