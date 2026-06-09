<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CatalogoProductos.aspx.cs" Inherits="Crud.WebForm.CatalogoProductos" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <!-- Enlace al CSS externo -->
    <link rel="stylesheet" type="text/css" href="estilo6.css" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Ferreteria MOMO</title>
</head>

<body>
    <form id="form1" runat="server">
        <main class="contenido">
            <div class="card">
                <h2>Catálogo de Productos</h2>
                <br />
                <div class="cuerpo">
                    <asp:GridView ID="gvCatalogo" runat="server" AutoGenerateColumns="False" CssClass="tabla" Width="558px">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        </Columns>
                    </asp:GridView>

                    <div class="filtros">
                        <asp:Label ID="lblFiltros" runat="server" Text="Filtros:" AssociatedControlID="ddlFiltro"></asp:Label>
                        <asp:DropDownList ID="ddlFiltro" runat="server">
                            <asp:ListItem>Nombre</asp:ListItem>
                            <asp:ListItem>Categoria</asp:ListItem>
                        </asp:DropDownList>

                        <asp:Label ID="lblBusqueda" runat="server" Text="Escribe el producto a consultar:" AssociatedControlID="txtBusqueda"></asp:Label>
                        <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>

                        <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" AssociatedControlID="ddlCantidad"></asp:Label>
                        <asp:DropDownList ID="ddlCantidad" runat="server">
                            <asp:ListItem>Menor a mayor</asp:ListItem>
                            <asp:ListItem>Mayor a menor</asp:ListItem>
                        </asp:DropDownList>

                    <div class="acciones">
                        <asp:Button ID="btnAplicar" runat="server" Text="Aplicar" CssClass="boton" OnClick="btnAplicar_Click" />
                        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="boton" OnClick="btnRegresar_Click" />
                        <asp:Button ID="btnQuitarFiltro" runat="server" Text="Quitar Filtro" CssClass="boton" OnClick="btnQuitarFiltro_Click" />

                    </div>

                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
