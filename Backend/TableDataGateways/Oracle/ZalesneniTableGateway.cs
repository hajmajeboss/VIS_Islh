using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class ZalesneniTableGateway : OracleTableDataGateway, IZalesneniTableGateway
    {
        private const string SELECT_ALL =
            "select id, id_psk, id_drevina, plocha, souradnice, rok_vzniku, procent_pudy" +
            " from Zalesneni";
        private const string SELECT_ONE =
            "select id, id_psk, id_drevina, plocha, souradnice, rok_vzniku, procent_pudy" +
            " from Zalesneni" +
            " where id = :id";
        private const string INSERT =
            "insert into Zalesneni(id, id_psk, id_drevina, plocha, souradnice, rok_vzniku, procent_pudy)" +
            " values (:id, :id_psk, :id_drevina, :plocha, :souradnice, :rok_vzniku, :procent_pudy)";
        private const string UPDATE =
            "update Zalesneni" +
            " set id_psk = :id_psk," +
            " id_drevina = :id_drevina," +
            " plocha = :plocha," +
            " souradnice = :souradnice," +
            " rok_vzniku = :rok_vzniku," +
            " procent_pudy = :procent_pudy" +
            " where id = :id";
        private const string DELETE = "delete from Zalesneni where id = :id";

        public override bool Delete(Model obj)
        {
            Zalesneni del = (Zalesneni)obj;
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
            Zalesneni ins = (Zalesneni)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":id_drevina", ins.IdDrevina);
                        cmd.Parameters.Add(":plocha", ins.Plocha);
                        cmd.Parameters.Add(":souradnice", ins.Souradnice);
                        cmd.Parameters.Add(":rok_vzniku", ins.RokVzniku);
                        cmd.Parameters.Add(":procent_pudy", ins.ProcentPudy);
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
            Zalesneni ins = (Zalesneni)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":id_drevina", ins.IdDrevina);
                        cmd.Parameters.Add(":plocha", ins.Plocha);
                        cmd.Parameters.Add(":souradnice", ins.Souradnice);
                        cmd.Parameters.Add(":rok_vzniku", ins.RokVzniku);
                        cmd.Parameters.Add(":procent_pudy", ins.ProcentPudy);
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
                            Zalesneni zalesneni = new Zalesneni
                            {
                                Id = reader.GetString(++i),
                                IdPorostniSkupina = reader.GetString(++i),
                                IdDrevina = reader.GetString(++i),
                                Plocha = reader.GetDouble(++i),
                                Souradnice = reader.GetString(++i),
                                RokVzniku = reader.GetInt32(++i),
                                ProcentPudy = reader.GetDouble(++i)
                            };
                            result.Add(zalesneni);
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
