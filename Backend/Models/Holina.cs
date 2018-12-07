using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Holina : Model
    {
        public string IdPorostniSkupina { get; set; }
        public double Plocha { get; set; }
        public string Souradnice { get; set; }
        public int RokVzniku { get; set; }
        public string Poznamka { get; set; }

        private PorostniSkupina _psk;
        public PorostniSkupina PorostniSkupina { set { _psk = value; IdPorostniSkupina = value.Id; } }
        public PorostniSkupina GetPorostniSkupina(ITableDataGateway gw)
        {
            PorostniSkupina psk = (PorostniSkupina)gw.SelectOne(IdPorostniSkupina);
            return psk;
        }
    }
}
