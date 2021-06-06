<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="App_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead>
            <tr class="table-dark">
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col">Cantidad</th>
                <th scope="col">Precio</th>
                <th scope="col">Subtotal</th>
                <th scope="col">Accion</th>
            </tr>
        </thead>

        <asp:Repeater runat="server" ID="repetidor">
            <ItemTemplate>
                <tr>
                    <td><%#Eval("Id")%></td>
                    <td><%#Eval("Articulo.Nombre")%></td>
                    <td>
                        <asp:TextBox TextMode="Number" ID="txtCantidad" Text='<%#Eval("Cantidad")%>' AutoPostBack="true" runat="server" OnTextChanged="txtChangeCantidad"/>
                    </td>
                    <td><%#Eval("Articulo.Precio")%></td>
                    <td><%#Eval("Subtotal")%></td>
                     <td><asp:Button Text="Eliminar" CssClass="btn btn-primary" ID="btnEliminar" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Id")%>' runat="server" /></td>
                </tr>

            </ItemTemplate>
        </asp:Repeater>
        

    </table>
    

</asp:Content>
