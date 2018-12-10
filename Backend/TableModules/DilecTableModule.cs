using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableModules
{
    public class DilecTableModule
    {
        IStorageContext db;

        public DilecTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<Dilec> LoadDilce(Oddeleni odd)
        {
            return db.DilecTableGateway.SelectByOddeleni(odd).Cast<Dilec>().ToList();
        }


    }
}
