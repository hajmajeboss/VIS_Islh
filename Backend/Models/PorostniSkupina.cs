using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class PorostniSkupina : Model
    {
        public string Kod { get; set; }
        public string IdPorost { get; set; }

        private Porost _por;
        public Porost Porost { set { _por = value; IdPorost = value.Id; } }

        public Porost GetPorost(ITableDataGateway gw)
        {
            Porost por = (Porost)gw.SelectOne(IdPorost);
            return por;
        }
    }
}
