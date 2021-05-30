using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Filtrar(string txtFiltrar)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> articulos = new List<Articulo>();

            string inner = "SELECT A.Codigo,A.Nombre,A.Descripcion,A.Precio,C.Descripcion AS Categoria,M.Descripcion AS Marca from ARTICULOS AS A  INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id INNER JOIN MARCAS AS M ON A.IdMarca = M.Id WHERE ";
            string filter = "A.Codigo LIKE '%" + txtFiltrar + "%'OR A.Nombre LIKE '%" + txtFiltrar  + "%' OR A.Precio LIKE '%" + txtFiltrar  + "%'";
            try
            {
                datos.SetearConsulta(inner + filter);
                datos.EjecutarLectura();

                while (datos.Leer.Read())
                {
                    Articulo art = new Articulo();

                    art.Nombre = (string)datos.Leer["Nombre"];
                    art.Marca = new Marca((string)datos.Leer["Marca"]);
                    art.Precio = decimal.Round((decimal)datos.Leer["Precio"], 2);
                    art.Categoria = new Categoria((string)datos.Leer["Categoria"]);
                    art.Descripcion = (string)datos.Leer["Descripcion"];
                    art.CodigoArticulo = (string)datos.Leer["Codigo"];

                    articulos.Add(art);
                }
                return articulos;

            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                datos.CerraConexion();
            }
        }

        public void Agregar(Articulo art)
        {
            AccesoDatos db = new AccesoDatos();

            try
            {
                string valores = "values('" + art.CodigoArticulo + "', '" + art.Nombre + "', '" + art.Descripcion + "', '" + art.Marca.Id + "', '" + art.Categoria.Id + "', '" + art.Imagen + "','"+ art.Precio + "')";
                db.SetearConsulta("INSERT INTO Articulos (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) "+valores);

                db.EjectutarAccion();
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                db.CerraConexion();
            }
        } 

        public void Modificar(Articulo art)
        {

            AccesoDatos db = new AccesoDatos();

            try
            {   
                db.SetearConsulta("UPDATE Articulos SET Codigo='" + art.CodigoArticulo + "', Nombre='" + art.Nombre + "', Descripcion='" + art.Descripcion + "', IdMarca=" + art.Marca.Id + ", IdCategoria=" + art.Categoria.Id + ", ImagenUrl='" + art.Imagen + "', Precio='" + art.Precio +"' WHERE Id="+art.Id);
                db.EjectutarAccion();
            }
            catch(Exception err)
            {
                throw err;
            }
            finally
            {
                db.CerraConexion();
            }

        }

        public void Eliminar(int id)
        {
            AccesoDatos db = new AccesoDatos();
            try
            {
                db.SetearConsulta("Delete From Articulos where Id = " + id);
                db.EjectutarAccion();
            }
            catch(Exception err)
            {
                throw err;
            }
            finally
            {
                db.CerraConexion();
            }
        }

        public bool VerificarCodigo(string Codigo)
        {
            int VerifCantidad = 0;
            bool Verif = true;
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.SetearConsulta("SELECT count (Codigo) as Codigo from ARTICULOS WHERE Codigo = '" +Codigo+"'");
                datos.EjecutarLectura();

                if (datos.Leer.Read())
                {
                   VerifCantidad = (Int32)datos.Leer[0];

                    if(VerifCantidad > 0)
                    {
                        Verif = false;
                    }

                }
 
            }
            catch (Exception err)
            {
                throw err;
            }
            finally
            {
                datos.CerraConexion();
            }

            
            return Verif;
        }

        public List<Articulo> Listar()
        {

            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string value = "WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                datos.SetearConsulta("SELECT A.Id,A.Codigo, A.Nombre, A.Descripcion,A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, ImagenUrl, A.Precio FROM ARTICULOS AS A, MARCAS AS M, CATEGORIAS AS C "+ value);
                datos.EjecutarLectura();

                while (datos.Leer.Read())
                {
                    Articulo art = new Articulo();

                    art.Id = (int)datos.Leer["Id"];
                    art.Nombre = (string)datos.Leer["Nombre"];
                    art.Marca = new Marca((string)datos.Leer["Marca"]);
                    art.Precio = decimal.Round((decimal)datos.Leer["Precio"],2);
                    art.Imagen = (string)datos.Leer["ImagenUrl"];
                    art.Categoria = new Categoria((string)datos.Leer["Categoria"]);
                    art.Descripcion = (string)datos.Leer["Descripcion"];
                    art.CodigoArticulo = (string)datos.Leer["Codigo"];

                   

                    articulos.Add(art);
                }
                return articulos;
            }
            catch (Exception err)
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
