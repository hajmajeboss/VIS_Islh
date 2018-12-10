using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Interfaces
{
    public interface IDilecTableGateway : ITableDataGateway
    {
        List<Model> SelectByOddeleni(Model odd);
    }
}
