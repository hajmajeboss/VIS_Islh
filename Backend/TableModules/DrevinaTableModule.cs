using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Backend.TableDataGateways.StorageContexts;
using Backend.Models;

namespace Backend.TableModules
{
    public class DrevinaTableModule
    {
        private IStorageContext db;

        public DrevinaTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<Drevina> LoadDreviny()
        {
            return db.DrevinaTableGateway.SelectAll().Cast<Drevina>().ToList();
        }
     }
}
