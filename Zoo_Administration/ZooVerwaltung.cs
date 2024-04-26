using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using verwaltungen;
using Zoo_Administration.General;

public class ZooVerwaltung
{
    private static verwaltungen.GehegeVerwaltung gehegeVerwaltung;
    private static List<Mitarbeiter> mitarbeiterListe;
    private static List<Tier> tierListe;
    private static List<Gehege> gehegeListe;

    public static void Main(string[] args)
    {
        //Initialisieren der hardcodierten Zoo-Tiere, Mitarbeiter und Gehege
        Initialisieren();

        //Begrüße Nutzer
        Console.WriteLine("Willkommen bei der Zoo-Verwaltung!");
        Verifikation();

        //Bitte Nutzer um Eingabe
        NutzerEingabe();
    }

    /// <summary>
    /// Diese Methode kann für alle Eingaben des Nutzers genutzt werden
    /// </summary>
    /// <returns>Die Eingabe des Nutzers als String oder ein leerer String, wenn etwas schief gelaufen ist in dem IO System.</returns>

    public static string NutzerEingabe()
	{
		// Fehlererkennung, falls etwas bei der Eingabe schief geht, hierdran bitte nichts ändern
		string antwort = "";
		try
		{
			antwort = Console.ReadLine();
		}
		catch (Exception e)
		{
			Console.WriteLine("Da ist etwas schief gegangen. Starten Sie das Programm neu.");
		}

		return antwort;
	}

    /// <summary>
    /// Generiert die Nummer einer Eingabe
    /// </summary>
    /// <param name="antwort">Übergebene Nutzer-Eingabe</param>
    /// <returns>Nummer aus der Nutzer-Eingabe</returns>

    private static int NummerVonEingabe(string antwort)
    {
        try
        {
            return int.Parse(antwort);
        }
        catch (FormatException)
        {
            return -1;
        }
    }
    /// <summary>
    /// Hier haben wir eine einfache Verifikation am Anfang der Software
    /// </summary>
    public static void Verifikation()
    {
        Console.WriteLine("Geben Sie Ihre Mitarbeiternummer ein:");

        string antwort = NutzerEingabe();

        int mitarbeiterNr = -1;

        if (!string.IsNullOrEmpty(antwort))
        {
            mitarbeiterNr = NummerVonEingabe(antwort);
        }
        Mitarbeiter mitarbeiter = mitarbeiterListe.FirstOrDefault(m => m.getMitarbeiterNr() == mitarbeiterNr);

        if (mitarbeiter == null)
            Console.WriteLine("Das Mitarbeiternummer ist falsch. Bitte starten Sie das Programm neu.");
        else
        {
            Console.WriteLine("Geben Sie das Passwort ein:");
            string passwortEingabe = NutzerEingabe();

            if (passwortEingabe == mitarbeiter.getPasswort())
            {
                if (mitarbeiter.getName() == "Hildegard Grün")
                {
                    //TODO: Ausgabe aller Tiere hinzufügen
                    Console.WriteLine("Willkommen in der Zoo Verwaltungs Software!");
                }
                else
                    Console.WriteLine("Willkommen in der Zoo Verwaltungs Software!");
                NutzerMenu1();
            }
            else
            {
                Console.WriteLine("Das Passwort ist falsch. Bitte starten Sie das Programm neu.");
            }

        }

    }
    /// <summary>
    /// Nutzer Eingabe
    /// </summary>
    public static void NutzerMenu1()
    {
        //Mögliche Nutzer anfragen
        string[] nutzerFragen = new string[]
        {
            "1) Gib Teile der Zoo Verwaltung aus.",
            "2) Verwalte Tiere.",
            "3) Verwalte Mitarbeiter.",
            "4) Verwalte Gehege.",
            "5) Bearbeiten die Gehegeverwaltung.",
            "6) Beenden"
        };

        //Frage den Nutzer was er tun möchte:
        Console.WriteLine("Was wollen Sie tun? Geben Sie eine Zahl ein:");
        foreach (string frage in nutzerFragen)
        {
            Console.WriteLine(frage);
        }

        string antwort = NutzerEingabe();

        //Verarbeite die Antwort des Nutzers (Sollte eine Zahl von 1 bis 5 sein.)
        if (!string.IsNullOrEmpty(antwort))
        {
            VerarbeiteNutzerMenu1(antwort);
        }
    }

    /// <summary>
    /// Soll die Nutzerantwort verarbeiten, je nach dem was gewollt ist, neue Sequenz an Fragen und Antworten einleiten
    /// </summary>
    /// <param name="antwort">Eingabe eines Nutzers</param>

    public static void VerarbeiteNutzerMenu1(string antwort)
	{
		int nummer = NummerVonEingabe(antwort);
		//Unterscheidung der eingegebenen Nummer
		switch (nummer)
		{
			case -1:
				Console.WriteLine("Das war keine der angegebenen Nummern.");
				break;
			case 1:
				//Methodenaufruf für Ausgabe
				NutzerOption1();
				break;
			case 2:
				//Methodenaufruf für Tiere
				break;
			case 3:
				//Methodenaufruf für Mitarbeiter
				break;
			case 4:
				//Methodenaufruf für Gehege
				break;
			case 5:
				//Methodenaufruf für Gehegeverwaltung
				break;
			case 6:
				//Methodenaufruf für Ende
				Beenden();
				break;
			default:
				Console.WriteLine("Das war keine der angegebenen Nummern.");
				break;
		}
	}

	/// <summary>
	/// Nutzer Eingabe für die Option 1 - Ausgabe
	/// </summary>
	public static void NutzerOption1()
	{
		//Mögliche Nutzer anfragen
		string[] nutzerFragen = new string[]
		{
			"1) Gib alle Tiere aus.",
			"2) Gib alle Mitarbeiter aus.",
			"3) Gib alle Gehege aus.",
			"4) Gib die Gehegeverwaltung aus."
		};

		//Frage den Nutzer was er ausgeben möchte:
		Console.WriteLine("Was wollen Sie ausgeben? Geben Sie eine Zahl ein:");
		foreach (string frage in nutzerFragen)
		{
			Console.WriteLine(frage);
		}

		string antwort = NutzerEingabe();

		//Verarbeite die Antwort des Nutzers (Sollte eine Zahl von 1 bis 5 sein.)
		if (!string.IsNullOrEmpty(antwort))
		{
			//Verarbeite die Nutzerantwort für die Ausgabe
			VerarbeiteNutzerEingabeOption1(antwort);
		}
	}

	/// <summary>
	/// Bearbeitet die Antwort des Nutzers auf Option 1
	/// </summary>
	/// <param name="antwort">Die Antwort des Nutzers auf Option 1</param>
	public static void VerarbeiteNutzerEingabeOption1(string antwort)
	{
		int nummer = NummerVonEingabe(antwort);
		switch (nummer)
		{
			case 1:
				//Gib alle Tiere aus
				break;
			case 2:
				//Gib alle Mitarbeiter aus
				break;
			case 3:
				//Gib alle Gehege aus
				break;
			case 4:
				//Gib die Gehegeverwaltung aus
				break;
			default:
				Console.WriteLine("Das war keine gültige Eingabe.");
				NutzerMenu1();
				break;
		}
	}

    /// <summary>
    /// Initialisiert die Zoo Verwaltung mit hardcodierten Daten
    /// </summary>
    public static void Initialisieren()
    {
        // Initialisiere Listen
        gehegeListe = new List<Gehege>();
        mitarbeiterListe = new List<Mitarbeiter>();
        tierListe = new List<Tier>();

        // Erschaffe Gehege
        Gehege gehege1 = new Gehege(1, 10, 3, "Löwengehege");
        gehegeListe.Add(gehege1);
        Gehege gehege2 = new Gehege(2, 20, 5, "Streichelzoo");
        gehegeListe.Add(gehege2);
        Gehege gehege3 = new Gehege(3, 5, 2, "Menschenaffengehege");
        gehegeListe.Add(gehege3);

        // Erschaffe Mitarbeiter
        mitarbeiterListe.Add(new Mitarbeiter(1, "Herbert Grün", 88, 6200, "ZoodirektorIn", "12345"));
        mitarbeiterListe.Add(new Mitarbeiter(2, "Hildegard Grün", 88, 6200, "ZoodirektorIn","12346"));
        mitarbeiterListe.Add(new Mitarbeiter(3, "Hannelore Specht", 34, 2300, "TierpflegerIn", "98765"));
        mitarbeiterListe.Add(new Mitarbeiter(4, "Friedrich Müller", 45, 3200, "TierpflegerIn", "56789"));
        mitarbeiterListe.Add(new Mitarbeiter(5, "Elisa Grün", 23, 450, "KassiererIn", "13579"));
        mitarbeiterListe.Add(new Mitarbeiter(6, "Ali Mohammed", 19, 450, "KassiererIn", "24680"));
        mitarbeiterListe.Add(new Mitarbeiter(7, "Marianne Jakobs", 23, 3100, "Verwaltungskraft", "25912"));
        mitarbeiterListe.Add(new Mitarbeiter(8, "Niko Bart", 21, 3000, "Verwaltungskraft", "25911"));
        mitarbeiterListe.Add(new Mitarbeiter(9, "Franz Hubert", 35, 3300, "Verwaltungskraft", "25913"));

        // Erschaffe Tiere
        string[] loewen = { "Anton", "Bernd", "Claudia", "Ditrich" };
        string[] ziegen = { "Ella", "Franzi", "Gertrud", "Hilda", "Inge", "Jakob", "Karl" };
        string[] affen = { "Leopold", "Malte", "Ni", "Oppi", "Paulus" };

        Random random = new Random(); 
        for (int i = 0; i < loewen.Length; i++)
        {
            int zufallsAlter = random.Next(1, 7);
            int eindeutigeTierNummer = i;
            tierListe.Add(new Tier(eindeutigeTierNummer, zufallsAlter, 1, loewen[i], "Löwe"));
        }
        for (int i = 0; i < ziegen.Length; i++)
        {
            int zufallsAlter = random.Next(1, 7);
            int eindeutigeTierNummer = i + loewen.Length;
            tierListe.Add(new Tier(eindeutigeTierNummer, zufallsAlter, 2, ziegen[i], "Ziege"));
        }
        for (int i = 0; i < affen.Length; i++)
        {
            int zufallsAlter = random.Next(1, 7);
            int eindeutigeTierNummer = i + ziegen.Length + loewen.Length;
            tierListe.Add(new Tier(eindeutigeTierNummer, zufallsAlter, 3, affen[i], "Menschenaffe"));
        }

        // Erschaffe GehegeVerwaltung
        // Hier haben wir das so geregelt, dass ein Gehege je eine Verwaltungskraft und einen Tierpfleger hat
        // Dieser Tierpfleger ist dann auch für alle Tiere im Gehege verantwortlich
        gehegeVerwaltung = new GehegeVerwaltung();
        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[0], (Mitarbeiter)mitarbeiterListe[6], (Mitarbeiter)mitarbeiterListe[2]);
        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[1], (Mitarbeiter)mitarbeiterListe[7], (Mitarbeiter)mitarbeiterListe[3]);
        gehegeVerwaltung.HinzufÜgen((Gehege)gehegeListe[2], (Mitarbeiter)mitarbeiterListe[8], (Mitarbeiter)mitarbeiterListe[3]);
    }
    /// <summary>
    /// Endes
    /// </summary>
    public static void Beenden()
    {
        Console.WriteLine("Auf Wiedersehen!");
    }
}



