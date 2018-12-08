using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Interfaces
{
    public interface IUzivatelTableGateway : ITableDataGateway
    {
        Model SelectByName(string username);
    }
}
