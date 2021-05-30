using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
       
        private int id;
        private string descripcion;

        public Marca(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public Marca(int id, string descripcion)
        {
            this.descripcion = descripcion;
            this.id = id;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
        }

        public override string ToString()
        {
            return this.descripcion;
        }

    }
}
