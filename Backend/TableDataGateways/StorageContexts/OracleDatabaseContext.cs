using Backend.TableDataGateways.Interfaces;
using Backend.TableDataGateways.Oracle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.StorageContexts
{
    public class OracleDatabaseContext : IStorageContext
    {
        public IDilecTableGateway DilecTableGateway { get; set; }
        public IDrevinaTableGateway DrevinaTableGateway { get; set; }
        public IDruhTezbyTableGateway DruhTezbyTableGateway { get; set; }
        public IHolinaTableGateway HolinaTableGateway { get; set; }
        public ILesniHospodarskaEvidenceTableGateway LesniHospodarskaEvidenceTableGateway { get; set; }
        public ILesniHospodarskyCelekTableGateway LesniHospodarskyCelekTableGateway { get; set; }
        public ILokalitaTableGateway LokalitaTableGateway { get; set; }
        public IOddeleniTableGateway OddeleniTableGateway { get; set; }
        public IOdvozniListekTableGateway OdvozniListekTableGateway { get; set; }
        public IOrganizacniUroven1TableGateway OrganizacniUroven1TableGateway { get; set; }
        public IOrganizacniUroven2TableGateway OrganizacniUroven2TableGateway { get; set; }
        public IOrganizacniUroven3TableGateway OrganizacniUroven3TableGateway { get; set; }
        public IPodvykonTableGateway PodvykonTableGateway { get; set; }
        public IPorostniSkupinaTableGateway PorostniSkupinaTableGateway { get; set; }
        public IPorostTableGateway PorostTableGateway { get; set; }
        public ISortimentTableGateway SortimentTableGateway { get; set; }
        public IUzivatelTableGateway UzivatelTableGateway { get; set; }
        public IVykonTableGateway VykonTableGateway { get; set; }
        public IZalesneniTableGateway ZalesneniTableGateway { get; set; }

        public OracleDatabaseContext()
        {
            DilecTableGateway = new DilecTableGateway();
            DrevinaTableGateway = new DrevinaTableGateway();
            DruhTezbyTableGateway = new DruhTezbyTableGateway();
            HolinaTableGateway = new HolinaTableGateway();
            LesniHospodarskaEvidenceTableGateway = new LesniHospodarskaEvidenceTableGateway();
            LesniHospodarskyCelekTableGateway = new LesniHospodarskyCelekTableGateway();
            LokalitaTableGateway = new LokalitaTableGateway();
            OddeleniTableGateway = new OddeleniTableGateway();
            OdvozniListekTableGateway = new OdvozniListekTableGateway();
            OrganizacniUroven1TableGateway = new OrganizacniUroven1TableGateway();
            OrganizacniUroven2TableGateway = new OrganizacniUroven2TableGateway();
            OrganizacniUroven3TableGateway = new OrganizacniUroven3TableGateway();
            PodvykonTableGateway = new PodvykonTableGateway();
            PorostniSkupinaTableGateway = new PorostniSkupinaTableGateway();
            PorostTableGateway = new PorostTableGateway();
            SortimentTableGateway = new SortimentTableGateway();
            UzivatelTableGateway = new UzivatelTableGateway();
            VykonTableGateway = new VykonTableGateway();
            ZalesneniTableGateway = new ZalesneniTableGateway();
        }
        
    }
}
