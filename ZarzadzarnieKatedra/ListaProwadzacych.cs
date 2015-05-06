using System;
using System.Collections;
public class ListaProwadzacych : ICollection {
	/// <summary>
	/// To jest lista prowadz¹cych
	/// </summary>
	private List<Prowadzacy> lista;

	/// <summary>
	/// Konstruktor
	/// </summary>
	public ListaProwadzacych() {
		lista = new List<Prowadzacy>();
	}
	/// <summary>
	/// Funkcja wczytuje do listy prowadzacych z pliku za pomoc¹ funkcji WczytajProwadzacych() klasy statycznej WczytajPliki
	/// </summary>
	/// <param name="sciezka">Œcie¿ka do pliku z list¹ prowadz¹cych</param>
	public List<Przedmiot> Wczytaj(string sciezka) {
		throw new System.Exception("Not implemented");
	}
	/// <param name="sciezka">Sciezka do pliku, w którym zapiszemy listê</param>
	public void Zapisz(string sciezka) {
		throw new System.Exception("Not implemented");
	}

}
