﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class CarritoProducto
    {
        private int id;
        private Articulo art;
        public int cantidad;

        public CarritoProducto(int Id) { id = Id; }

        public int Id
        {
            get { return this.id; }
            set { id = value; }
        }
    }
}