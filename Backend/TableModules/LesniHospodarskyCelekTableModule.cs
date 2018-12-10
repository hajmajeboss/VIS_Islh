using Backend.Models;
using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Backend.TableModules
{
    public class LesniHospodarskyCelekTableModule
    {
        private IStorageContext db;

        public LesniHospodarskyCelekTableModule(IStorageContext db)
        {
            this.db = db;
        }

        public List<LesniHospodarskyCelek> LoadLhc(Uzivatel uzivatel)
        {
            return db.LesniHospodarskyCelekTableGateway.SelectByUser(uzivatel).Cast<LesniHospodarskyCelek>().ToList();
        }
    }
}
