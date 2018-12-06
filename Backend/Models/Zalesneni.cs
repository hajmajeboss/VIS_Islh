using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class Zalesneni : Model
    {
        public string IdPorostniSkupina { get; set; }
        public string IdDrevina { get; set; }
        public double Plocha { get; set; }
        public string Souradnice { get; set; }
        public int RokVzniku { get; set; }
        public double ProcentPudy { get; set; }

        private PorostniSkupina _psk;
        public PorostniSkupina PorostniSkupina { set { _psk = value; IdPorostniSkupina = value.Id } }
        public PorostniSkupina GetPorostniSkupina(ITableDataGateway gw)
        {
            PorostniSkupina psk = (PorostniSkupina)gw.SelectOne(IdPorostniSkupina);
            return psk;
        }

        private Drevina _drevina;
        public Drevina Drevina { set { _drevina = value; IdDrevina = value.Id } }
        public Drevina GetDrevina(ITableDataGateway gw)
        {
            Drevina drevina = (Drevina)gw.SelectOne(IdDrevina);
            return drevina;
        }
    }
}
