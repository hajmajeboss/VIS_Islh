using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class DilecTableGateway : OracleTableDataGateway, IDilecTableGateway
    {
        private const string SELECT_ALL = "select id, id_odd, kod from Dilec";
        private const string SELECT_ONE = "select id, id_odd, kod from Dilec where id = :id";
        private const string SELECT_ODD = "select id, id_odd, kod from Dilec where id_odd = :id_odd";
        private const string INSERT = "insert into Dilec(id, id_odd, kod) values (:id, :id_odd, :kod)";
        private const string UPDATE = "update Dilec set id_odd = :id_odd, kod = :kod where id = :id";
        private const string DELETE = "delete from Dilec where id = :id";

        public override bool Delete(Model obj)
        {
            Dilec del = (Dilec)obj;
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
            Dilec ins = (Dilec)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_odd", ins.IdOddeleni);
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
            Dilec ins = (Dilec)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_odd", ins.IdOddeleni);
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
                            Dilec oddec = new Dilec
                            {
                                Id = reader.GetString(++i),
                                IdOddeleni = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(oddec);
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

        public List<Model> SelectByOddeleni(Model odd)
        {
            List<Model> result = new List<Model>();
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = SELECT_ODD;
                        cmd.Parameters.Add(":id_odd", odd.Id);
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int i = -1;
                            Dilec oddec = new Dilec
                            {
                                Id = reader.GetString(++i),
                                IdOddeleni = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(oddec);
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
