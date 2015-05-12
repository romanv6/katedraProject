using System;
using System.Collections;
using System.Collections.Generic;
public class Przedmiot
{

    private uint idKierunku;
    public uint IdKierunku
    {
        get { return idKierunku; }
        set { idKierunku = value; }
    }

    private List<string> typy;
    private string typ;
    public string Typ
    {
        get { return typ; }
        set {
            string val = value;
            if (val == typy[0] || val == typy[1] || val == typy[2] || val == typy[3] || val == typy[4])
            {
                typ = val;
            }
            else
            {
                throw new ApplicationException("B≥Ídny typ przedmioty. Sprawdü dane w pliku ürud≥owym.");
            }
        }
    }

	private string nazwa;
	public string Nazwa {
		get { return nazwa;}
        set { nazwa = value;}
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
    private int liczbaGodzinDoWykorzystania;
    public int LiczbaGodzinDoWykorzystania
    { 
        get; set; 
    }

	public Przedmiot(uint idKierunku, string nazwa, string kierunek, int liczbaGodzin) 
    {
        this.idKierunku = idKierunku;
        this.nazwa = nazwa;
        this.kierunek = kierunek;
        this.liczbaGodzin = liczbaGodzin;
        typy = new List<string>();
        typy.Add("wyklad");
        typy.Add("laboratorium");
        typy.Add("cwiczenia");
        typy.Add("fakultet");
        typy.Add("seminarium");
	}
}

