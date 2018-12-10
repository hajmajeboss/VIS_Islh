using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableModules
{
    public class LesniHospodarskaEvidenceTableModule
    {
        IStorageContext db;

        public LesniHospodarskaEvidenceTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<LesniHospodarskaEvidence> LoadLhe(PorostniSkupina psk)
        {
            var res = db.LesniHospodarskaEvidenceTableGateway.SelectAll();
            var lhe = res.Cast<LesniHospodarskaEvidence>().ToList();
            List<LesniHospodarskaEvidence> filteredLhe = lhe.FindAll(x => x.IdPorostniSkupina.Equals(psk.Id)).ToList();
            return filteredLhe;
        }
    }
}
