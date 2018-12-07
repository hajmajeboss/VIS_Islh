using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class PorostTableGateway : OracleTableDataGateway
    {
        private const string SELECT_ALL = "select id, id_dil, kod from Porost";
        private const string SELECT_ONE = "select id, id_dil, kod from Porost where id = :id";
        private const string INSERT = "insert into Porost(id, id_dil, kod) values (:id, :id_dil, :kod)";
        private const string UPDATE = "update Porost set id_dil = :id_dil, kod = :kod where id = :id";
        private const string DELETE = "delete from Porost where id = :id";

        public override bool Delete(Model obj)
        {
            Porost del = (Porost)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = DELETE;
                        cmd.Parameters.Add(":id", del.Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }

                    catch (OracleException oe)
                    {
                        Log(oe.Message);
                        return false;
                    }
                }
            }

        }

        public override bool Insert(Model obj)
        {
            Porost ins = (Porost)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_dil", ins.IdDilec);
                        cmd.Parameters.Add(":kod", ins.Kod);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (OracleException oe)
                    {
                        Log(oe.Message);
                        return false;
                    }
                }

            }
        }

        public override bool Update(Model obj)
        {
            Porost ins = (Porost)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_dil", ins.IdDilec);
                        cmd.Parameters.Add(":kod", ins.Kod);
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (OracleException oe)
                    {
                        Log(oe.Message);
                        return false;
                    }
                }
            }
        }

        public override List<Model> SelectAll()
        {
            List<Model> result = new List<Model>();
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = SELECT_ALL;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int i = -1;
                            Porost dilec = new Porost
                            {
                                Id = reader.GetString(++i),
                                IdDilec = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(dilec);
                        }
                        return result;
                    }
                    catch (OracleException oe)
                    {
                        Log(oe.Message);
                        return null;
                    }
                }
            }
        }

        public override Model SelectOne(string id)
        {
            List<Model> result = SelectAll();
            return result.FindLast(x => x.Id.Equals(id));
        }

    }
}
