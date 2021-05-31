using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{

    

    class CarritoNegocio
    {

        List<CarritoProducto> carrito = new List<CarritoProducto>();

        
        public void Agregar(int id)
        {

            CarritoProducto Producto = new CarritoProducto(id);

            if (carrito.Contains(Producto))
            {
                foreach (CarritoProducto pr in carrito)
                {
                    if (pr.Id == Producto.Id) pr.cantidad++;
                }
            }
            else
            {
                Producto.cantidad = 1;
                carrito.Add(Producto);
            }
        }


    }
}
