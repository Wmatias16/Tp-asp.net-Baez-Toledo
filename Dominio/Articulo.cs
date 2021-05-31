using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        private int id;
        private string codigoArticulo;
        private string nombre;
        private string descripcion;
        private string imagen;
        private decimal precio;

        private Marca marca;
        private Categoria categoria;

        public string CodigoArticulo
        {
            get { return this.codigoArticulo; }
            set { codigoArticulo = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return this.descripcion; }
            set { descripcion = value; }
        }

        public string Imagen
        {
            get { return this.imagen; }
            set { imagen = value; }
        }

        public Marca Marca
        {
            get { return this.marca; }
            set { marca = value; }
        }

        public Categoria Categoria
        {
            get { return this.categoria; }
            set { categoria = value; }
        }

        public decimal Precio
        {
            get { return this.precio; }
            set { precio = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { id = value; }
        }
    }
}


