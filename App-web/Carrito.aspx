<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="App_web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
    <div class="row">
    <div class="col-lg-10">
    <table class="table">
        <thead>
            <tr class="table-dark">
                <th scope="col">#</th>
                <th scope="col">Nombre</th>
                <th scope="col"></th>
                <th scope="col" style="width: 30px;">Cantidad</th>
                <th scope="col"></th>
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
                    <td style="float: right">
                        <asp:Button Text="-" CssClass="btn btn-outline-secondary" ID="btnMenos" OnClick="btnMenos_Click" CommandArgument='<%#Eval("Id")%>' runat="server" /></td>
                    </td>
                    <td>
                        <input id="txtCantidad" type="number" min="1" runat="server" value='<%#Eval("Cantidad")%>' disabled /></td>
                    <td style="float: left">
                        <asp:Button Text="+" CssClass="btn btn-outline-secondary" ID="btnMas" OnClick="btnMas_Click" CommandArgument='<%#Eval("Id")%>' runat="server" imageUrl="" /></td>
                    </td>
                    <td><%#Eval("Articulo.Precio")%></td>
                    <td><%#Eval("Subtotal")%></td>
                    <td>
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger" ID="btnEliminar" OnClick="btnEliminar_Click" CommandArgument='<%#Eval("Id")%>' runat="server" /></td>

                </tr>




            </ItemTemplate>
        </asp:Repeater>




    </table>
      </div>


    <div class="col-lg-2" style="margin-top:20px;   ">

      <!-- Card -->
      <div class="mb-3">
        <div class="pt-4">

          <h5 class="mb-3">Total del Carrito</h5>

          <ul class="list-group list-group-flush">
            <li class="list-group-item d-flex justify-content-between align-items-center px-0">
              Envio
              <span>Gratis</span>
            </li>
            <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
              <div>
                <strong>Total a Pagar</strong>
                <strong>
                  <p class="mb-0">(Incluye Iva)</p>
                </strong>
              </div>
              <span><strong><%=Total %></strong></span>
            </li>
          </ul>

          <button type="button" class="btn btn-success btn-block">Finalizar Compra</button>

        </div>
      </div>
      <!-- Card -->

         </div>
     </div>
    </div>
</asp:Content>
