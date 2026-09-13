<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionInventario.aspx.cs" Inherits="Crud.WebForm.vistas.GestionInventario.GestionInventario" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestión de Inventario</title>
    <link href="estilo7.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Gestion de Inventario</h1>

            <div class="section-title">Inventario</div>
            <asp:GridView ID="gvInventario" runat="server" AutoGenerateColumns="False" CssClass="grid-table" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Categoria" HeaderText="Categoria" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />   
                </Columns>
                <EmptyDataTemplate>
                    No hay datos en el inventario.
                </EmptyDataTemplate>
            </asp:GridView>

            <div class="section-title">Entradas</div>
            <asp:GridView ID="gvEntradas" runat="server" AutoGenerateColumns="False" CssClass="grid-table" ShowHeaderWhenEmpty="true">
                <Columns>             
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-Width="25%" />
                </Columns>
                <EmptyDataTemplate>
                    No hay entradas registradas.
                </EmptyDataTemplate>
            </asp:GridView>

            <div class="section-title">Salidas</div>
            <asp:GridView ID="gvSalidas" runat="server" AutoGenerateColumns="False" CssClass="grid-table" ShowHeaderWhenEmpty="true">
                <Columns>               
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" HeaderStyle-Width="25%" />
                </Columns>
                <EmptyDataTemplate>
                    No hay salidas registradas.
                </EmptyDataTemplate>
            </asp:GridView>

            <br />
            <br />

            <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="boton" OnClick="btnRegresar_Click" Width="407px" />

        </div>
    </form>
</body>
</html>