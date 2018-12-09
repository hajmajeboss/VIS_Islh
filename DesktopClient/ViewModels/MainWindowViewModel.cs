using Backend.TableDataGateways.StorageContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.ViewModels
{
    public class MainWindowViewModel
    {
        private IStorageContext db;

        public MainWindowViewModel(IStorageContext db)
        {
            this.db = db;
        }
    }
}
