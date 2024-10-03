using System;
using System.Collections.Generic;

class TaskMaster
{
    // Liste zum Speichern der Aufgaben
    private List<string> aufgabenListe = new List<string>();

    static void Main(string[] args)
    {
        // Initialisierung der TaskMaster-Klasse und Aufruf des Hauptmenüs
        TaskMaster taskMaster = new TaskMaster();
        taskMaster.HauptMenue();
    }

    // Hauptmenü der Anwendung
    public void HauptMenue()
    {
        bool laeuft = true; // Bool-Variable zur Steuerung der Schleife

        while (laeuft) // Schleife läuft, solange die Variable laeuft true ist
        {
            // Anzeige der Menüoptionen
            Console.WriteLine("\nWillkommen bei TaskMaster!");
            Console.WriteLine("1. Aufgabe hinzufügen");
            Console.WriteLine("2. Aufgabenliste anzeigen");
            Console.WriteLine("3. Aufgabe bearbeiten");
            Console.WriteLine("4. Aufgabe löschen");
            Console.WriteLine("5. Programm beenden");
            Console.Write("Wählen Sie eine Option: ");

            // Einlesen der Benutzerauswahl
            if (!int.TryParse(Console.ReadLine(), out int auswahl))  // Alternativ Convert.ToInt32
            {
                Console.WriteLine("Dies ist keine gültige Ganzzahl. Bitte versuchen Sie es erneut.");
                continue; // Schleife wiederholen
            }

            // Auswahl entsprechend der Benutzereingabe
            switch (auswahl)
            {
                case 1:
                    AufgabeHinzufuegen(); // Neue Aufgabe hinzufügen
                    break;
                case 2:
                    AufgabenListeAnzeigen(); // Aufgaben anzeigen
                    break;
                case 3:
                    AufgabeBearbeiten(); // Aufgabe bearbeiten
                    break;
                case 4:
                    AufgabeLoeschen(); // Aufgabe löschen
                    break;
                case 5:
                    Console.WriteLine("Danke, dass Sie TaskMaster genutzt haben. Programm beendet.");
                    laeuft = false; // Setzt die Variable auf false, um die Schleife zu beenden
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl, bitte erneut versuchen.");
                    break;
            }
        }
    }

    // Hinzufügen einer neuen Aufgabe
    public void AufgabeHinzufuegen()
    {
        // Eingabe der Aufgabenbeschreibung
        Console.Write("Geben Sie die Beschreibung der Aufgabe ein: ");
        string beschreibung = Console.ReadLine();

        // Aufgabe zur Liste hinzufügen
        aufgabenListe.Add(beschreibung);
        Console.WriteLine("Aufgabe hinzugefügt.");
    }

    // Anzeigen der Liste aller Aufgaben
    public void AufgabenListeAnzeigen()
    {
        if (aufgabenListe.Count == 0)
        {
            // Wenn keine Aufgaben vorhanden sind
            Console.WriteLine("Keine Aufgaben vorhanden.");
        }
        else
        {
            // Anzeige der Aufgaben mit Nummerierung
            Console.WriteLine("Aufgabenliste:");
            for (int i = 0; i < aufgabenListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {aufgabenListe[i]}");
            }
        }
    }

    // Bearbeiten einer bestehenden Aufgabe
    public void AufgabeBearbeiten()
    {
        AufgabenListeAnzeigen(); // Aufgaben anzeigen
        if (aufgabenListe.Count > 0)
        {
            // Auswahl der zu bearbeitenden Aufgabe
            Console.Write("Wählen Sie die Nummer der Aufgabe zum Bearbeiten: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= aufgabenListe.Count)
            {
                // Neue Beschreibung eingeben
                Console.Write("Neue Beschreibung eingeben: ");
                string neueBeschreibung = Console.ReadLine();

                // Aufgabe aktualisieren
                aufgabenListe[index - 1] = neueBeschreibung; // Index -1 da der Index bei 0 beginnt
                Console.WriteLine("Aufgabe aktualisiert.");
            }
            else
            {
                Console.WriteLine("Ungültige Auswahl.");
            }
        }
    }

    // Löschen einer bestehenden Aufgabe
    public void AufgabeLoeschen()
    {
        AufgabenListeAnzeigen(); // Aufgaben anzeigen
        if (aufgabenListe.Count > 0)
        {
            // Auswahl der zu löschenden Aufgabe
            Console.Write("Wählen Sie die Nummer der Aufgabe zum Löschen: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= aufgabenListe.Count)
            {
                // Aufgabe aus der Liste entfernen
                aufgabenListe.RemoveAt(index - 1); // Index -1 da der Index bei 0 beginnt
                Console.WriteLine("Aufgabe gelöscht.");
            }
            else
            {
                Console.WriteLine("Ungültige Auswahl.");
            }
        }
    }
}
