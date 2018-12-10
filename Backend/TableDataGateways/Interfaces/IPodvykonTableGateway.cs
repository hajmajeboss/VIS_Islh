using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Interfaces
{
    public interface IPodvykonTableGateway : ITableDataGateway
    {
        List<Model> SelectByVykon(Model vykon);
    }
}
