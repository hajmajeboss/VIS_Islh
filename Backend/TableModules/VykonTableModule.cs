using Backend.Models;
using Backend.TableDataGateways;
using Backend.TableDataGateways.Interfaces;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableModules
{
    public class VykonTableModule
    {
        private IStorageContext db;

        public VykonTableModule(IStorageContext db)
        {
            this.db = db;
        }
        
        public List<Vykon> LoadVykony()
        {
            return db.VykonTableGateway.SelectAll().Cast<Vykon>().ToList();
        }
    }
}
