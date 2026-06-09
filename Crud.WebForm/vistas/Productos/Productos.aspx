<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Crud.WebForm.Productos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <link rel="stylesheet" type="text/css" href="estilo5.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ferreteria MOMO</title>
</head>

<body>
    <form id="form1" runat="server">
        <main class="contenido">
            <div class="card">
                <h2>Producto</h2>
                <br />

                <div class="input-group">
                    <label for="txtClave">Clave del producto:</label>
                    <asp:TextBox ID="txtClave" runat="server" CssClass="campo" />
                </div>

                <div class="input-group">
                    <label for="txtNombre">Nombre del producto:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" />
                </div>
                <br />

                <div class="input-group">
                    <label for="txtCategoria">Categoría:</label>
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="campo" />
                </div>

                <div class="input-group">
                    <label for="txtCantidad">Cantidad:</label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="campo" />
                </div>
                <br />

                <div class="input-group">
                    <label for="txtDescripcion">Descripción:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="campo" />
                </div>
                <br /><br />

                <asp:ImageButton ID="btnAlta" runat="server" ImageUrl="~/vistas/Productos/pic_alta.png" AlternateText="Alta" Height="70px" Width= "70px" OnClick="btnAlta_Click"/> 
                <asp:ImageButton ID="btnBaja" runat="server" ImageUrl="~/vistas/Productos/pic_modif.png" AlternateText="Baja" Height="70px" Width="70px" OnClick="btnBaja_Click" />
                <asp:ImageButton ID="btnConsulta" runat="server" ImageUrl="~/vistas/Productos/pic_baja.png" AlternateText="Consulta" Height="70px" Width="70px" OnClick="btnConsulta_Click" />
                <asp:ImageButton ID="btnModificacion" runat="server" ImageUrl="~/vistas/Productos/pic_cons.png" AlternateText="Modificacion" Height="70px" Width="70px" OnClick="btnModificacion_Click" />
                <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/vistas/Productos/pic_back.png" AlternateText="Regresar" Height= "70px" Width="70px" OnClick="btnRegresar_Click" />



                <br /><br />

                <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />

                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="tabla" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ClaveProducto" HeaderText="Clave del producto" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del producto" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    </Columns>
                </asp:GridView>
            </div>
        </main>
    </form>
</body>
</html>
