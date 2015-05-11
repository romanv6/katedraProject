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
	
	/// Maksymalna liczba grup jak¹ dany prowadz¹cy mo¿e uczyæ
    private int maxLiczbaGrup { get; set; }


	
	/// Przedmioty które mo¿e prowadziæ dany prowadz¹cy

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
