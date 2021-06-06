using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class CarritoProducto
    {
        private int id;
        private Articulo articulo;
        public int cantidad;
        public decimal subtotal;
        public CarritoProducto(int Id) { id = Id; }

        public int Id
        {
            get { return this.id; }
            set { id = value; }
        }

        public int Cantidad
        {
            get { return this.cantidad; }
            set { id = value; }
        }
        public decimal Subtotal
        {
            get { return this.articulo.Precio * this.cantidad; }
            set { this.subtotal = value; }
        }

        public Articulo Articulo
        {
            get { return this.articulo; }
            set { articulo = value; }
        }
    }
}
