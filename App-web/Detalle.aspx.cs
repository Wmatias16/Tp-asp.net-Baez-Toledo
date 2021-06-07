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
        List<CarritoProducto> productos;

        protected void Page_Load(object sender, EventArgs e)
        {
           

            try
            {

                if (Session["Carrito"] == null)
                {
                    Session.Add("Carrito", new List<CarritoProducto>());
                }
                else
                {
                    productos = (List<CarritoProducto>)Session["Carrito"];
                }


                id = int.Parse(Request.QueryString["id"]);

                List<Articulo> articulos = new List<Articulo>();

                articulos = (List<Articulo>)Session["ListaArticulos"];

                art = articulos.Find(x => x.Id == id);/// buscamos el producto


                if (art == null)
                {
                    Session.Add("Error", "Producto inexistente");
                    Response.Redirect("Error.aspx");
                }

            }
            catch (Exception err)
            {

                Session.Add("Error", err.ToString());
                Response.Redirect("Error.aspx");

            }



        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CarritoNegocio carrito = new CarritoNegocio(productos);

            productos = carrito.Agregar(id);
            

            foreach(CarritoProducto produc in productos)
            {

                if(produc.Id == id)
                {
                    produc.Articulo = art;
                }
            }

            Session.Add("Carrito", productos);
        }
    }
}