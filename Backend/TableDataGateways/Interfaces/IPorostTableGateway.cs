using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Interfaces
{
    public interface IPorostTableGateway : ITableDataGateway
    {
        List<Model> SelectByDilec(Model dil);
    }
}
