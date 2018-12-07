using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class PodvykonTableGateway : OracleTableDataGateway, IPodvykonTableGateway
    {
        private const string SELECT_ALL = "select id, id_vykon, kod, popis, poznamka from Podvykon";
        private const string SELECT_ONE = "select id, id_vykon, kod, popis, poznamka from Podvykon where id = :id";
        private const string INSERT = "insert into Podvykon(id, id_vykon, kod, popis, poznamka) values (:id, :id_vykon, :kod, :popis, :poznamka)";
        private const string UPDATE = "update Podvykon set id_vykon = :id_vykon, kod = :kod, popis = :popis, poznamka = :poznamka where id = :id";
        private const string DELETE = "delete from Podvykon where id = :id";

        public override bool Delete(Model obj)
        {
            Podvykon del = (Podvykon)obj;
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
            Podvykon ins = (Podvykon)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add("id_vykon", ins.IdVykon);
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
            Podvykon ins = (Podvykon)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add("id_vykon", ins.IdVykon);
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
                            Podvykon podvykon = new Podvykon
                            {
                                Id = reader.GetString(++i),
                                IdVykon = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                                Popis = !reader.IsDBNull(++i) ? reader.GetString(i) : null,
                                Poznamka = !reader.IsDBNull(++i) ? reader.GetString(i) : null
                            };
                            result.Add(podvykon);
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
