using MySql.Data.MySqlClient;
using Server.DataBaseManager;
using Server.DTOs;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Controllers
{
    public class LoginController
    {
        public string GetSalt(string LoginNev)
        {
            string salt = "";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok WHERE LoginNev = @LoginNev";
            MySqlConnection connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@LoginNev", MySqlDbType.Int32)).Value = LoginNev;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                salt = reader.GetString("SALT");

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return salt;
        }

        public FelhasznaloKezeloDTO Login(Login login)
        {
            string uId = "";
            FelhasznaloKezeloDTO felhasznaloKezeloDTO = new FelhasznaloKezeloDTO();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok WHERE LoginNev = @LoginNev";
            MySqlConnection connection = BaseDatabaseManager.connection;
            cmd.Connection = connection;
            cmd.Parameters.Add(new MySqlParameter("@LoginNev", MySqlDbType.Int32)).Value = login.LoginNev;
            try
            {
                connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string hash = reader.GetString("HASH");
                bool aktiv = reader.GetBoolean("Aktiv");
                if (hash != null && hash == login.Jelszo && aktiv)
                {
                    bool talalt = false;
                    int index = 0;
                    int elemSzam = Service1.BejelentkezettFelhasznalok.Count;
                    while (!talalt && index < elemSzam)
                    {
                        if (Service1.BejelentkezettFelhasznalok.ElementAt(index).Value.LoginNev == login.LoginNev)
                        {
                            lock (Service1.BejelentkezettFelhasznalok)
                            {
                                Service1.BejelentkezettFelhasznalok.Remove
                                    (Service1.BejelentkezettFelhasznalok.ElementAt(index).Key);
                            }
                        }
                    }
                    uId = Guid.NewGuid().ToString();
                    Felhasznalo egyFelhasznalo = new Felhasznalo();
                    egyFelhasznalo.Id = reader.GetInt32("Id");
                    egyFelhasznalo.LoginNev = reader.GetString("LoginNev");
                    egyFelhasznalo.HASH = reader.GetString("HASH");
                    egyFelhasznalo.SALT = reader.GetString("SALT");
                    egyFelhasznalo.Nev = reader.GetString("Nev");
                    egyFelhasznalo.Jog = (byte)reader.GetInt32("Jog");
                    //egyFelhasznalo.Aktiv = bool.Parse(reader["Aktiv"].ToString().ToLower());
                    egyFelhasznalo.Aktiv = reader.GetBoolean("Aktiv");
                    egyFelhasznalo.Email = reader.GetString("Email");
                    egyFelhasznalo.ProfilKep = reader.GetString("ProfilKep");
                    Service1.BejelentkezettFelhasznalok.Add(uId, egyFelhasznalo);
                    felhasznaloKezeloDTO.Uid = uId;
                    felhasznaloKezeloDTO.Name = egyFelhasznalo.Nev;
                    felhasznaloKezeloDTO.Jog = egyFelhasznalo.Jog;
                }
                else
                {
                    uId = "Nem jó jelszó vagy nem aktív";
                }
            }
            catch (Exception ex)
            {
                felhasznaloKezeloDTO.Uid = "";
                felhasznaloKezeloDTO.Name = ex.Message;
                felhasznaloKezeloDTO.Jog = 0;
                return felhasznaloKezeloDTO;
            }
            finally
            {
                connection.Close();
            }
            return felhasznaloKezeloDTO;
        }
    }
}