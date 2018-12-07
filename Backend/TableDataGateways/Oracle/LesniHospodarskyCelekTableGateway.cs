using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class LesniHospodarskyCelekTableGateway : OracleTableDataGateway, ILesniHospodarskyCelekTableGateway
    {
        private const string SELECT_ALL = "select id, kod from LesniHospodarskyCelek";
        private const string SELECT_ONE = "select id, kod from LesniHospodarskyCelek where id = :id";
        private const string INSERT = "insert into LesniHospodarskyCelek(id, kod) values (:id, :kod)";
        private const string UPDATE = "update LesniHospodarskyCelek set kod = :kod where id = :id";
        private const string DELETE = "delete from LesniHospodarskyCelek where id = :id";

        public override bool Delete(Model obj)
        {
            LesniHospodarskyCelek del = (LesniHospodarskyCelek)obj;
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
            LesniHospodarskyCelek ins = (LesniHospodarskyCelek)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
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
            LesniHospodarskyCelek ins = (LesniHospodarskyCelek)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
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
                            LesniHospodarskyCelek lesniHospodarskyCelek = new LesniHospodarskyCelek
                            {
                                Id = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                            };
                            result.Add(lesniHospodarskyCelek);
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
