using BuchDB;
using Buecherverwaltung.Models;
using Buecherverwaltung.Utilis;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;


namespace Buecherverwaltung.Controllers
{
    public class BuchController : Controller
    {
        private readonly KonfigurationsLeser _konfigurationsLeser;

        // Konstruktor für den BuchController
        public BuchController(KonfigurationsLeser konfigurationsLeser)
        {
            this._konfigurationsLeser = konfigurationsLeser; // _konfigurationsLeser wird gesetzt um ConnectionString auszulesen
        }

        // Methode zur Abruf des Connection Strings
        public string GetConnectionString()
        {
            return _konfigurationsLeser.LiesDatenbankVerbindungZurMariaDB(); // Auslesen des ConnectionStrings
        }

        // Action Methode für die Index-Seite
        public IActionResult Index()
        {

            BuchModel model = LeseModelDaten(GetConnectionString()); // Daten werden in ein Model eingelesen

            return View(model); //View wird erstellt
        }

        // Methode zum Lesen der Daten und Erstellen des BuchModels
        public BuchModel LeseModelDaten(string connectionString)
        {
            // Erstellt zwei Listen, mit den Daten der angezeigten Tabellen
            List<BuchDTO> aktuelleBuecher = new();
            List<BuchDTO> archivierteBuecher = new();
            var repository = new BuecherRepository(connectionString); 

            // Verwendung von Threads zur parallelen Abfrage der Daten
            Thread aktuelleBuecherLesen = new Thread(() =>
            {
                aktuelleBuecher = repository.HoleAktuelleBuecher();
            });

            Thread archivierteBuecherLesen = new Thread(() =>
            {
                archivierteBuecher = repository.HoleArchivierteBuecher();
            });

            // Ausführen der obigen Threads
            aktuelleBuecherLesen.Start();
            archivierteBuecherLesen.Start();

            aktuelleBuecherLesen.Join();
            archivierteBuecherLesen.Join();

            return new BuchModel(aktuelleBuecher, archivierteBuecher);
        }

        // Methode zum Verschieben von Büchern zwischen Tabellen
        public void Verschieben(BuchDTO buch, string quelle, string ziel)
        {
            string connectionString = GetConnectionString();
            // Repository zum verschieben wird Initialisiert
            var repository = new BuecherRepository(connectionString);
            repository.VerschiebeBuch(buch, quelle, ziel); // Verschieben des Buches (Löschen aus der 1. Tabelle und Einfügen in die andere Tabelle) wird ausgeführt
        }

        // Action Methode zum Verschieben nach archivierten Büchern
        public IActionResult VerschiebeNachArchiviert(BuchDTO buch)
        {
            Verschieben(buch, "aktuelle_buecher", "archivierte_buecher"); // Start des verschiebens eines aktuellen Buches, zu einem archivierten Buch

            BuchModel model = LeseModelDaten(GetConnectionString()); // Neues Laden der beiden Tabellen, nach obiger Verschiebung

            return View("Views/Buch/Index.cshtml", model); // Erstellen der View
        }

        // Action Methode zum Verschieben nach aktuellen Büchern
        public IActionResult VerschiebeNachAktuell(BuchDTO buch)
        {
            Verschieben(buch, "archivierte_buecher", "aktuelle_buecher"); // Start des verschiebens eines archivierten Buches, zu einem aktuellen Buch

            BuchModel model = LeseModelDaten(GetConnectionString()); // Neues Laden der beiden Tabellen, nach obiger Verschiebung

            return View("Views/Buch/Index.cshtml", model); // Erstellen der View
        }



    }
}
