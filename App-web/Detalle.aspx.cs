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
    public partial class Detalle : System.Web.UI.Page
    {
        public int id;
        public Articulo art;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Request.QueryString["id"]);

            List<Articulo> articulos = new List<Articulo>();

            articulos = (List<Articulo>)Session["ListaArticulos"];

            art = articulos.Find(x => x.Id == id);
        
        }
    }
}