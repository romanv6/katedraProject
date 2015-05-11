using System;
public class ListaPrzedmiotow {
	/// <summary>
	/// To jest lista objektów Przedmiot
	/// </summary>
	private List<Przedmiot> lista;
	public List<Przedmiot> Lista {
		get {
			return lista;
		}
		set {
			lista = value;
		}
	}

	/// <summary>
	/// Konstruktor
	/// </summary>
	public ListaPrzedmiotow() {
		throw new System.Exception("Not implemented");
	}
	/// <summary>
	/// Funkcja wczytuje do listy przedmioty z pliku za pomoc¹ funkcji WczytajPrzedmioty() klasy statycznej WczytajPliki
	/// </summary>
	/// <param name="sciezka">Œcie¿ka do pliku z list¹ przedmiotów</param>
	public List<Przedmiot> Wczytaj(string sciezka) {
		throw new System.Exception("Not implemented");
	}
	/// <param name="sciezka">Œcie¿ka do pliku, w którym zapiszemy listê</param>
	public void Zapisz(string sciezka) {
		throw new System.Exception("Not implemented");
	}

	private Przedmiot attribute;
	private Przedmiot -Lista;

}
