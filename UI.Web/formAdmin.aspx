<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formAdmin.aspx.cs" Inherits="UI.Web.formAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnPendientes" runat="server" OnClick="btnHistorial_Click" Text="Compras Pendientes" />
        <asp:Button ID="btnColectivos" runat="server" OnClick="btnColectivos_Click" Text="Colectivos" />
        <asp:Button ID="btnDestinos" runat="server" OnClick="btnDestinos_Click" Text="Destinos" />
    
    </div>
        <asp:Panel ID="panelCompras" runat="server" Height="174px" Visible="False">
            <asp:GridView ID="gvCompras" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID Compra" />
                    <asp:BoundField DataField="FechaCompra" HeaderText="Fecha Compra" />
                    <asp:BoundField DataField="IDBoleto" HeaderText="ID Boleto" />
                    <asp:BoundField DataField="IDUsuario" HeaderText="ID Usuario" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
            <asp:Button ID="btnHabilitar" runat="server" OnClick="btnHabilitar_Click" Text="Habilitar" />
            <asp:Button ID="btnEliminarCompra" runat="server" OnClick="btnEliminarCompra_Click" Text="Eliminar" />
            <br />
        </asp:Panel>
        <asp:Panel ID="panelColectivos" runat="server" Height="353px" Visible="False">
            <asp:GridView ID="gvColectivos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID Colectivo" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca" />
                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                    <asp:BoundField DataField="CantidadAsientos" HeaderText="Asientos" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
            <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" />
            <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
            <br />
            <asp:Panel ID="panelNuevoColectivo" runat="server" Height="125px" Visible="False">
                <asp:Label ID="Label1" runat="server" Text="Marca: "></asp:Label>
                <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Modelo: "></asp:Label>
                <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Cantidad de Asientos: "></asp:Label>
                <asp:TextBox ID="txtCantidadAsientos" runat="server" TextMode="Number"></asp:TextBox>
                <br />
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="panelDestinos" runat="server" Visible="False" Height="91px">
        </asp:Panel>
    </form>
</body>
</html>
