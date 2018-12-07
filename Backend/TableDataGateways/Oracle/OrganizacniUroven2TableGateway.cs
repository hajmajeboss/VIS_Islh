using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class OrganizacniUroven2TableGateway : OracleTableDataGateway
    {
        private const string SELECT_ALL = "select id, id_org1, kod, popis, poznamka from OrganizacniUroven2";
        private const string SELECT_ONE = "select id, id_org1, kod, popis, poznamka from OrganizacniUroven2 where id = :id";
        private const string INSERT = "insert into OrganizacniUroven2(id, id_org1, kod, popis, poznamka) values (:id, :kod, :popis, :poznamka)";
        private const string UPDATE = "update OrganizacniUroven2 set id_org1 = :id_org1, kod = :kod, popis = :popis, poznamka = :poznamka where id = :id";
        private const string DELETE = "delete from OrganizacniUroven2 where id = :id";

        public override bool Delete(Model obj)
        {
            OrganizacniUroven2 del = (OrganizacniUroven2)obj;
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
            OrganizacniUroven2 ins = (OrganizacniUroven2)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":id_org1", ins.IdOrganizacniUroven1);
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
            OrganizacniUroven2 ins = (OrganizacniUroven2)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":id_org1", ins.IdOrganizacniUroven1);
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
                            OrganizacniUroven2 organizacniUroven2 = new OrganizacniUroven2
                            {
                                Id = reader.GetString(++i),
                                IdOrganizacniUroven1 = reader.GetString(++i),
                                Kod = reader.GetString(++i),
                                Popis = !reader.IsDBNull(++i) ? reader.GetString(i) : null,
                                Poznamka = !reader.IsDBNull(++i) ? reader.GetString(i) : null
                            };
                            result.Add(organizacniUroven2);
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
