using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaTienda
{
    public class GestionProducto
    {
        public int registro_producto(string Nombre, string Cantidad, string Precio, string FechaVencimiento)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"INSERT INTO Productos(Nombre, Cantidad, Precio, FechaVencimiento)
					                   values('" + Nombre + "','" + Cantidad + "'," + Precio + ",'" + FechaVencimiento + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                filas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return filas;
        }
    }
}