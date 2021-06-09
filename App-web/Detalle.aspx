<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="App_web.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card">
            <div class="row">
                <aside class="col-sm-5 border-right">
                    <article class="gallery-wrap">
                        <div class="img-thumbnai">
                            <div>
                                <a href="#">
                                    <img src="<%=art.Imagen %>" style="width: 100%;">
                                </a>
                            </div>
                        </div>

                    </article>
                </aside>
                <aside class="col-sm-7">
                    <article class="card-body p-5">
                        <h3 class="title mb-3"><%=art.Nombre %></h3>

                        <p class="price-detail-wrap">
                            <span class="price h3">
                                <span class="currency">$</span><span class="num"><%=art.Precio %></span>
                            </span>
                        </p>
                        <dl class="item-property">
                            <dt>Descripcion</dt>
                            <dd>
                                <p>
                                    <%=art.Descripcion %>
                                </p>
                            </dd>
                        </dl>
                        <hr>
                        <asp:Button ID="btnAgregarCarrito" runat="server" OnClick="btnAgregar_Click" class="btn btn-lg btn-outline-success" Text="Agregar al carrito" />
                    </article>
                </aside>
            </div>
        </div>
    </div>
</asp:Content>
