<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="App_web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    

    <div class="container">
    <div class="row">
        <div class="col-md-12">
            <div class="error-template">
                <h1>
                    Oops!</h1>
                <h2>
                    404 Not Found</h2>
                <div class="error-details">
                      <% =error %>
                </div>
                <div class="error-actions">
                    <a href="Productos.aspx" class="btn btn-primary btn-lg">Home</a>
                </div>
            </div>
        </div>
    </div>
</div>


</asp:Content>
