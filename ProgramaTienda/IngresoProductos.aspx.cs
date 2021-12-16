using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramaTienda
{
    public partial class IngresoProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresarProducto_Click(object sender, EventArgs e)
        {
            List<GestionProducto> log = new List<GestionProducto>();
            String producto = txtNombre.Text;
            String cantidad = txtCantidad.Text;
            String precio = txtPrecio.Text;
            String FechaVencimiento = txtFechaVencimiento.Text;

            GestionProducto modelo = new GestionProducto();
            int filas = modelo.registro_producto(producto.Replace("  ", String.Empty), cantidad, precio.Replace(',', '.'), FechaVencimiento);

            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtFechaVencimiento.Text = "";

            Response.Write("<script language=javascript>alert('PRODUCTO REGISTRADO CORECTAMENTE ');</script>");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }
    }
}