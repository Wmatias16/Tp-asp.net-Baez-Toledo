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

        public Articulo Articulo
        {
            get { return this.articulo; }
            set { articulo = value; }
        }
    }
}
