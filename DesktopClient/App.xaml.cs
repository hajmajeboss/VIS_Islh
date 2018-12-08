using Backend.TableDataGateways.Interfaces;
using Backend.TableDataGateways.Oracle;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DesktopClient
{
    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        public IUzivatelTableGateway UzivatelTableGateway { get; set; }

        public App()
        {
            UzivatelTableGateway = new UzivatelTableGateway();
        }

    }
}
