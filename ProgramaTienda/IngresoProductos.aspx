<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoProductos.aspx.cs" Inherits="ProgramaTienda.IngresoProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Resource/css/Estilos.css" rel="stylesheet" />
</head>
<body class="colorFondoProductos">
    <form id="form1" runat="server">
        <h1>Ingreso de Productos</h1>
        <div class="productos">
            <div>
                <img class="mb-1" alt="" src="https://www.prestashop.com/sites/default/files/styles/blog_750x320/public/blog/2018/03/fichas-de-producto.png?itok=z3_rWSqa" /><div class="productos">
            </div>
        </div>
            <asp:TextBox class="form-control mb-3" placeholder="Nombre del producto" ID="txtNombre" runat="server" BorderColor="Black"></asp:TextBox>
            <asp:TextBox class="form-control mb-3" placeholder="Cantidad de producto" ID="txtCantidad" runat="server" BackColor="Aqua" BorderColor="Black"></asp:TextBox>
            <asp:TextBox class="form-control mb-3" placeholder="Precio de producto" ID="txtPrecio" runat="server" BorderColor="Black"></asp:TextBox>
            <asp:TextBox class="form-control mb-3" placeholder="Fecha de vencimiento" ID="txtFechaVencimiento" runat="server" BackColor="Aqua" BorderColor="Black"></asp:TextBox>
            <asp:Button class="btn btn-warning" ID="btnIngresarProducto" runat="server" Text="Ingresar Producto" OnClick="btnIngresarProducto_Click" />
            <asp:Button class="btn btn-warning btnCerrarSesion" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
        </div>
    </form>
</body>
</html>
