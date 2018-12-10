using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Backend.TableDataGateways.StorageContexts;
using Backend.Models;

namespace Backend.TableModules
{
    public class PorostTableModule
    {
        IStorageContext db;

        public PorostTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<Porost> LoadPorosty(Dilec dil)
        {
            return db.PorostTableGateway.SelectByDilec(dil).Cast<Porost>().ToList();
        }
    }
}
