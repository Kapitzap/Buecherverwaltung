using MySqlConnector;
using System.Collections.Generic;

namespace BuchDB
{
    public class BuecherRepository
    {
        public string connectionString;

        public BuecherRepository(string connectionString)
        {
            this.connectionString = connectionString; // Legt bei Erstellung den connectionString zur Datenbank fest
        }

        // Liest aktuellen Bücher ein
        public List<BuchDTO> HoleAktuelleBuecher()
        {
            return GetBooksFromTable("aktuelle_Buecher");
        }

        // Liest archiviertte Bücher ein
        public List<BuchDTO> HoleArchivierteBuecher()
        {
            return GetBooksFromTable("archivierte_Buecher");
        }

        // Liest Bücher aus einer bestimmten Tabelle ein
        public List<BuchDTO> GetBooksFromTable(string tabellenname)
        {
            List<BuchDTO> Buch = new();

            // Datenbankabfrage wird gestartet und die Abfrage zum Auslesen einer der beiden Tabellen wird ausgeführt
            using var db_Verbindung = new MySqlConnection(connectionString);
            db_Verbindung.Open();
            string queryBuecher = "SELECT titel, autor FROM " + tabellenname;
            using var commando = new MySqlCommand(queryBuecher, db_Verbindung);
            using var reader = commando.ExecuteReader();

            while (reader.Read())
            {
                BuchDTO buch = new BuchDTO
                {
                    Autor = (string?)reader["autor"],
                    Titel = (string?)reader["titel"]
                };

                Buch.Add(buch);
            }

            db_Verbindung.Close();

            return Buch;
        }

        // Verschiebt ein Buch zwischen Tabellen
        public void VerschiebeBuch(BuchDTO buch, string quelle, string ziel)
        {
            using var db_Verbindung = new MySqlConnection(connectionString);

            LoescheBuch(buch, quelle); // Lösche das Buch aus der Quelltabelle

            BuchEinfuegen(buch, ziel); // Füge das Buch der Zieltabelle hinzu
        }

        // Fügt ein Buch in eine Tabelle ein
        public void BuchEinfuegen(BuchDTO buch, string ziel)
        {
            // Datenbankverbindung aufbauen und Befehl zum Einfuegen in die Zieladresse wird ausgeführt
            using var db_Verbindung = new MySqlConnection(connectionString);
            db_Verbindung.Open();

            string queryBuchLoeschen = "INSERT INTO " + ziel + " (titel, autor) VALUES ('" + buch.Titel + "', '" + buch.Autor + "')";
            using var command = new MySqlCommand(queryBuchLoeschen, db_Verbindung);
            command.Parameters.AddWithValue("titel", buch.Titel);
            command.Parameters.AddWithValue("autor", buch.Autor);

            command.ExecuteNonQuery();

            db_Verbindung.Close();
        }

        // Löscht ein Buch aus einer Tabelle
        public void LoescheBuch(BuchDTO buch, string quelle)
        {
            // Datenbankverbindung aufbauen und Befehl zum Löschen aus der Quelladresse wird ausgeführt
            using var db_Verbindung = new MySqlConnection(connectionString);
            db_Verbindung.Open();

            string queryBuchLoeschen = "DELETE FROM " + quelle + " WHERE titel = @titel AND autor = @autor";
            using var command = new MySqlCommand(queryBuchLoeschen, db_Verbindung);
            command.Parameters.AddWithValue("titel", buch.Titel);
            command.Parameters.AddWithValue("autor", buch.Autor);

            command.ExecuteNonQuery();

            db_Verbindung.Close();
        }

       
    }

    public class BuchDTO
    {
        // Klasse die alle Daten eines Buches enthält
        public string? Titel { get; set; }
        public string? Autor { get; set; }
    }

}