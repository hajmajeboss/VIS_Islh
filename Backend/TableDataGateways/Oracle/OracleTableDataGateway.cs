using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public abstract class OracleTableDataGateway : ITableDataGateway
    {
        protected OracleConnection Connection { get; set; }

        public abstract bool Delete(Model obj);
        public abstract bool Insert(Model obj);
        public abstract List<Model> SelectAll();
        public abstract Model SelectOne(string id);
        public abstract bool Update(Model obj);    

        protected OracleTableDataGateway()
        {
        }

    }
}
