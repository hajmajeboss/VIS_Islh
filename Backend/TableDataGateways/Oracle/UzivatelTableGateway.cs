using System;
using System.Collections.Generic;
using System.Text;
using Backend.Models;
using Backend.TableDataGateways.Interfaces;
using Oracle.ManagedDataAccess.Client;

namespace Backend.TableDataGateways.Oracle
{
    public class UzivatelTableGateway : OracleTableDataGateway, IUzivatelTableGateway
    {
        private const string SELECT_ALL = "select id, username, pass_sha256, role, jmeno, email from Uzivatel";
        private const string SELECT_ONE = "select id, username, pass_sha256, role, jmeno, email from Uzivatel where id = :id";
        private const string SELECT_BY_NAME = "select id, username, pass_sha256, role, jmeno, email from Uzivatel where username = :username";
        private const string INSERT = "insert into Uzivatel(id, username, pass_sha256, role, jmeno, email) values (:id, :username, :pass_sha256, :role, :jmeno, :email)";
        private const string UPDATE = "update Uzivatel set username=:username, pass_sha256=:pass_sha256, role=:role, jmeno=:jmeno, email=:email where id = :id";
        private const string DELETE = "delete from Uzivatel where id = :id";

        public override bool Delete(Model obj)
        {
            Uzivatel del = (Uzivatel)obj;
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
            Uzivatel ins = (Uzivatel)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = INSERT;
                        cmd.Parameters.Add(":id", ins.Id);
                        cmd.Parameters.Add(":username", ins.Username);
                        cmd.Parameters.Add(":pass_sha256", ins.Password);
                        cmd.Parameters.Add(":role", ins.Role);
                        cmd.Parameters.Add(":jmeno", ins.Jmeno);
                        cmd.Parameters.Add(":email", ins.Email);
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
            Uzivatel ins = (Uzivatel)obj;
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = UPDATE;
                        cmd.Parameters.Add(":username", ins.Username);
                        cmd.Parameters.Add(":pass_sha256", ins.Password);
                        cmd.Parameters.Add(":role", ins.Role);
                        cmd.Parameters.Add(":jmeno", ins.Jmeno);
                        cmd.Parameters.Add(":email", ins.Email);
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
                            Uzivatel uzivatel = new Uzivatel
                            {
                                Id = reader.GetString(++i),
                                Username = reader.GetString(++i),
                                Password = reader.GetString(++i),
                                Role = reader.GetInt16(++i),
                                Jmeno = reader.GetString(++i),
                                Email = reader.GetString(++i)
                            };
                            result.Add(uzivatel);
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


        public Model SelectByName(string username)
        {
            List<Model> result = new List<Model>();
            using (var c = ConnetionFactory.GetOracleConnection())
            {
                using (var cmd = c.CreateCommand())
                {
                    try
                    {
                        cmd.CommandText = SELECT_BY_NAME;
                        cmd.Parameters.Add(":username", username);
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int i = -1;
                            Uzivatel uzivatel = new Uzivatel
                            {
                                Id = reader.GetString(++i),
                                Username = reader.GetString(++i),
                                Password = reader.GetString(++i),
                                Role = reader.GetInt16(++i),
                                Jmeno = reader.GetString(++i),
                                Email = reader.GetString(++i)
                            };
                            result.Add(uzivatel);
                        }
                        return result.Count > 0 ? result[0] : null;
                    }
                    catch (OracleException oe)
                    {
                        Log(oe.Message);
                        return null;
                    }
                }
            }
        }

    }
}
