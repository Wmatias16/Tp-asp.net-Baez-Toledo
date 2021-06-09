using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace App_web
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> articulos;
        public ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            try
            {
                articulos = negocio.Listar();
                Session.Add("ListaArticulos", articulos);                                            
            }
            catch (Exception err)
            {
                Session.Add("Error", err.ToString());
                Response.Redirect("Error.aspx");
            }
           
        }

        protected void FiltrarTexto(object sender, EventArgs e)
        {
            Session.RemoveAll();
            articulos = negocio.Filtrar(TextBoxFiltrar.Text);
            Session.Add("ListaArticulos", articulos);
            
        }

    }
}