<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="Crud.WebForm.Usuario" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <link rel="stylesheet" type="text/css" href="estilo3.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ferreteria MOMO</title>
</head>

<body>
    <form id="formUsuarios" runat="server">
        <main class="contenido">
            <div class="card">
                <h2>Usuarios</h2>
                <br /> 
                
               
                <div class="input-group">
                    <label for="txtId">ID:</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="campo" />
                </div>

                <div class="input-group">
                    <label for="txtNombre">Nombre(s):</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" />
                </div>
                <br />

                <div class="input-group">
                    <label for="txtApellidoP">Apellido paterno:</label>
                    <asp:TextBox ID="txtApellidoP" runat="server" CssClass="campo" />
                </div>

                <div class="input-group">
                    <label for="txtApellidoM">Apellido materno:</label>
                    <asp:TextBox ID="txtApellidoM" runat="server" CssClass="campo" />
                </div>
                <br />

                <div class="input-group">
                    <label for="txtUsuario">Nombre de usuario:</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="campo" />
                </div>

                <div class="input-group">
                    <label for="txtPass">Contraseña:</label>
                    <asp:TextBox ID="txtPass" runat="server" CssClass="campo" TextMode="Password" />
                </div>
                <br /><br />

                <asp:Label ID="lblFallo" runat="server" ForeColor="Red"/>
                <asp:Label ID="lblExito" runat="server" ForeColor="Green" />

                <br /><br />

                <asp:ImageButton ID="btnAlta" runat="server" ImageUrl="~/vistas/Usuario/pic_alta.png" AlternateText="Alta" Height="70px" Width= "70px" OnClick="btnAlta_Click"/> 
                <asp:ImageButton ID="btnBaja" runat="server" ImageUrl="~/vistas/Usuario/pic_baja.png" AlternateText="Baja" Height="70px" Width="70px" OnClick="btnBaja_Click" />
                <asp:ImageButton ID="btnConsulta" runat="server" ImageUrl="~/vistas/Usuario/pic_cons.png" AlternateText="Consulta" Height="70px" Width="70px" OnClick="btnConsulta_Click" />
                <asp:ImageButton ID="btnModificacion" runat="server" ImageUrl="~/vistas/Usuario/pic_modif.png" AlternateText="Modificacion" Height="70px" Width="70px" OnClick="btnModificacion_Click" />
                <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/vistas/Usuario/pic_back.png" AlternateText="Regresar" Height= "70px" Width="70px" OnClick="btnRegresar_Click" />               
                <br /><br />

                 <div class="contenedor-tabla">
                    <asp:GridView ID="gvUsuarios" runat="server" CssClass="tabla"
                        AutoGenerateColumns="False" GridLines="None" CellPadding="5">
                            <Columns>
                    <asp:BoundField DataField="IdUsuario" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre(s)" />
                    <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                    <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Nombre de Usuario" />
                    <asp:BoundField DataField="Contrasena" HeaderText="Contraseña" />
                            </Columns>
                     </asp:GridView>
                 </div>

                
            </div>
        </main>
    </form>
</body>
</html>
