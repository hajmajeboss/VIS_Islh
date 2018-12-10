using Backend.TableDataGateways.StorageContexts;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;

namespace Backend.TableModules
{
    public class PodvykonTableModule
    {
        private IStorageContext db;

        public PodvykonTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<Podvykon> LoadPodvykony(Vykon vykon)
        {
            return db.PodvykonTableGateway.SelectByVykon(vykon).Cast<Podvykon>().ToList();
        }

    }
}
