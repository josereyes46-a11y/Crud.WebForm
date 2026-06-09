<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Crud.WebForm.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Ferretería MOMO</title>
    <link rel="stylesheet" type="text/css" href="estilo.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="titulo"></div>
        <br />
        <div class="contenedor">

            <div class="icono">
                <asp:Image ID="imgUser" runat="server" ImageUrl="~/vistas/Login/user.png" />
            </div>

            <div class="input-group">
                <asp:Label ID="lblUser" runat="server" Text="Usuario:" />
                <asp:TextBox ID="txtUser" runat="server" />
            </div>

            <div class="input-group">
                <asp:Label ID="lblPass" runat="server" Text="Contraseña:" />
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
            </div>

            <asp:Button ID="btnLogin" runat="server" Text="Iniciar sesión" 
                        OnClick="btnLogin_Click" CssClass="login_btn" Width="270px" />
            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
