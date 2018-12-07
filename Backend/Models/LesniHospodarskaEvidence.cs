using Backend.TableDataGateways;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class LesniHospodarskaEvidence : Model
    {
        public string IdPorostniSkupina { get; set; }
        public string IdPodvykon { get; set; }
        public string IdDruhTezby { get; set; }
        public string IdDrevina { get; set; }
        public double Plocha { get; set; }
        public double Mnozstvi { get; set; }

        private PorostniSkupina _psk;
        public PorostniSkupina PorostniSkupina { set { _psk = value; IdPorostniSkupina = value.Id; } }
        public PorostniSkupina GetPorostniSkupina(ITableDataGateway gw)
        {
            PorostniSkupina psk = (PorostniSkupina)gw.SelectOne(IdPorostniSkupina);
            return psk;
        }

        private Podvykon _podvykon;
        public Podvykon Podvykon { set { _podvykon = value; IdPodvykon = value.Id; } }
        public Podvykon GetPodvykon(ITableDataGateway gw)
        {
            Podvykon podvykon = (Podvykon)gw.SelectOne(IdPodvykon);
            return podvykon;
        }

        private DruhTezby _druhTezby;
        public DruhTezby DruhTezby { set { _druhTezby = value; IdDruhTezby = value.Id; } }
        public DruhTezby GetDruhTezby(ITableDataGateway gw)
        {
            DruhTezby druhTezby = (DruhTezby)gw.SelectOne(IdDruhTezby);
            return druhTezby;
        }

        private Drevina _drevina;
        public Drevina Drevina { set { _drevina = value; IdDrevina = value.Id; } }
        public Drevina GetDrevina(ITableDataGateway gw)
        {
            Drevina drevina = (Drevina)gw.SelectOne(IdDrevina);
            return drevina;
        }
    }
}
