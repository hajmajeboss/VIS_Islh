using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Podvykon : Model
    {
        public string Popis { get; set; }
        public string Kod { get; set; }
        public string Poznamka { get; set; }
        public string IdVykon { get; set; }

        private Vykon _vykon;
        public Vykon Vykon { set { _vykon = value; IdVykon = value.Id; } }

        public Vykon GetVykon(IVykonTableGateway gw)
        {
            Vykon vykon = (Vykon)gw.SelectOne(IdVykon);
            return vykon;
        }

        public override string ToString()
        {
            return Kod + " - " + Popis;
        }

    }
}
