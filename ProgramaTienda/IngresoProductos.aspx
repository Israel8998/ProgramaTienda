<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoProductos.aspx.cs" Inherits="ProgramaTienda.IngresoProductos" %>

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
            <h1>Ingreso de Productos</h1>
        </div>
        <div>
            <img class="mb-3 imagenIngProd" alt="" src="https://www.prestashop.com/sites/default/files/styles/blog_750x320/public/blog/2018/03/fichas-de-producto.png?itok=z3_rWSqa" />
        </div>
        <div class="productos fondoBLanco">
            <asp:TextBox class="form-control mb-3" placeholder="Codigo del producto" ID="txtCodigo" runat="server" BorderColor="Black" Visible="False"></asp:TextBox>
            <asp:TextBox class="form-control mb-3" placeholder="Nombre del producto" ID="txtNombre" runat="server" BorderColor="Black"></asp:TextBox>
            <asp:TextBox class="form-control mb-3" placeholder="Cantidad de producto" ID="txtCantidad" runat="server" BorderColor="Black"></asp:TextBox>

            <div class="input-group mb-3">
                <span class="input-group-text">$</span>
                <asp:TextBox class="form-control" placeholder="Precio de producto" ID="txtPrecio" runat="server" BorderColor="Black"></asp:TextBox>
            </div>
            <div class="mb-5">
                <asp:TextBox class="form-control mb-3" placeholder="Fecha de vencimiento" ID="txtFechaVencimiento" runat="server" BorderColor="Black"></asp:TextBox>
            </div>
            <asp:Button class="btn btn-outline-dark mb-1" ID="btnIngresarProducto" runat="server" Text="Ingresar Producto" OnClick="btnIngresarProducto_Click" />
            <asp:Button class="btn btn-outline-dark" ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <div class="mb-3 btnDerecha btnProductosCerrar">
                <asp:Button class="btn btn-outline-success" ID="btnImprimir" runat="server" Text="Imprimir" OnClick="btnImprimir_Click" />
                <asp:Button class="btn btn-outline-success" ID="btnDespacho" runat="server" Text="Despacho" OnClick="btnDespacho_Click" />
                <asp:Button class="btn btn-outline-danger" ID="btnCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="btnCerrarSesion_Click" />
                <asp:ImageButton class="imagenCalendario" ID="btnCalendario" runat="server" src="https://cdn-icons-png.flaticon.com/512/3652/3652267.png" OnClick="btnCalendario_Click"/>
            </div>
        </div>

        <div>
            <div class="mb-3">
                <asp:Button class="btn btn-outline-light btnProductos" ID="btnProductos" runat="server" Text="Ver Productos" OnClick="btnProductos_Click" />
            </div>
            <div class="mb-1 btnsIngProd">
            </div>
        </div>

            <asp:Calendar class="calendario" ID="Calendario" runat="server" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px" OnDayRender="Calendario_DayRender" OnSelectionChanged="Calendario_SelectionChanged">
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <SelectorStyle BackColor="#CCCCCC" />
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <WeekendDayStyle BackColor="#FFFFCC" />
            </asp:Calendar>
        <div class="align-content-center">
        <asp:GridView ID="GridView2"  runat="server"  CssClass="table table-responsive table-bordered border-dark tabla_datos fondoBLanco tablaDespacho"              BorderColor="Transparent" AutoGenerateColumns="false" OnSelectedIndexChanged="btnEditar_Click"             DataKeyNames="codigo" OnRowDataBound="GridView2_RowDataBound">            <Columns>                <asp:BoundField DataField="Codigo" HeaderText="CODIGO" Visible="False" />                <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />                <asp:BoundField DataField="Cantidad" HeaderText="CANTIDAD" />                <asp:BoundField DataField="Precio" HeaderText="PRECIO" />                <asp:BoundField DataField="FechaVencimiento" HeaderText="FECHA DE VENCIMIENTO" />                <asp:TemplateField>            <ItemTemplate>                <asp:LinkButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("Codigo")+";"+Eval("Nombre")+";"+Eval("Cantidad")+";"+Eval("Precio")+";"+Eval("FechaVencimiento") %>'                    CssClass="btn btn-secondary" BorderColor="Transparent" OnClick="btnEditar_Click"><span class="glyphicon glyphicon-list-alt">EDITAR</span>                </asp:LinkButton>                <asp:LinkButton ID="btn_Asignar_rc" runat="server"  CommandArgument='<%# Eval("Codigo") %>'   CssClass="btn btn-danger" BorderColor="Transparent" OnClick="btnEliminar_Click" >                       <span class="glyphicon glyphicon-list-alt">ELIMINAR</span>                    </asp:LinkButton>                </ItemTemplate>            </asp:TemplateField>                </Columns>            </asp:GridView>

        </div>
    </form>
</body>
</html>
