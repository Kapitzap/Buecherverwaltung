using BuchDB;
using System.Collections.Generic;

namespace Buecherverwaltung.Models
{
    public class BuchModel
    {
        // Liste für aktuelle Bücher
        public List<BuchDTO> AktuelleBuecherList { get; set; } = new();

        // Liste für archivierte Bilder
        public List<BuchDTO> ArchivierteBuecherList { get; set; } = new();

        // Konstruktor, der die Listen mit BuchDTO-Objekten befüllt
        public BuchModel(IEnumerable<BuchDTO> aktuelleBuecher, IEnumerable<BuchDTO> archivierteBuecher)
        {
            // Befüllen der Liste für aktuelle Bücher
            foreach (BuchDTO buchDTO in aktuelleBuecher)
            {
                AktuelleBuecherList.Add(buchDTO);
            }

            // Befüllen der Liste für archiviete Bücher
            foreach (BuchDTO buchDTO in archivierteBuecher)
            {
                ArchivierteBuecherList.Add(buchDTO);
            }
        }
    }
}
