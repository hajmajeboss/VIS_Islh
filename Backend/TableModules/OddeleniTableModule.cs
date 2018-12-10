using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Backend.TableModules
{
    public class OddeleniTableModule
    {
        IStorageContext db;

        public OddeleniTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<Oddeleni> LoadOddeleni(LesniHospodarskyCelek lhc)
        {
            return db.OddeleniTableGateway.SelectByLhc(lhc).Cast<Oddeleni>().ToList();
        }
    }
}
