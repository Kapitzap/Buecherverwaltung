using Buecherverwaltung;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Buecherverwaltung.Models
{
    public class BuchDTO
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Autor { get; set; }
        public BuchTabelle Tabelle { get; set; }
    }

}
