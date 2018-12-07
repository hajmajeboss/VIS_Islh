using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
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
        public PorostniSkupina PorostniSkupina { set { _psk = value; IdPorostniSkupina = value.Id; } }
        public PorostniSkupina GetPorostniSkupina(IPorostniSkupinaTableGateway gw)
        {
            PorostniSkupina psk = (PorostniSkupina)gw.SelectOne(IdPorostniSkupina);
            return psk;
        }

        private Drevina _drevina;
        public Drevina Drevina { set { _drevina = value; IdDrevina = value.Id; } }
        public Drevina GetDrevina(IDrevinaTableGateway gw)
        {
            Drevina drevina = (Drevina)gw.SelectOne(IdDrevina);
            return drevina;
        }
    }
}
