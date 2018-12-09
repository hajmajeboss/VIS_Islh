using Backend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways
{
    public interface ITableDataGateway
    {
        bool Insert(Model obj);
        bool Update(Model obj);
        bool Delete(Model obj);
        List<Model> SelectAll();
        Model SelectOne(string id);
    }
}
