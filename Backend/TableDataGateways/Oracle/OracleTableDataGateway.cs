using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Backend.Models;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public abstract class OracleTableDataGateway : ITableDataGateway
    {
        protected OracleConnectionFactory ConnetionFactory { get; set; }

        public abstract bool Delete(Model obj);
        public abstract bool Insert(Model obj);
        public abstract List<Model> SelectAll();
        public abstract Model SelectOne(string id);
        public abstract bool Update(Model obj);    

        protected OracleTableDataGateway()
        {
            ConnetionFactory = new OracleConnectionFactory();
        }

        protected void Log(string message)
        {
            using (StreamWriter wt = new StreamWriter("log.txt"))
            {
                wt.WriteLine(message);
            }
        }
    }
}
