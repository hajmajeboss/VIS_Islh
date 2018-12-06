using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;

namespace Backend.TableDataGateways.Xml
{
    public abstract class XmlTableDataGateway : ITableDataGateway
    {
        public abstract bool Delete(Model obj);
        public abstract bool Insert(Model obj);
        public abstract bool SelectAll();
        public abstract bool SelectOne(string id);
        public abstract bool Update(Model obj);
    }
}
