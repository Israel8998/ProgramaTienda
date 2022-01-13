using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramaTienda
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> log = new List<Usuario>();

            String usuario = txtUsuario.Text;
            String contraseña = txtContraseña.Text;

            GestionUsuario modelo = new GestionUsuario();
            log = modelo.consultar_Administrador(usuario, contraseña);
            Usuario user1 = log.FirstOrDefault();
            if (user1 != null)
            {
                Response.Redirect("IngresoProductos.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Usuario o contraseña incorrectos');</script>");
            }
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            List<Usuario> log = new List<Usuario>();

            String usuario = txtUsuario.Text;
            String contraseña = txtContraseña.Text;

            GestionUsuario modelo = new GestionUsuario();
            log = modelo.consultar_Administrador(usuario, contraseña);
            Usuario user1 = log.FirstOrDefault();
            if (user1 != null)
            {
                Response.Redirect("IngresoUsuarios.aspx");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Usuario o contraseña incorrectos');</script>");
            }
        }
    }
}