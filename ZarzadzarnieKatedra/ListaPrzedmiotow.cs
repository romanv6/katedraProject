using System;
public class ListaPrzedmiotow {
	/// <summary>
	/// To jest lista objekt�w Przedmiot
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
	/// Konstruktor-test
	/// </summary>
	public ListaPrzedmiotow() {
		throw new System.Exception("Not implemented");
	}
	/// <summary>
	/// Funkcja wczytuje do listy przedmioty z pliku za pomoc� funkcji WczytajPrzedmioty() klasy statycznej WczytajPliki
	/// </summary>
	/// <param name="sciezka">�cie�ka do pliku z list� przedmiot�w</param>
	public List<Przedmiot> Wczytaj(string sciezka) {
		throw new System.Exception("Not implemented");
	}
	/// <param name="sciezka">�cie�ka do pliku, w kt�rym zapiszemy list�</param>
	public void Zapisz(string sciezka) {
		throw new System.Exception("Not implemented");
	}

	private Przedmiot attribute;
	private Przedmiot -Lista;

}
