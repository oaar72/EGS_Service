using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EGS_Services.Network
{
    public class Connection
    {
        private string connectionString;
        private string server;
        private string username;
        private string password;
        private string DB;

        public Connection()
        {
            server = ConfigurationManager.AppSettings["ServerDB"].ToString();
            username = ConfigurationManager.AppSettings["UserDB"].ToString();
            password = ConfigurationManager.AppSettings["PassDB"].ToString();
            DB = ConfigurationManager.AppSettings["DB"].ToString();

            //connectionString = "Server=tcp:" + server + ",1433;Initial Catalog=EGS;Persist Security Info=False; " + "User ID = " + username + ";Password=" + password + ";MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            connectionString = "data source=" + server + ";initial catalog=" + DB + ";user id= " + username + ";password="+ password + ";MultipleActiveResultSets=True;App=EntityFramework";
        }

        public string getConnectionString()
        {
            return this.connectionString;
        }

        public string getUsername()
        {
            return this.username;
        }

        public string getPassword()
        {
            return this.password;
        }
    }
}