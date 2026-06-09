<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="Crud.WebForm.Roles" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <link rel="stylesheet" type="text/css" href="estilo4.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ferreteria MOMO</title>
</head>

<body>
    <form id="form1" runat="server">
        <main class="contenido">
            <div class="card">
                <h2>Roles</h2>
                <br />

                <div class="input-group">
                    <label for="txtId">ID:</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="campo" />
                </div>

                <div class="menu-select">
                    <label for="ddlRol">Rol de usuario:</label>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="campo">
                        <asp:ListItem Text="Empleado" Value="Empleado"></asp:ListItem>
                        <asp:ListItem Text="Administrador" Value="Administrador"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
                <asp:DropDownList ID="ddlUsuario" runat="server"></asp:DropDownList>

                <br /><br /><br /><br />

                <asp:ImageButton ID="btnAlta" runat="server" ImageUrl="~/vistas/Roles/pic_alta.png" AlternateText="Alta" Height="70px" Width="70px" OnClick="btnAlta_Click" />                
                <asp:ImageButton ID="btnBaja" runat="server" ImageUrl="~/vistas/Roles/pic_modif.png" AlternateText="Baja" Height="70px" Width="70px" OnClick="btnBaja_Click" />                
                <asp:ImageButton ID="btnConsulta" runat="server" ImageUrl="~/vistas/Roles/pic_baja.png" AlternateText="Consulta" Height="70px" Width="70px" OnClick="btnConsulta_Click" />                
                <asp:ImageButton ID="btnModificar" runat="server" ImageUrl="~/vistas/Roles/pic_cons.png" AlternateText="Modificacion" Height="70px" Width="70px" OnClick="btnModificar_Click" />                
                <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/vistas/Roles/pic_back.png" AlternateText="Regresar" Height="70px" Width="70px" OnClick="btnRegresar_Click" />      
                <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />

              

                <br /><br />

                <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" CssClass="tabla">
                    <Columns>
                        <asp:BoundField DataField="IdRol" HeaderText="ID del Rol" />
                        <asp:BoundField DataField="IdUsuario" HeaderText="ID del Usuario" />
                        <asp:BoundField DataField="NombreRol" HeaderText="Rol de usuario" />
                    </Columns>
                </asp:GridView>
            </div>
        </main>
    </form>
</body>
</html>
