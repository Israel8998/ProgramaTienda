using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaTienda
{
    public class Conexion
    {
        public static string Cadena()
        {
            SqlConnectionStringBuilder csql = new SqlConnectionStringBuilder();
            csql.DataSource = "localhost";
            csql.InitialCatalog = "BDDTienda";
            csql.UserID = "sa";
            csql.Password = "CUENA";
            csql.ConnectTimeout = 1000;
            return csql.ConnectionString;
        }
    }
}