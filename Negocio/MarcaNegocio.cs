using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar() 
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("SELECT Id,Descripcion from MARCAS");
                datos.EjecutarLectura();

                while (datos.Leer.Read())
                {
                    lista.Add(new Marca((int)datos.Leer["Id"], (string)datos.Leer["Descripcion"]));
                }
                return lista;
            }
            catch(Exception err)
            {
                throw err;
            }
            finally
            {
                datos.CerraConexion();
            }

            
        }

    }
}
