using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Server.DataBaseManager;
using Server.Models;

namespace Server.Controllers
{
    public class FelhasznalokController:BaseDatabaseManager,ISQL
    {
        public List<Record> Select()
        {
            List<Record> list = new List<Record>();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok ORDER BY Nev";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) 
                {
                    Felhasznalo egyFelhasznalo = new Felhasznalo();
                    egyFelhasznalo.Id = int.Parse(reader["Id"].ToString());
                    egyFelhasznalo.LoginNev = reader["LoginNev"].ToString();
                    egyFelhasznalo.HASH = reader["HASH"].ToString();
                    egyFelhasznalo.SALT = reader["SALT"].ToString();
                    egyFelhasznalo.Nev = reader["Nev"].ToString();
                    egyFelhasznalo.Jog = byte.Parse(reader["Jog"].ToString());
                    egyFelhasznalo.Aktiv = bool.Parse(reader["Aktiv"].ToString().ToLower());
                    egyFelhasznalo.Email = reader["Email"].ToString();
                    egyFelhasznalo.ProfilKep = reader["ProfilKep"].ToString();
                    list.Add(egyFelhasznalo);
                }
            }
            catch (Exception ex)
            {
                Felhasznalo felhasznalo = new Felhasznalo();
                felhasznalo.Id = -1;
                felhasznalo.Nev = ex.Message;
                list.Add(felhasznalo);
            }
            finally
            {
                connection.Close();
            }
            return list;
        }

        public string Insert(Record record) 
        { 
            Felhasznalo felhasznalo = record as Felhasznalo;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"INSERT INTO felhasznalok (LoginNev, HASH, SALT, Nev, Jog, Aktiv, Email, ProfilKep) VALUES 
                                (@LoginNev, @HASH, @SALT, @Nev, @Jog, @Aktiv, @Email, @ProfilKep);";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@LoginNev", MySqlDbType.VarChar)).Value = felhasznalo.LoginNev;
                cmd.Parameters.Add(new MySqlParameter("@HASH", MySqlDbType.VarChar)).Value = felhasznalo.HASH;
                cmd.Parameters.Add(new MySqlParameter("@SALT", MySqlDbType.VarChar)).Value = felhasznalo.SALT;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = felhasznalo.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Jog", MySqlDbType.Int32)).Value = felhasznalo.Jog;
                cmd.Parameters.Add(new MySqlParameter("@Aktiv", MySqlDbType.Byte)).Value = felhasznalo.Aktiv;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = felhasznalo.Email;
                cmd.Parameters.Add(new MySqlParameter("@ProfilKep", MySqlDbType.VarChar)).Value = felhasznalo.ProfilKep;
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
            Felhasznalo felhasznalo = record as Felhasznalo;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = @"UPDATE felhasznalok SET LoginNev=@LoginNev, SALT=@SALT, HASH=@HASH, Nev=@Nev, Jog=@Jog, Aktiv=@Aktiv, Email=@Email, ProfilKep=@ProfilKep 
                                WHERE Id=@Id";
            cmd.Connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@Id", MySqlDbType.Int32)).Value = felhasznalo.Id;
                cmd.Parameters.Add(new MySqlParameter("@LoginNev", MySqlDbType.VarChar)).Value = felhasznalo.LoginNev;
                cmd.Parameters.Add(new MySqlParameter("@HASH", MySqlDbType.VarChar)).Value = felhasznalo.HASH;
                cmd.Parameters.Add(new MySqlParameter("@SALT", MySqlDbType.VarChar)).Value = felhasznalo.SALT;
                cmd.Parameters.Add(new MySqlParameter("@Nev", MySqlDbType.VarChar)).Value = felhasznalo.Nev;
                cmd.Parameters.Add(new MySqlParameter("@Jog", MySqlDbType.Int32)).Value = felhasznalo.Jog;
                cmd.Parameters.Add(new MySqlParameter("@Aktiv", MySqlDbType.Byte)).Value = felhasznalo.Aktiv;
                cmd.Parameters.Add(new MySqlParameter("@Email", MySqlDbType.VarChar)).Value = felhasznalo.Email;
                cmd.Parameters.Add(new MySqlParameter("@ProfilKep", MySqlDbType.VarChar)).Value = felhasznalo.ProfilKep;
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
            cmd.CommandText = @"DELETE FROM felhasznalok WHERE Id=@Id";
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