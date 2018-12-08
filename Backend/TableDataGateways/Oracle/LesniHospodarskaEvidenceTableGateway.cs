using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class LesniHospodarskaEvidenceTableGateway : OracleTableDataGateway, ILesniHospodarskaEvidenceTableGateway
    {
        private const string SELECT_ALL = 
            "select id, id_psk, id_podvykon, id_druhtezby, id_drevina, plocha, mnozstvi" +
            " from LesniHospodarskaEvidence";
        private const string SELECT_ONE = 
            "select id, id_psk, id_podvykon, id_druhtezby, id_drevina, plocha, mnozstvi" +
            " from LesniHospodarskaEvidence" +
            " where id = :id";
        private const string INSERT = 
            "insert into LesniHospodarskaEvidence(id, id_psk, id_podvykon, id_druhtezby id_drevina, plocha, mnozstvi)" +
            " values (:id, :id_psk, :id_podvykon, :id_druhtezby, :id_drevina, :plocha, :mnozstvi)";
        private const string UPDATE = 
            "update LesniHospodarskaEvidence" +
            " set id_psk = :id_psk," +
            " id_podvykon = :id_podvykon," +
            " id_druhtezby = :id_druhtezby," +
            " id_drevina = :id_drevina," +
            " plocha = :plocha," +
            " mnozstvi = :mnozstvi" +
            " where id = :id";
        private const string DELETE = "delete from LesniHospodarskaEvidence where id = :id";

        public override bool Delete(Model obj)
        {
            LesniHospodarskaEvidence del = (LesniHospodarskaEvidence)obj;
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
            LesniHospodarskaEvidence ins = (LesniHospodarskaEvidence)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":id_podvykon", ins.IdPodvykon);
                        cmd.Parameters.Add(":id_druzhtezby", ins.IdDruhTezby);
                        cmd.Parameters.Add(":id_drevina", ins.IdDrevina);
                        cmd.Parameters.Add(":plocha", ins.Plocha);
                        cmd.Parameters.Add(":mnozstvi", ins.Mnozstvi);
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
            LesniHospodarskaEvidence ins = (LesniHospodarskaEvidence)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_psk", ins.IdPorostniSkupina);
                        cmd.Parameters.Add(":id_podvykon", ins.IdPodvykon);
                        cmd.Parameters.Add(":id_druzhtezby", ins.IdDruhTezby);
                        cmd.Parameters.Add(":id_drevina", ins.IdDrevina);
                        cmd.Parameters.Add(":plocha", ins.Plocha);
                        cmd.Parameters.Add(":mnozstvi", ins.Mnozstvi);
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
                            LesniHospodarskaEvidence lesniHospodarskaEvidence = new LesniHospodarskaEvidence
                            {
                                Id = reader.GetString(++i),
                                IdPorostniSkupina = reader.GetString(++i),
                                IdPodvykon = reader.GetString(++i),
                                IdDruhTezby = reader.GetString(++i),
                                IdDrevina = reader.GetString(++i),
                                Plocha = reader.GetDouble(++i),
                                Mnozstvi = reader.GetDouble(++i)
                            };
                            result.Add(lesniHospodarskaEvidence);
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
