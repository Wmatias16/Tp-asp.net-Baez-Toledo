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
    public partial class Carrito : System.Web.UI.Page
    {

        public List<CarritoProducto> prods;
        protected void Page_Load(object sender, EventArgs e)
        {

            prods = (List<CarritoProducto>)Session["Carrito"];


            if (prods == null)
            {
                prods = new List<CarritoProducto>();
            }

            if (!IsPostBack)
            {
                repetidor.DataSource = prods;
                repetidor.DataBind();
            }

           
            

        }

        protected void txtChangeCantidad(object sender, EventArgs e)
        {

            /*
            int cantidad = int.Parse(((TextBox)sender).Text);
            CarritoNegocio negocio = new CarritoNegocio(prods);

            List<CarritoProducto> nuevoCarrito = negocio.EditarCantidad(1, cantidad);

            Session.Add("Carrito", nuevoCarrito);
            */
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {   

            var argument = ((Button)sender).CommandArgument;
            CarritoNegocio carritoNeg = new CarritoNegocio(prods);


            List<CarritoProducto> carrito = carritoNeg.EliminarProducto(int.Parse(argument));

            Session.Add("Carrito", carrito);
            repetidor.DataSource = null;
            repetidor.DataSource = carrito;
            repetidor.DataBind();
        }

    }
}

