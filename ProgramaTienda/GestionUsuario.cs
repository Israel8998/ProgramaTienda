using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaTienda
{
    public class GestionUsuario
    {
        //Validación inicio de sesión
        public List<Usuario> consultar_Administrador(String usuario, String contraseña)
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            List<Usuario> user = new List<Usuario>();
            try
            {
                con.Open();
                SqlCommand sqlcom;
                String sql = "select * from Usuarios where Contraseña ='" + contraseña + "' and Usuario ='" + usuario + "'";
                sqlcom = new SqlCommand(sql, con);
                SqlDataReader r = sqlcom.ExecuteReader();
                while (r.Read())
                {
                    user.Add(new Usuario
                    {
                        Usuarios = r.GetString(0),
                        Contraseña = r.GetString(1),
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

            return user;
        }

        //registro de usuarios
        public int registro_usuario(string Usuario, string Contraseña)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"INSERT INTO Usuarios(Usuario, Contraseña)
					                   values('" + Usuario + "','" + Contraseña + "')";
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

        //Consultar usuarios
        public List<Usuario> consultar_Usuarios()
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            List<Usuario> user = new List<Usuario>();
            try
            {
                con.Open();
                SqlCommand sqlcom;
                String sql = "select * from Usuarios";
                sqlcom = new SqlCommand(sql, con);
                SqlDataReader r = sqlcom.ExecuteReader();
                while (r.Read())
                {
                    user.Add(new Usuario
                    {
                        Usuarios = r.GetString(0),
                        Contraseña = r.GetString(1),
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

            return user;
        }


        //Eliminar usuario
        public int eliminar_usuario(string Usuario)
        {
            int filas = 0;
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            try
            {
                con.Open();
                string query = @"delete from Usuarios where Usuario = '" + Usuario + "'";
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