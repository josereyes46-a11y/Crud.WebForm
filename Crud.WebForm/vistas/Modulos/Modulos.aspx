<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modulos.aspx.cs" Inherits="Crud.WebForm.Modulos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Ferretería MOMO - Módulos</title>
    <link rel="stylesheet" type="text/css" href="estilo2.css" />
</head>
<body>
    <form id="form1" runat="server">

        <main class="contenido">
            <div class="card">
                <h2>Módulos</h2>
                <br />

                <asp:Label ID="lblBienvenido" runat="server" ForeColor="Green" />
                <br /><br />

                <asp:Button ID="btnUsuarios" runat="server" Text="Usuarios" CssClass="boton" OnClick="btnUsuarios_Click" />
                <br /><br />

                <asp:Button ID="btnRoles" runat="server" Text="Roles de Usuario" CssClass="boton" Onclick="btnRoles_Click" />
                <br /><br />

                <asp:Button ID="btnProductos" runat="server" Text="Productos" CssClass="boton" OnClick="btnProductos_Click" />
                <br /><br />

                <asp:Button ID="btnCatalogo" runat="server" Text="Catálogo de Productos" CssClass="boton" OnClick="btnCatalogo_Click" />
                <br /><br />

                <!--<asp:Button ID="btnHistorial" runat="server" Text="Historial" CssClass="boton" />
                <br /><br /-->

                <asp:Button ID="btnInventario" runat="server" Text="Gestión de Inventario" CssClass="boton" OnClick="btnInventario_Click" />
                <br /><br /-->

                <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" />
                <br /><br />

                <!--<asp:Button ID="btnReportes" runat="server" Text="Reportes" CssClass="boton" />
                <br /><br />-->

                <!--<asp:Button ID="btnRespaldo" runat="server" Text="Respaldo" CssClass="boton" />
                <br /><br />-->

                <br /><br /><br /> <br /> <br />
                <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/vistas/Modulos/closesion.png" AlternateText="Regresar" Height= "70px" Width="70px" OnClick="btnCerrarSesion_Click" />
    
            </div>
        </main>
    </form>
</body>
</html>
