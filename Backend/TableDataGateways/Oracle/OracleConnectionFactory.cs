using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.TableDataGateways.Oracle
{
    public class OracleConnectionFactory
    {
        private const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=dbsys.cs.vsb.cz)" +
            "(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=oracle.dbsys.cs.vsb.cz)));" +
            "User Id=hei0051;Password=B01MFYQNXT;Connection Timeout=45;";
        public OracleConnection GetOracleConnection()
        {
            OracleConnection connection = new OracleConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            return connection;
        }
    }
}
