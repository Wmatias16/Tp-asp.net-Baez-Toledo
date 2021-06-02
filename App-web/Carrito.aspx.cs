using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Dominio;

namespace App_web
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<CarritoProducto> prods;
        protected void Page_Load(object sender, EventArgs e)
        {
            prods = (List<CarritoProducto>)Session["Carrito"];
            dgv.DataSource = prods;
            dgv.DataBind();
        }
    }
}

