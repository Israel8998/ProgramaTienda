<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="ProgramaTienda.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" class="colorFondoAzul">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Resource/css/Estilos.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 329px;
            height: 311px;
            margin-left: 0px;
        }
        .auto-style4 {
            position: absolute;
            left: 865px;
            top: 488px;
            width: 54px;
            height: 45px;
        }
        .auto-style5 {
            left: 2px;
            top: 0px;
            width: 27px;
        }
        .auto-style6 {
            position: absolute;
            left: 870px;
            top: 430px;
            width: 31px;
            height: 30px;
        }
        .auto-style7 {
            left: 0px;
            top: 0px;
            width: 26px;
            height: 24px;
        }
    </style>
</head>
<body class="colorFondoAzul">
    <form id="form1" runat="server">
        <h1>Inicio de sesión</h1>
        <div class="centrar">
            <div class="imagenes">
                <img alt="" src="https://image.flaticon.com/icons/png/512/47/47774.png" class="auto-style1 mb-3" />
            </div>
            <div>
                &nbsp;</div>
            <div>
                <asp:TextBox class="form-control mb-3" placeholder="Nombre de Usuario" ID="txtUsuario" runat="server"></asp:TextBox>
                <asp:TextBox class="form-control mb-3" placeholder="Contraseña" ID="txtContraseña" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Button class="btn btn-warning" ID="btnIngresar" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click" />
            </div>
            <div>
                <asp:Button class="btn btn-warning" ID="btnCrearCuenta" runat="server" Text="Crear Usuario" OnClick="btnCrearCuenta_Click" />
            </div>
        </div>
        <div class="auto-style6">
            <img alt="" src="https://cdn.icon-icons.com/icons2/827/PNG/128/user_icon-icons.com_66546.png" class="auto-style5" /></div>
        <div class="auto-style4">
            &nbsp;<img alt="" src="https://media.istockphoto.com/vectors/lock-padlock-password-security-icon-vector-id1194214491" class="auto-style7" /></div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
