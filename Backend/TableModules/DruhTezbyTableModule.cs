using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Backend.TableDataGateways.StorageContexts;
using Backend.Models;

namespace Backend.TableModules
{
    public class DruhTezbyTableModule
    {
        private IStorageContext db;

        public DruhTezbyTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<DruhTezby> LoadDruhyTezby()
        {
            return db.DruhTezbyTableGateway.SelectAll().Cast<DruhTezby>().ToList();
        }
    }
}
