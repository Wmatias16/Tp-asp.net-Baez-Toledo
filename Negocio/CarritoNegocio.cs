using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{

    public class CarritoNegocio
    {
        private List<CarritoProducto> carrito;

        public CarritoNegocio(List<CarritoProducto> carrito)
        {
            this.carrito = carrito;
        }

        public List<CarritoProducto> Agregar(int id)
        {
            CarritoProducto Producto = new CarritoProducto(id);

            foreach (CarritoProducto pr in carrito)
            {
                if (pr.Id == Producto.Id)
                {
                    pr.cantidad++;
                    return carrito;
                }
            }

            Producto.cantidad = 1;
            carrito.Add(Producto);

            return carrito;
        }


        public List<CarritoProducto> EditarCantidad(int id, int cant)
        {

            foreach (CarritoProducto pr in carrito)
            {
                if (pr.Id == id)
                {
                    pr.cantidad = cant;
                }
            }

            return carrito;
        }


        public List<CarritoProducto> EliminarProducto(int id)
        {

            CarritoProducto elim = carrito.Find(x => x.Id == id); ;
            carrito.Remove(elim);
            return carrito;
        }

    }
}
