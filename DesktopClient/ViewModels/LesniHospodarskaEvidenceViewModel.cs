using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.ViewModels
{
    public class LesniHospodarskaEvidenceViewModel
    {
        private IStorageContext db;

        public LesniHospodarskaEvidenceViewModel(IStorageContext db)
        {
            this.db = db;
        }
    }
}
