using System;
using System.Runtime.InteropServices;
public class Przedmiot {
	private string nazwa;
	public string Nazwa {
		get {
			return nazwa;
		}
		set {
			nazwa = value;
		}
	}
	private string typ;
	public string Typ {
		get {
			return typ;
		}
		set {
			typ = value;
		}
	}

	public Przedmiot(string nazwa, string typ) {
		throw new System.Exception("Not implemented");
	}


}
