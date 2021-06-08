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
        public decimal Total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            prods = (List<CarritoProducto>)Session["Carrito"];


            if (prods == null)
            {
                prods = new List<CarritoProducto>();
            }

            if (!IsPostBack)
            {

                Total = CalcularTotal();

                repetidor.DataSource = prods;
                repetidor.DataBind();
            }

        }

        public decimal CalcularTotal()
        {

            decimal total = 0;

            foreach (CarritoProducto carro in prods)
            {
                total += carro.Subtotal;
                
            }

            return total;

        }


        protected void txtChangeCantidad(object sender, EventArgs e)
        {
            
        }

        protected void btnMenos_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            CarritoNegocio negocio = new CarritoNegocio(prods);

            List<CarritoProducto> nuevoCarrito = negocio.EditarCantidad(id, false);

            Session.Add("Carrito", nuevoCarrito);
            repetidor.DataSource = null;
            repetidor.DataSource = nuevoCarrito;
            repetidor.DataBind();

            Total = CalcularTotal();


        }

        protected void btnMas_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);
            CarritoNegocio negocio = new CarritoNegocio(prods);

            List<CarritoProducto> nuevoCarrito = negocio.EditarCantidad(id, true);

            Session.Add("Carrito", nuevoCarrito);
            repetidor.DataSource = null;
            repetidor.DataSource = nuevoCarrito;
            repetidor.DataBind();

            Total = CalcularTotal();

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

            Total = CalcularTotal();


        }

    }
}

