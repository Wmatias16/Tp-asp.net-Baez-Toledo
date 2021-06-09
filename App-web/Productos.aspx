<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="App_web.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="margin-top: 25px;">
        <div class="row">
            <div class="col-8">

               

                <div class="input-group flex-nowrap">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="addon-wrapping">Filtrar</span>
                    </div>
                     <asp:TextBox ID="TextBoxFiltrar" runat="server" OnTextChanged="FiltrarTexto" placeholder="buscar" ></asp:TextBox>
                </div>


            </div>
        </div>
        <div class="row">
            <%foreach (Dominio.Articulo item in articulos)
                {%>
            <div class="col">
                <div class="card" style="width: 18rem;">
                    <a href="Detalle.aspx?id=<% = item.Id %>">
                        <img src="<% = item.Imagen %>" class="card-img-top" style="width: 100%" alt="...">
                    </a>

                    <div class="card-body">
                        <h5 class="card-title text-center"><% = item.Nombre %></h5>
                        <p class="card-text text-center" style="font-size: 24px"><% = item.Precio %>$</p>

                        <a href="Detalle.aspx?id=<% = item.Id %>" class="btn btn-primary btn-lg btn-block">Ver detalle</a>
                    </div>
                </div>
            </div>
            <%} %>
        </div>

    </div>


</asp:Content>
