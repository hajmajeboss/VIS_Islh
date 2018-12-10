using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class LesniHospodarskaEvidence : Model
    {
        public DateTime Datum { get; set; }
        public string IdPorostniSkupina { get; set; }
        public string IdPodvykon { get; set; }
        public string IdDruhTezby { get; set; }
        public string IdDrevina { get; set; }
        public double Plocha { get; set; }
        public double Mnozstvi { get; set; }
        public string Poznamka { get; set; }

        private PorostniSkupina _psk;
        public PorostniSkupina PorostniSkupina { set { _psk = value; IdPorostniSkupina = value.Id; } }
        public PorostniSkupina GetPorostniSkupina(IPorostniSkupinaTableGateway gw)
        {
            PorostniSkupina psk = (PorostniSkupina)gw.SelectOne(IdPorostniSkupina);
            return psk;
        }

        private Podvykon _podvykon;
        public Podvykon Podvykon { get { return _podvykon; } set { _podvykon = value; IdPodvykon = value.Id; } }
        public Podvykon GetPodvykon(IPodvykonTableGateway gw)
        {
            _podvykon = (Podvykon)gw.SelectOne(IdPodvykon);
            return _podvykon;
        }

        private DruhTezby _druhTezby;
        public DruhTezby DruhTezby { get { return _druhTezby; } set { _druhTezby = value; IdDruhTezby = value.Id; } }
        public DruhTezby GetDruhTezby(IDruhTezbyTableGateway gw)
        {
            _druhTezby = (DruhTezby)gw.SelectOne(IdDruhTezby);
            return _druhTezby;
        }

        private Drevina _drevina;
        public Drevina Drevina { get { return _drevina; } set { _drevina = value; IdDrevina = value.Id; } }
        public Drevina GetDrevina(IDrevinaTableGateway gw)
        {
            _drevina = (Drevina)gw.SelectOne(IdDrevina);
            return _drevina;
        }

        //Only for table
        private Vykon _vykon;
        public Vykon Vykon { get { return _vykon; } }
        public Vykon GetVykon(IVykonTableGateway gw)
        {
            _vykon = (Vykon)gw.SelectOne(Podvykon.IdVykon);
            return _vykon;
        }
    }
}
