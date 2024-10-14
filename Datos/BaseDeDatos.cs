using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    // Clase que gestiona la conexión a la base de datos.
    public class BaseDeDatos
    {
        // Propiedad que obtiene la cadena de conexión desde el archivo de configuración.
        public static string Connection
        {
            get
            {
                // Devuelve la cadena de conexión con el nombre "NWConnectionString".
                return ConfigurationManager.ConnectionStrings["NWConnectionString"].ConnectionString;
            }
        }

        // Método que crea y abre una conexión SQL.
        public static SqlConnection GetSqlConnection()
        {
            // Instancia una nueva conexión SQL utilizando la cadena de conexión.
            SqlConnection connection = new SqlConnection(Connection);
            // Abre la conexión a la base de datos.
            connection.Open();
            // Devuelve la conexión abierta.
            return connection;
        }
    }
}

