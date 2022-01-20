<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoUsuarios.aspx.cs" Inherits="ProgramaTienda.IngresoUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Resource/css/Estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-bottom: .25rem;
            width: 504px;
            height: 252px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mb-3">
            <h1>Ingreso de Usuarios</h1>
        </div>
        <div class="centrar">
            <div class="mb-3">
            <img class="auto-style1" alt="" src="https://uploadgerencie.com/imagenes/usuarios-informacion-contable.png" />
            </div>
            <asp:TextBox class="form-control mb-3" placeholder="Usuario" ID="txtRegistroUsuario" runat="server" BorderColor="Black"></asp:TextBox>
            <asp:TextBox class="form-control mb-3" placeholder="Contraseña" ID="txtRegistroContraseña" runat="server" BorderColor="Black" TextMode="Password"></asp:TextBox>
            <asp:Button class="btn btn-outline-light" ID="btnIngresarUsuario" runat="server" Text="Ingresar Usuario" OnClick="btnIngresarUsuario_Click" />
            <asp:Button class="btn btn-outline-light" ID="btnUsuarios" runat="server" Text="Usuarios" OnClick="btnUsuarios_Click" />
            <asp:Button class="btn btn-danger" ID="btnCerrarSesion" runat="server" Text="Login" OnClick="btnCerrarSesion_Click" />
        </div>
        <div class="align-content-center">
        <asp:GridView ID="GridView1"  runat="server"  CssClass="table table-responsive tabla_datos"  BorderColor="Transparent" AutoGenerateColumns="False">            <Columns>                <asp:BoundField DataField="Usuarios" HeaderText="USUARIO" />                <asp:BoundField DataField="Contraseña" HeaderText="CONTRASEÑA" />                 <asp:TemplateField>            <ItemTemplate>                <asp:LinkButton ID="btn_Asignar_rc" runat="server"  CommandArgument='<%# Eval("Usuarios") %>'   CssClass="btn btn-secondary" BorderColor="Transparent" OnClick="btnEliminar_Click" >                       <span class="glyphicon glyphicon-list-alt">ELIMINAR</span>                    </asp:LinkButton>                </ItemTemplate>            </asp:TemplateField>                </Columns>            </asp:GridView>

        </div>
    </form>
</body>
</html>
