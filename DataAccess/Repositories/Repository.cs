using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public class Repository
    {
        private readonly string connectionString;
        public Repository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connInteleSys"].ToString();
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
