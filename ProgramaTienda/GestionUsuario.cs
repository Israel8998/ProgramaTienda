using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProgramaTienda
{
    public class GestionUsuario
    {
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
    }
}