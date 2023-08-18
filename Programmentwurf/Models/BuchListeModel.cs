using FahrzeugDatenbank;
using Fahrzeuge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FahrzeugeMVC2.Models
{
    public class FahrzeugListeModel
    {
        public FahrzeugListeModel(IEnumerable<FahrzeugDTO> fahrzeuge)
        {
            foreach (var fahrzeugDTO in fahrzeuge)
            {
                switch (fahrzeugDTO.Typ)
                {
                    case "Auto":
                        var auto = new Auto()
                        { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                        this.Fahrzeuge.Add(auto);
                        break;
                    case "Motorrad":
                        var motorrad = new Motorrad()
                        { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                        this.Fahrzeuge.Add(motorrad);
                        break;
                    case "Fahrrad":
                        var fahrrad = new Fahrrad()
                        { Id = fahrzeugDTO.Id, Name = fahrzeugDTO.Name };
                        this.Fahrzeuge.Add(fahrrad);
                        break;

                }
            }

        }

        public List<Fahrzeug> Fahrzeuge { get; set; } = new();
    }
}
