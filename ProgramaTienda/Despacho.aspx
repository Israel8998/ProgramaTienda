<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Despacho.aspx.cs" Inherits="ProgramaTienda.Despacho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Resource/css/Estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="Titulo">
            <h1>Despacho de productos</h1>
        </div>

        <div class="imagenesDespacho">
            <img alt="" src="https://delectra.com.ve/imagen/despachoproductos/9.png" class="imagenesDespacho"/>
        </div>

        <div class="despacho mb-3">
            <div>
                <asp:Label class="h4" ID="Label3" runat="server" Text=" Nombre del producto"></asp:Label>
            </div>
            <div class="mb-5">
                <asp:DropDownList class="btn btn-outline-primary" ID="cmbNombres" runat="server" DataSourceID="SqlBDDTienda" DataTextField="producto" DataValueField="Codigo" Width="228px" AutoPostBack="True" OnSelectedIndexChanged="cmbNombres_SelectedIndexChanged">
                    <asp:ListItem>Productos</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlBDDTienda" runat="server" ConnectionString="<%$ ConnectionStrings:BDDTiendaConnectionString %>" SelectCommand="SELECT [Codigo], CONCAT ( (TRIM ([Nombre])), ' - ', [Cantidad] ) producto from [Productos]"></asp:SqlDataSource>
            </div>
            <div class="lblPrecio">
                <asp:Label class="h4 lead" ID="Label1" runat="server" Text="Precio: $"></asp:Label>
                <asp:Label class="h4 lead" ID="lblPrecio" runat="server" Text="..."></asp:Label>
            </div>
            <div class="mb-3">
                <asp:TextBox class="form-control mb-3 txtCantidad" placeholder="Cantidad de producto" ID="txtCantidad" runat="server" BorderColor="Black"></asp:TextBox>
                <asp:Button class="btn btn-outline-primary" ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            </div>
            <div class="mb-5">
                <asp:Button class="btn btn-outline-primary" ID="btnImprimir" runat="server" Text="Despachar" OnClick="btnImprimir_Click" />
                <asp:Button class="btn btn-outline-primary" ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                <asp:Button class="btn btn-outline-danger" ID="btnCerrar" runat="server" Text="Cerrar Sesion" OnClick="btnCerrar_Click" />
            </div>
        </div>
        <div>
            <asp:Table ID="tblProductos" runat="server" class="table table-dark table-striped">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">Nombre</asp:TableCell>
                    <asp:TableCell runat="server">Cantidad</asp:TableCell>
                    <asp:TableCell runat="server">Precio</asp:TableCell>
                    <asp:TableCell runat="server">Fecha de Vencimiento</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>

    </form>
</body>
</html>
