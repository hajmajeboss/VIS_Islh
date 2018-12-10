using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Interfaces
{
    public interface IPorostniSkupinaTableGateway : ITableDataGateway
    {
        List<Model> SelectByPorost(Model por);
    }
}
