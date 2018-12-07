using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class OddeleniTableGateway : OracleTableDataGateway, IOddeleniTableGateway
    {
        private const string SELECT_ALL = "select id, id_lhc, kod from Oddeleni";
        private const string SELECT_ONE = "select id, id_lhc, kod from Oddeleni where id = :id";
        private const string INSERT = "insert into Oddeleni(id, id_lhc, kod) values (:id, :id_lhc, :kod)";
        private const string UPDATE = "update Oddeleni set id_lhc = :id_lhc, kod = :kod where id = :id";
        private const string DELETE = "delete from Oddeleni where id = :id";

        public override bool Delete(Model obj)
        {
            Oddeleni del = (Oddeleni)obj;
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
            Oddeleni ins = (Oddeleni)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_lhc", ins.IdLesniHospodarskyCelek);
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
            Oddeleni ins = (Oddeleni)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_lhc", ins.IdLesniHospodarskyCelek);
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
                            Oddeleni oddeleni = new Oddeleni
                            {
                                Id = reader.GetString(++i),
                                IdLesniHospodarskyCelek = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(oddeleni);
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
