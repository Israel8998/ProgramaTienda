using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramaTienda
{
    public partial class IngresoUsuarios : System.Web.UI.Page
    {
        List<Usuario> ingre = new List<Usuario>();

        public void CargarDataGridUsuario()
        {
            GestionUsuario modelo = new GestionUsuario();
            ingre = modelo.consultar_Usuarios();
            GridView1.DataSource = ingre.ToList();
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresarUsuario_Click(object sender, EventArgs e)
        {
            String correo = txtRegistroUsuario.Text;
            String password = txtRegistroContraseña.Text;

            GestionUsuario modelo = new GestionUsuario();
            int filas = modelo.registro_usuario(correo, password);

            txtRegistroUsuario.Text = "";
            txtRegistroContraseña.Text = "";

            Response.Write("<script language=javascript>alert('USUARIOS CREADO CORRECTAMENTE ');</script>");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            CargarDataGridUsuario();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Session["Usuarios"] = 0;
            String Usuario = (sender as LinkButton).CommandArgument;
            Session["Usuarios"] = Usuario;

            GestionUsuario mode1 = new GestionUsuario();
            int filas = mode1.eliminar_usuario(Usuario);

            Response.Write("<script language=javascript>alert('Usuario eliminado');</script>");

            CargarDataGridUsuario();
        }
    }
}