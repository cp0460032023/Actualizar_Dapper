using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class BaseDeDatos
    {
        public static string Connection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString;

            }

        }
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(Connection);
            connection.Open();
            return connection;
        }
    }
}
