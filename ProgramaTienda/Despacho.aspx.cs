using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProgramaTienda
{
    public partial class Despacho : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmbNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            String codigo = (sender as DropDownList).SelectedValue;
            GestionProducto modelo = new GestionProducto();
            Producto producto1 = modelo.consultarPorCodigo(long.Parse(codigo));
            lblPrecio.Text = producto1.Precio.ToString();
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            GestionProducto modelo = new GestionProducto();
            if (Session["listaProductos"] != null)
            {
                List<Producto> listaProducto = (List<Producto>)Session["listaProductos"];
                for (int i = 0; i < listaProducto.Count; i++)
                {
                    Producto producto1 = listaProducto.ElementAt(i);
                    String cantidad = txtCantidad.Text;
                    producto1.Cantidad = int.Parse(cantidad);
                    modelo.Despacho(producto1);
                }
                Session["listaProductos"] = null;
            }
            else
            {
                Response.Write("<script language=javascript>alert('NO HAY PRODUCTOS AGREGADOS');</script>");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            List<Producto> listaProducto = new List<Producto>();
            if (Session["listaProductos"] != null)
            {
                listaProducto = (List<Producto>) Session["listaProductos"];
            }

            String codigo = cmbNombres.SelectedItem.Value;
            GestionProducto modelo = new GestionProducto();
            Producto producto1 = modelo.consultarPorCodigo(long.Parse(codigo));
            String cantidad = txtCantidad.Text;
            if (producto1.Cantidad >= Int32.Parse(cantidad))
            {
                listaProducto.Add(producto1);
                Session["listaProductos"] = listaProducto;

                for(int i=0; i < listaProducto.Count; i++)
                {
                    TableRow productos = new TableRow();
                    producto1 = listaProducto.ElementAt(i);

                    TableCell nombre = new TableCell();
                    nombre.Text = producto1.Nombre;
                    productos.Cells.Add(nombre);

                    TableCell cantidadCelda = new TableCell();
                    cantidadCelda.Text = txtCantidad.Text;
                    productos.Cells.Add(cantidadCelda);

                    TableCell precio = new TableCell();
                    precio.Text = producto1.Precio.ToString();
                    productos.Cells.Add(precio);

                    TableCell fecha = new TableCell();
                    fecha.Text = producto1.FechaVencimiento.ToString();
                    productos.Cells.Add(fecha);
                
                    tblProductos.Rows.Add(productos);
                }

            }
            else
            {
                Response.Write("<script language=javascript>alert('CANTIDAD INGRESADA MAYOR A LA EXISTENTE');</script>");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresoProductos.aspx");
        }
    }
}