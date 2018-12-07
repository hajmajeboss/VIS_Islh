using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class DrevinaTableGateway : OracleTableDataGateway
    {
        private const string SELECT_ALL = "select id, kod, popis, poznamka, hustota from Drevina";
        private const string SELECT_ONE = "select id, kod, popis, poznamka, hustota from Drevina where id = :id";
        private const string INSERT = "insert into Drevina(id, kod, popis, poznamka, hustota) values (:id, :kod, :popis, :poznamka, :hustota)";
        private const string UPDATE = "update Drevina set kod = :kod, popis = :popis, poznamka = :poznamka, hustota = :hustota where id = :id";
        private const string DELETE = "delete from Drevina where id = :id";

        public override bool Delete(Model obj)
        {
            Drevina del = (Drevina)obj;
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
            Drevina ins = (Drevina)obj;
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
                        cmd.Parameters.Add(":hustota", ins.Hustota);
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
            Drevina ins = (Drevina)obj;
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
                        cmd.Parameters.Add(":hustota", ins.Hustota);
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
                            Drevina drevina = new Drevina
                            {
                                Id = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                                Popis = !reader.IsDBNull(++i) ? reader.GetString(i) : null,
                                Poznamka = !reader.IsDBNull(++i) ? reader.GetString(i) : null,
                                Hustota = !reader.IsDBNull(++i) ? reader.GetDouble(i) : 0.0
                            };
                            result.Add(drevina);
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
