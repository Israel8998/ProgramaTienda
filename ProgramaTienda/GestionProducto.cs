    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaTienda
{
    public class GestionProducto
    {
        // Registro de productos
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

        //Consultar productos
        public List<Producto> consultar_Productos()
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            List<Producto> producto = new List<Producto>();
            try
            {
                con.Open();
                SqlCommand sqlcom;
                String sql = "select * from Productos";
                sqlcom = new SqlCommand(sql, con);
                SqlDataReader r = sqlcom.ExecuteReader();
                while (r.Read())
                {
                    producto.Add(new Producto
                    {
                        Nombre = r.GetString(0),
                        Cantidad = r.GetInt32(1),
                        Precio = r.GetDouble(2), 
                        FechaVencimiento = r.GetDateTime(3),
                        Codigo = r.GetInt64(4),
                    });

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return producto;
        }

        //Eliminar productos
        public int eliminar_productos(long codigo)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"delete from Productos where Codigo = @CODIGO";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CODIGO", codigo);
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

        // Modificar Productos
        public int modificar_producto(Producto producto)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"UPDATE Productos SET Nombre = @NOMBRE, Cantidad = @CANTIDAD, Precio = @PRECIO, FechaVencimiento = @FECHA where Codigo = @CODIGO";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NOMBRE", producto.Nombre);
                cmd.Parameters.AddWithValue("@CANTIDAD", producto.Cantidad);
                cmd.Parameters.AddWithValue("@PRECIO", producto.Precio);
                cmd.Parameters.AddWithValue("@FECHA", producto.FechaVencimiento);
                cmd.Parameters.AddWithValue("@CODIGO",producto.Codigo);
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

        // Despacho
        public int Despacho(Producto producto)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"UPDATE Productos SET Cantidad = Cantidad - @CANTIDAD where Codigo=@CODIGO";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CODIGO", producto.Codigo);
                cmd.Parameters.AddWithValue("@CANTIDAD", producto.Cantidad);
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

        //Consultar por codigo
        public Producto consultarPorCodigo(long codigo)
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            Producto producto = new Producto();
            try
            {
                con.Open();
                SqlCommand sqlcom;
                String sql = "select * from Productos where codigo = @CODIGO";
                sqlcom = new SqlCommand(sql, con);
                sqlcom.Parameters.AddWithValue("@CODIGO", codigo);
                SqlDataReader r = sqlcom.ExecuteReader();
                while (r.Read())
                {
                    producto = new Producto
                    {
                        Nombre = r.GetString(0),
                        Cantidad = r.GetInt32(1),
                        Precio = r.GetDouble(2),
                        FechaVencimiento = r.GetDateTime(3),
                        Codigo = r.GetInt64(4),
                    };

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return producto;
        }
    }
}