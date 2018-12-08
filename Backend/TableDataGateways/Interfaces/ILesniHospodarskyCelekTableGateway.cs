using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Interfaces
{
    public interface ILesniHospodarskyCelekTableGateway : ITableDataGateway
    {
        List<Model> SelectByUser(Uzivatel uzivatel);
    }
}
