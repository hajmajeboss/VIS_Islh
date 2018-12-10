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

        public List<string> GetHolinyByYearArrays()
        {
            var holiny = LoadHoliny().OrderBy(x => x.RokVzniku).ToList();
            List<int> years = holiny.Select(x => x.RokVzniku).Distinct().ToList();
            List<int> counts = new List<int>();
            foreach (var year in years)
            {
                counts.Add(holiny.FindAll(x => x.RokVzniku == year).ToList().Count);
            }

            List<string> ret = new List<string>();
            StringBuilder y = new StringBuilder();
            y.Append("[");
            var idx = 0;
            foreach(var year in years)
            {
                y.Append(year.ToString());
                if (idx < years.Count)
                {
                    y.Append(",");
                }
                idx++;
            }
            y.Append("]");

            StringBuilder c = new StringBuilder();
            c.Append("[");
            idx = 0;
            foreach (var count in counts)
            {
                c.Append(count.ToString());
                if (idx < years.Count)
                {
                    c.Append(",");
                }
                idx++;
            }
            c.Append("]");

            ret.Add(y.ToString());
            ret.Add(c.ToString());
            return ret;

        }
    }
}
