using MySql.Data.MySqlClient;
using Server.DataBaseManager;
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

        public string Login(Login login)
        {
            string uId = "uid";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM felhasznalok WHERE LoginNev = @LoginNev";
            MySqlConnection connection = BaseDatabaseManager.connection;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@LoginNev", MySqlDbType.Int32)).Value = login.LoginNev;
                connection.Open();
                cmd.Connection = connection;
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string hash = reader.GetString("HASH");
                if (hash != null && hash == login.Jelszo)
                {
                    uId = hash;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return uId;
        }
    }
}