using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Backend.TableDataGateways.StorageContexts;
using Backend.Models;

namespace Backend.TableModules
{
    public class PorostniSkupinaTableModule
    {
        IStorageContext db;
        
        public PorostniSkupinaTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<PorostniSkupina> LoadPorostniSkupiny(Porost por)
        {
            return db.PorostniSkupinaTableGateway.SelectByPorost(por).Cast<PorostniSkupina>().ToList();
        }
    }
}
