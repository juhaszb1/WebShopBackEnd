using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Server.DataBaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager() { }

        public static MySqlConnection connection
        {
            get 
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "SERVER=192.168.50.97;"+"DATABASE=webshop;"+"UID=root;"+"PASSWORD=password;"+"SSL MODE=none;";
                connection.ConnectionString = connectionString;
                return connection;
            }
        }
    }
}