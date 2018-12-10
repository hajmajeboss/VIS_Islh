using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class PorostniSkupinaTableGateway : OracleTableDataGateway, IPorostniSkupinaTableGateway
    {
        private const string SELECT_ALL = "select id, id_por, kod from PorostniSkupina";
        private const string SELECT_ONE = "select id, id_por, kod from PorostniSkupina where id = :id";
        private const string SELECT_POR = "select id, id_por, kod from PorostniSkupina where id_por = :id_por";
        private const string INSERT = "insert into PorostniSkupina(id, id_por, kod) values (:id, :id_por, :kod)";
        private const string UPDATE = "update PorostniSkupina set id_por = :id_por, kod = :kod where id = :id";
        private const string DELETE = "delete from PorostniSkupina where id = :id";

        public override bool Delete(Model obj)
        {
            PorostniSkupina del = (PorostniSkupina)obj;
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
            PorostniSkupina ins = (PorostniSkupina)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_por", ins.IdPorost);
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
            PorostniSkupina ins = (PorostniSkupina)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_por", ins.IdPorost);
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
                            PorostniSkupina porec = new PorostniSkupina
                            {
                                Id = reader.GetString(++i),
                                IdPorost = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(porec);
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

        public List<Model> SelectByPorost(Model por)
        {
            List<Model> result = new List<Model>();
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = SELECT_POR;
                        cmd.Parameters.Add(":id_por", por.Id);
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int i = -1;
                            PorostniSkupina porec = new PorostniSkupina
                            {
                                Id = reader.GetString(++i),
                                IdPorost = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(porec);
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
    }
}
