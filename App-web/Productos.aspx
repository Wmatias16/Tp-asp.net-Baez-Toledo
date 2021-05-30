<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="App_web.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hola mundo</h1>


    <div class="container">

        <div class="row">

            <%foreach(Dominio.Articulo item in articulos)
                    {%>
            <div class="col">
                <div class="card" style="width: 18rem;" >
                    <img src="<% = item.Imagen %>"  class="card-img-top" alt="...">
                    <div class="card-body">
                        <h5 class="card-title text-center"><% = item.Nombre %></h5>
                        <p class="card-text text-center" style ="font-size : 24px"><% = item.Precio %>$</p>
                        <a href="#" class="btn btn-primary btn-lg btn-block">add to cart</a>
                    </div>
                </div>
            </div>
              <%} %>
        </div>
    </div>

    
</asp:Content>
