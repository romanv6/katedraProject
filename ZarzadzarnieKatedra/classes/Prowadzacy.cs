using System;
using System.Collections;
using System.Collections.Generic; 
public class Prowadzacy 
{
	private string imie{get;set;}

    private string nazwisko { get; set; }
    
    private int pesel { get; set; }

    private string tytul { get; set; }

    private string stanowisko { get; set; }

    private int pensum { get; set; }
	
	/// Maksymalna liczba grup jak� dany prowadz�cy mo�e uczy�
    private int maxLiczbaGrup { get; set; }


	
	/// Przedmioty kt�re mo�e prowadzi� dany prowadz�cy

    private List<Przedmiot> przedmioty;

	public Prowadzacy(string imie, string nazwisko, int pesel, string tytul, string stanowisko, int pensum, int maxLiczbaGrup) 
    {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.pesel = pesel;
        this.tytul = tytul;
        this.stanowisko = stanowisko;
        this.pensum = pensum;
        this.maxLiczbaGrup = maxLiczbaGrup;
        przedmioty = new List<Przedmiot>();
	}

    



}
