using MySql.Data.MySqlClient;
using Server.DataBaseManager;
using Server.Models;
using System;
using System.Collections.Generic;

namespace Server.Controllers
{
    public class JogosultsagokController : BaseDatabaseManager, ISQL
    {
        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM jogosultsagok ORDER BY Nev";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Jogosultsag egyJogosultsag = new Jogosultsag();
                    egyJogosultsag.Id = int.Parse(reader["Id"].ToString());
                    egyJogosultsag.Szint = byte.Parse(reader["Szint"].ToString());
                    egyJogosultsag.Nev = reader["Nev"].ToString();
                    list.Add(egyJogosultsag);
                }
            }
            catch (Exception ex)
            {
                Jogosultsag jogosultsag = new Jogosultsag();
                jogosultsag.Id = -1;
                jogosultsag.Nev = ex.Message;
                list.Add(jogosultsag);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public string Insert(Record record)
        {
            Jogosultsag jogosultsag = record as Jogosultsag;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"INSERT INTO jogosultsagok (Szint, Nev) VALUES (@Szint, @Nev);";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Szint", MySqlDbType.VarChar)).Value = jogosultsag.Szint;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsag.Nev;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            cmd.Parameters.Clear();
            return "Sikeres adattárolás.";
        }

        public string Update(Record record)
        {
            Jogosultsag jogosultsag = record as Jogosultsag;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"UPDATE jogosultsagok SET Szint=@Szint, Nev=@Nev WHERE Id=@Id";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Szint", MySqlDbType.VarChar)).Value = jogosultsag.Szint;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = jogosultsag.Nev;
                try
                {
                    cmd.Connection.Open();
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    cmd.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            cmd.Parameters.Clear();
            return "Sikeres adatmódosítás.";
        }

        public string Delete(int id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"DELETE FROM jogosultsagok WHERE Id=@Id";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32)).Value = id;
                cmd.Connection.Open();
                int db = cmd.ExecuteNonQuery();
                if (db == 0)
                {
                    return "Nincs ilyen id-vel rendelkező rekord!";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return "Sikeres adattörlés.";
        }
    }
}