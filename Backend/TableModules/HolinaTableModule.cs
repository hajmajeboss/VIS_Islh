using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Backend.TableModules
{
    public class HolinaTableModule
    {
        IStorageContext db;
        public HolinaTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<Holina> LoadHoliny()
        {
            return db.HolinaTableGateway.SelectAll().Cast<Holina>().ToList();
        }

        public List<Holina> LoadHolinyByRokVzniku(int rokVzniku)
        {
            return db.HolinaTableGateway.SelectAll().Cast<Holina>().ToList().FindAll(x => x.RokVzniku == rokVzniku).ToList();
        }
    }
}
