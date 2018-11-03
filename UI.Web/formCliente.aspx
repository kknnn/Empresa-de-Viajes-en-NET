<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="formCliente.aspx.cs" Inherits="UI.Web.formCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 447px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
        <asp:Button ID="btnBoletos" runat="server" OnClick="btnBoletos_Click" Text="Comprar Boleto" />
        <asp:Button ID="btnHistorialCompras" runat="server" OnClick="btnHistorialCompras_Click" Text="Historial de Compras" />
    <div>
    
        <asp:Panel ID="panelCompra" runat="server" Height="181px" Visible="False">
            <asp:GridView ID="gvCompra" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID Boleto" />
                    <asp:BoundField DataField="FechaSalida" HeaderText="Fecha Salida" />
                    <asp:BoundField DataField="FechaRegreso" HeaderText="Fecha Regreso" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="IDColectivo" HeaderText="ID Colectivo" />
                    <asp:BoundField DataField="Destino" HeaderText="Destino" />
                    <asp:BoundField DataField="AsientosDisponibles" HeaderText="Asientos Disponibles" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <SelectedRowStyle BackColor="Black" ForeColor="White" />
            </asp:GridView>
            <asp:Button ID="btnCompra" runat="server" OnClick="btnCompra_Click" Text="Comprar" />
            <br />
        </asp:Panel>
            <asp:Panel ID="panelHistorialCompras" runat="server" Height="188px" Visible="False">
                <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="fecha_compra" HeaderText="Fecha de Compra" />
                        <asp:BoundField DataField="descripcion" HeaderText="Destino" />
                        <asp:BoundField DataField="precio" HeaderText="Precio" />
                        <asp:BoundField DataField="descripcion" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>

    
    </div>
    </form>
</body>
</html>
