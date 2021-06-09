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

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

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

    }
}