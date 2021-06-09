using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;

namespace App_web
{
    public partial class SiteMaster : MasterPage
    {
        public List<CarritoProducto> carrito = new List<CarritoProducto>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Carrito"] == null)
            {
                Session.Add("Carrito",new List<CarritoProducto>());
            }
            else
            {
                carrito = (List<CarritoProducto>)Session["Carrito"];
            }
        }

    }
}