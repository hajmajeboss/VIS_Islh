using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Backend.Filters;

namespace Backend.TableModules
{
    public class LesniHospodarskaEvidenceTableModule
    {
        IStorageContext db;
        public LheFilterConfig FilterConfig { get; set; }

        public LesniHospodarskaEvidenceTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<LesniHospodarskaEvidence> LoadLhe(PorostniSkupina psk)
        {
            var res = db.LesniHospodarskaEvidenceTableGateway.SelectAll();
            var lhe = res.Cast<LesniHospodarskaEvidence>().ToList();
            List<LesniHospodarskaEvidence> filteredLhe = lhe.FindAll(x => x.IdPorostniSkupina.Equals(psk.Id)).ToList();

            if (FilterConfig != null)
            {
                if (FilterConfig.Drevina != null)
                {
                    filteredLhe = filteredLhe.FindAll(x => x.IdDrevina.Equals(FilterConfig.Drevina.Id)).ToList();
                }
                if (FilterConfig.DruhTezby != null)
                {
                    filteredLhe = filteredLhe.FindAll(x => x.IdDruhTezby.Equals(FilterConfig.DruhTezby.Id)).ToList();
                }
                if (FilterConfig.Vykon != null)
                {
                    filteredLhe = filteredLhe.FindAll(x => x.GetPodvykon(db.PodvykonTableGateway).GetVykon(db.VykonTableGateway).Id.Equals(FilterConfig.Vykon.Id)).ToList();
                }
                if (FilterConfig.Podvykon != null)
                {
                    filteredLhe = filteredLhe.FindAll(x => x.IdPodvykon.Equals(FilterConfig.Podvykon.Id)).ToList();
                }
            }

            foreach (var item in filteredLhe)
            {
                item.GetPodvykon(db.PodvykonTableGateway);
                item.GetDrevina(db.DrevinaTableGateway);
                item.GetDruhTezby(db.DruhTezbyTableGateway);
                item.GetVykon(db.VykonTableGateway);
            }

            return filteredLhe;
        }


        public void AddLhe(LesniHospodarskaEvidence lhe)
        {
            db.LesniHospodarskaEvidenceTableGateway.Insert(lhe);
        }

        public void RemoveLhe(LesniHospodarskaEvidence lhe)
        {
            db.LesniHospodarskaEvidenceTableGateway.Delete(lhe);
        }

        public void UpdateLhe(LesniHospodarskaEvidence lhe)
        {
            db.LesniHospodarskaEvidenceTableGateway.Update(lhe);
        }
    }
}
