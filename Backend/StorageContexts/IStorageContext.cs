using Backend.TableDataGateways.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.StorageContexts
{
    public interface IStorageContext
    {
        IDilecTableGateway DilecTableGateway { get; set; }
        IDrevinaTableGateway DrevinaTableGateway { get; set; }
        IDruhTezbyTableGateway DruhTezbyTableGateway { get; set; }
        IHolinaTableGateway HolinaTableGateway { get; set; }
        ILesniHospodarskaEvidenceTableGateway LesniHospodarskaEvidenceTableGateway { get; set; }
        ILesniHospodarskyCelekTableGateway LesniHospodarskyCelekTableGateway { get; set; }
        ILokalitaTableGateway LokalitaTableGateway { get; set; }
        IOddeleniTableGateway OddeleniTableGateway { get; set; }
        IOdvozniListekTableGateway OdvozniListekTableGateway { get; set; }
        IOrganizacniUroven1TableGateway OrganizacniUroven1TableGateway { get; set; }
        IOrganizacniUroven2TableGateway OrganizacniUroven2TableGateway { get; set; }
        IOrganizacniUroven3TableGateway OrganizacniUroven3TableGateway { get; set; }
        IPodvykonTableGateway PodvykonTableGateway { get; set; }
        IPorostniSkupinaTableGateway PorostniSkupinaTableGateway { get; set; }
        IPorostTableGateway PorostTableGateway { get; set; }
        ISortimentTableGateway SortimentTableGateway { get; set; }
        IUzivatelTableGateway UzivatelTableGateway { get; set; }
        IVykonTableGateway VykonTableGateway { get; set; }
        IZalesneniTableGateway ZalesneniTableGateway { get; set; }
    }
}
