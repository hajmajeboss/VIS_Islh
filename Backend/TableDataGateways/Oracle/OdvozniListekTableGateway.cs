using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class OdvozniListekTableGateway : OracleTableDataGateway, IOdvozniListekTableGateway
    {
        private const string SELECT_ALL =
            "select id, id_org3, id_sort, id_podvykon, id_lokalita, id_psk, datum_odvozu, mnozstvi, spz, odberatel, ujete_km" +
            " from OdvozniListek";
        private const string SELECT_ONE =
            "select id, id_org3, id_sort, id_podvykon, id_lokalita, id_psk, datum_odvozu, mnozstvi, spz, odberatel, ujete_km" +
            " from OdvozniListek" +
            " where id = :id";
        private const string INSERT =
            "insert into OdvozniListek(id, id_org3, id_sort, id_podvykon, id_lokalita, id_psk, datum_odvozu, mnozstvi, spz, odberatel, ujete_km)" +
            " values (:id, :id_org3, :id_sort, :id_podvykon, :id_lokalita, :id_psk, :datum_odvozu, :mnozstvi, :spz, :odberatel, :ujete_km)";
        private const string UPDATE =
            "update OdvozniListek" +
            " set id_org = :id_org3," +
            " id_sort = :id_sort," +
            " id_podvykon = :id_podvykon," +
            " id_lokalita = :id_lokalita," +
            " id_psk = :id_psk," +
            " datum_odvozu = :datum_odvozu," +
            " mnozstvi = :mnozstvi," +
            " spz = :spz," +
            " odberatel = :odberatel," +
            " ujete_km = :ujete_km" +
            " where id = :id";
        private const string DELETE = "delete from OdvozniListek where id = :id";

        public override bool Delete(Model obj)
        {
            OdvozniListek del = (OdvozniListek)obj;
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
            OdvozniListek ins = (OdvozniListek)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_org3", ins.IdOrganizacniUroven3);
                        cmd.Parameters.Add(":id_sort", ins.IdSortiment);
                        cmd.Parameters.Add(":id_podvykon", ins.IdPodvykon);
                        cmd.Parameters.Add(":id_lokalita", ins.IdLokalita);
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":datum_odvozu", ins.DatumOdvozu);
                        cmd.Parameters.Add(":mnozstvi", ins.Mnozstvi);
                        cmd.Parameters.Add(":spz", ins.Spz);
                        cmd.Parameters.Add(":odberatel", ins.Odberatel);
                        cmd.Parameters.Add(":ujete_km", ins.UjeteKm);
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
            OdvozniListek ins = (OdvozniListek)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_org3", ins.IdOrganizacniUroven3);
                        cmd.Parameters.Add(":id_sort", ins.IdSortiment);
                        cmd.Parameters.Add(":id_podvykon", ins.IdPodvykon);
                        cmd.Parameters.Add(":id_lokalita", ins.IdLokalita);
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":datum_odvozu", ins.DatumOdvozu);
                        cmd.Parameters.Add(":mnozstvi", ins.Mnozstvi);
                        cmd.Parameters.Add(":spz", ins.Spz);
                        cmd.Parameters.Add(":odberatel", ins.Odberatel);
                        cmd.Parameters.Add(":ujete_km", ins.UjeteKm);
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
                            OdvozniListek odvozniListek = new OdvozniListek
                            {
                                Id = reader.GetString(++i),
                                IdOrganizacniUroven3 = reader.GetString(++i),
                                IdSortiment = reader.GetString(++i),
                                IdPodvykon = reader.GetString(++i),
                                IdLokalita = reader.GetString(++i),
                                IdPorostniSkupina = reader.GetString(++i),
                                DatumOdvozu = reader.GetDateTime(++i),
                                Mnozstvi = reader.GetDouble(++i),
                                Spz = !reader.IsDBNull(++i) ?  reader.GetString(i) : null,
                                Odberatel = !reader.IsDBNull(++i) ? reader.GetString(i) : null,
                                UjeteKm = !reader.IsDBNull(++i) ?  reader.GetInt32(i) : -1
                            };
                            result.Add(odvozniListek);
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
