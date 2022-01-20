using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ProgramaTienda
{
    public partial class IngresoProductos : System.Web.UI.Page
    {
        List<Producto> ingre = new List<Producto>();

        public void CargarDataGridProductos()
        {
            GestionProducto modelo = new GestionProducto();
            ingre = modelo.consultar_Productos();
            GridView2.DataSource = ingre.ToList();
            GridView2.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendario.Visible = false;
            }
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

            Response.Write("<script language=javascript>alert('PRODUCTO REGISTRADO CORECTAMENTE');</script>");

            CargarDataGridProductos();
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioSesion.aspx");
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            CargarDataGridProductos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Session["Codigo"] = 0;
            String codigo = (sender as LinkButton).CommandArgument;
            Session["Codigo"] = codigo;

            GestionProducto mode1 = new GestionProducto();
            int filas = mode1.eliminar_productos(long.Parse(codigo));

            Response.Write("<script language=javascript>alert('Producto eliminado');</script>");

            CargarDataGridProductos();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            GestionProducto modelo = new GestionProducto();
            Producto producto1 = new Producto();
            producto1.Nombre = txtNombre.Text;
            producto1.Cantidad = Int32.Parse(txtCantidad.Text);
            producto1.Precio = double.Parse(txtPrecio.Text);
            producto1.FechaVencimiento = DateTime.Parse(txtFechaVencimiento.Text);
            producto1.Codigo = long.Parse(txtCodigo.Text);
            modelo.modificar_producto(producto1);

            Response.Write("<script language=javascript>alert('Producto Actualizado');</script>");
            txtNombre.Text = "";
            txtCantidad.Text = "";
            txtPrecio.Text = "";
            txtFechaVencimiento.Text = "";
            CargarDataGridProductos();
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string[] arg = new string[5];
            arg = (sender as LinkButton).CommandArgument.ToString().Split(';');
            Session["Codigo"] = arg[0];
            Session["Nombre"] = arg[1];
            Session["Cantidad"] = arg[2];
            Session["Precio"] = arg[3];
            Session["FechaVencimiento"] = arg[4];
            string codigo = Session["Codigo"].ToString();
            string nombre = Session["Nombre"].ToString();
            string cantidad = Session["Cantidad"].ToString();
            string precio = Session["Precio"].ToString();
            string fecha = Session["FechaVencimiento"].ToString();

            txtCodigo.Text = codigo;
            txtNombre.Text = nombre;
            txtCantidad.Text = cantidad;
            txtPrecio.Text = precio;
            txtFechaVencimiento.Text = fecha;
        }

        protected void btnCalendario_Click(object sender, ImageClickEventArgs e)
        {
            Calendario.Visible = !Calendario.Visible;
        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            txtFechaVencimiento.Text = Calendario.SelectedDate.ToShortDateString();
            Calendario.Visible = false;
        }

        protected void Calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsToday)
            {
                e.Cell.Text = "Hoy";
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            string fechaingreso = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            DataTable dt = new DataTable();
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, HttpContext.Current.Response.OutputStream);
            dt = DtUsuarios();

            if (dt.Rows.Count > 0)
            {
                document.Open();
                Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 25);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 9);
                Font font10 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 15);


                PdfPTable table = new PdfPTable(dt.Columns.Count);
                document.Add(new Paragraph(20, "Despacho", fontTitle));
                document.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 4f;

                table.SetWidths(widths);
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }
                    }
                }

                document.Add(table);
                document.Add(new Chunk("\n"));
                document.Add(new Chunk("\n"));
                document.Add(new Chunk("\n"));
                document.Add(new Chunk("\n"));
                document.Add(new Paragraph(20, "Firma Client@s", font10));
                document.Add(new Paragraph(20, "Israel Pazmiño", font10));
                document.Add(new Paragraph(20, "Techno" + fechaingreso + "", font9));

            }
            document.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=OrdeSalida" + ".pdf");
            HttpContext.Current.Response.Write(document);
            Response.Flush();
            Response.End();
        }

        public DataTable DtUsuarios()
        {
            SqlConnection con = new SqlConnection(Conexion.Cadena());
            DataTable dsDat = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Productos ", con);
            SqlDataAdapter dsA = new SqlDataAdapter(cmd);
            dsA.Fill(dsDat);
            con.Close();

            return dsDat;
        }

        protected void btnDespacho_Click(object sender, EventArgs e)
        {
            Response.Redirect("Despacho.aspx");
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                string estado1 = DataBinder.Eval(e.Row.DataItem, "Cantidad").ToString();
                int cantidad = Int32.Parse(estado1);
                if(cantidad <= 0)
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Red;
                else if(cantidad <= 7)
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Violet;
                else
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.Green;

                string estado2 = DataBinder.Eval(e.Row.DataItem, "FechaVencimiento").ToString();
                DateTime fecha = DateTime.Parse(estado2);
                if (fecha <= DateTime.Now)
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Red;
                else
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}