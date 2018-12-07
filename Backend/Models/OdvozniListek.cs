using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Models
{
    public class OdvozniListek : Model
    {
        public string IdOrganizacniUroven3 { get; set; }
        public string IdSortiment { get; set; }
        public string IdPodvykon { get; set; }
        public string IdLokalita { get; set; }
        public string IdPorostniSkupina { get; set; }
        public DateTime DatumOdvozu { get; set; }
        public double Mnozstvi { get; set; }
        public string Spz { get; set; }
        public string Odberatel { get; set; }
        public int UjeteKm { get; set; }

        private OrganizacniUroven3 _orgUr3;
        public OrganizacniUroven3 OrganizacniUroven3 { set { _orgUr3 = value; IdOrganizacniUroven3 = value.Id; } }
        public OrganizacniUroven3 GetOrganizacniUroven3(IOrganizacniUroven3TableGateway gw)
        {
            OrganizacniUroven3 orgUr3 = (OrganizacniUroven3)gw.SelectOne(IdOrganizacniUroven3);
            return orgUr3;
        }

        private Sortiment _sortiment;
        public Sortiment Sortiment { set { _sortiment = value; IdSortiment = value.Id; } }
        public Sortiment GetSortiment(ISortimentTableGateway gw)
        {
            Sortiment sortiment = (Sortiment)gw.SelectOne(IdSortiment);
            return sortiment;
        }

        private Lokalita _lokalita;
        public Lokalita Lokalita { set { _lokalita = value; IdLokalita = value.Id; } }
        public Lokalita GetLokalita(ILokalitaTableGateway gw)
        {
            Lokalita lokalita = (Lokalita)gw.SelectOne(IdLokalita);
            return lokalita;
        }

        private PorostniSkupina _psk;
        public PorostniSkupina PorostniSkupina { set { _psk = value; IdPorostniSkupina = value.Id; } }
        public PorostniSkupina GetPorostniSkupina(IPorostniSkupinaTableGateway gw)
        {
            PorostniSkupina psk = (PorostniSkupina)gw.SelectOne(IdPorostniSkupina);
            return psk;
        }

        private Podvykon _podvykon;
        public Podvykon Podvykon { set { _podvykon = value; IdPodvykon = value.Id; } }
        public Podvykon GetPodvykon(IPodvykonTableGateway gw)
        {
            Podvykon podvykon = (Podvykon)gw.SelectOne(IdPodvykon);
            return podvykon;
        }
    }
}
