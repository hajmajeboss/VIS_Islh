using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class HolinaTableGateway : OracleTableDataGateway, IHolinaTableGateway
    {
        private const string SELECT_ALL =
            "select id, id_psk, souradnice, rok_vzniku, poznamka, plocha" +
            " from Holina";
        private const string SELECT_ONE =
            "select id, id_psk, souradnice, rok_vzniku, poznamka, plocha" +
            " from Holina" +
            " where id = :id";
        private const string INSERT =
            "insert into Holina(id, id_psk, souradnice, rok_vzniku, poznamka, plocha)" +
            " values (:id, :id_psk, :souradnice, :rok_vzniku, :poznamka, :plocha)";
        private const string UPDATE =
            "update Holina" +
            " set id_psk = :id_psk," +
            " souradnice = :souradnice," +
            " rok_vzniku = :rok_vzniku," +
            " poznamka = :poznamka," +
            " plocha = :plocha," +
            " where id = :id";
        private const string DELETE = "delete from Holina where id = :id";

        public override bool Delete(Model obj)
        {
            Holina del = (Holina)obj;
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
            Holina ins = (Holina)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":souradnice", ins.Souradnice);
                        cmd.Parameters.Add(":rok_vzniku", ins.RokVzniku);
                        cmd.Parameters.Add(":poznamka", ins.Poznamka);
                        cmd.Parameters.Add(":plocha", ins.Plocha);
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
            Holina ins = (Holina)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":souradnice", ins.Souradnice);
                        cmd.Parameters.Add(":rok_vzniku", ins.RokVzniku);
                        cmd.Parameters.Add(":poznamka", ins.Poznamka);
                        cmd.Parameters.Add(":plocha", ins.Plocha);
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
                            Holina holina = new Holina
                            {
                                Id = reader.GetString(++i),
                                IdPorostniSkupina = reader.GetString(++i),
                                Souradnice = reader.GetString(++i),
                                RokVzniku = reader.GetInt32(++i),
                                Poznamka = reader.GetString(++i),
                                Plocha = reader.GetDouble(++i),
                            };
                            result.Add(holina);
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
