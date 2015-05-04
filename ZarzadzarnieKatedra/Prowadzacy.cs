using System;
public class Prowadzacy {
	private string imie;
	public string Imie {
		get {
			return imie;
		}
		set {
			imie = value;
		}
	}
	private string nazwisko;
	public string Nazwisko {
		get {
			return nazwisko;
		}
		set {
			nazwisko = value;
		}
	}
	private int pesel;
	public int Pesel {
		get {
			return pesel;
		}
		set {
			pesel = value;
		}
	}
	private string tytul;
	public string Tytul {
		get {
			return tytul;
		}
		set {
			tytul = value;
		}
	}
	private string stanowisko;
	public string Stanowisko {
		get {
			return stanowisko;
		}
		set {
			stanowisko = value;
		}
	}
	private int pensum;
	public int Pensum {
		get {
			return pensum;
		}
		set {
			pensum = value;
		}
	}
	/// <summary>
	/// Maksymalna liczba grup jak¹ dany prowadz¹cy mo¿e uczyæ
	/// </summary>
	private int maxLiczbaGrup;
	public int MaxLiczbaGrup {
		get {
			return maxLiczbaGrup;
		}
		set {
			maxLiczbaGrup = value;
		}
	}
	/// <summary>
	/// Przedmioty które mo¿e prowadziæ dany prowadz¹cy
	/// </summary>
	private Przedmiot[] przedmioty;

	public Prowadzacy(string imie, string nazwisko, string pesel, string tytul, string stanowisko) {
		throw new System.Exception("Not implemented");
	}
	public void EdytujDane(string imie, string nazwisko, string pesel, string tytul, string stanowisko) {
		throw new System.Exception("Not implemented");
	}



}
