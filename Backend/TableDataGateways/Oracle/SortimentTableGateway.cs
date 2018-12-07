using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class SortimentTableGateway : OracleTableDataGateway
    {
        private const string SELECT_ALL = "select id, kod, popis, poznamka from Sortiment";
        private const string SELECT_ONE = "select id, kod, popis, poznamka from Sortiment where id = :id";
        private const string INSERT = "insert into Sortiment(id, kod, popis, poznamka) values (:id, :kod, :popis, :poznamka)";
        private const string UPDATE = "update Sortiment set kod = :kod, popis = :popis, poznamka = :poznamka where id = :id";
        private const string DELETE = "delete from Sortiment where id = :id";

        public override bool Delete(Model obj)
        {
            Sortiment del = (Sortiment)obj;
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
            Sortiment ins = (Sortiment)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":kod", ins.Kod);
                        cmd.Parameters.Add(":popis", ins.Popis);
                        cmd.Parameters.Add(":poznamka", ins.Poznamka);
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
            Sortiment ins = (Sortiment)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":kod", ins.Kod);
                        cmd.Parameters.Add(":popis", ins.Popis);
                        cmd.Parameters.Add(":poznamka", ins.Poznamka);
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
                            Sortiment sortiment = new Sortiment
                            {
                                Id = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                                Popis = !reader.IsDBNull(++i) ? reader.GetString(i) : null,
                                Poznamka = !reader.IsDBNull(++i) ? reader.GetString(i) : null
                            };
                            result.Add(sortiment);
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
