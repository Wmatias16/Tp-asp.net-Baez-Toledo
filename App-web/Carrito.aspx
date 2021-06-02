<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="App_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table table-dark">

        <thead>
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Precio</th>
                <th scope="col">Subtotal</th>
                <th scope="col">Cantidad</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (Dominio.CarritoProducto carrito in prods) 
                {%>
                    <tr>
                        <th scope="row"><%=carrito.Id %></th>
                        <td><%=carrito.Articulo.Nombre %></td>
                        <td><%=carrito.Articulo.Precio %>$</td>
                        <td><%=carrito.Articulo.Precio*carrito.Cantidad %>$</td>
                        <td><%=carrito.Cantidad %></td>
                    </tr>
                <%}
            %>
        </tbody>

    </table>
</asp:Content>
