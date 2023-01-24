using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;


namespace HRMS.DAL
{
    public class DBConnection
    {
      
        public static string connectionString = @"Data Source =DESKTOP-8SAEBD9\SQLEXPRESS;Initial Catalog = HRMS; integrated security = true";
        public IDbConnection connection;
        public DBConnection()
        {
            connection = new SqlConnection(connectionString);
        }
        public void CloseConnection()
        {
            connection.Dispose();
        }
    }
}
