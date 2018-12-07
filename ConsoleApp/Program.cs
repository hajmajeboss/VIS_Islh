using Backend.TableDataGateways.Oracle;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OracleConnectionFactory factory = new OracleConnectionFactory();
            OracleConnection conn = factory.GetOracleConnection();
            Console.WriteLine(conn.State.ToString());
            Console.ReadKey();
        }
    }
}
